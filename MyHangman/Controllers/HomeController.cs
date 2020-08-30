using Microsoft.AspNet.Identity;
using MyHangman.Enums;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class HomeController : Controller
    {

        private List<int> LevelSet { get; set; }

        public HomeController()
        {
            LevelSet = new List<int>();
        }

        // GET: Home
        public ActionResult BeginNewLevel()
        {
            Player player = GameEngine.GetPlayer(User.Identity.GetUserId());

            LevelSet = GameEngine.LoadLevelSet(player.CompleteLevels);

            // TODO randimize level feed to game
            Level level = GameEngine.GetLevelByID(LevelSet[0]);

            GameVM viewModel = Mapper.MapGameVM(player, level);

            return View("Index", viewModel);
        }

        public ActionResult GuessLetter(char key, GameVM model)
        {
            ModelState.Clear();

            model.HiddenAnswer = GameEngine.ProcessLetterGuess(key, model.HiddenAnswer, model.OpenAnswer, out bool isGuessCorrect);

            model.NumberOfCorrectGuesses = GameEngine.UpdateCorrectGuessCount(isGuessCorrect, model.NumberOfCorrectGuesses);

            model.NumberOfGuessesLeft = GameEngine.UpdateFailedGuessCount(isGuessCorrect, model.NumberOfGuessesLeft);

            model.IsWin = GameEngine.CheckForWin(model.NumberOfCorrectGuesses, model.OpenAnswer.Length);

            model.IsLoss = GameEngine.CheckForLoss(model.NumberOfGuessesLeft);

            if (model.IsWin)
            {
                GameEngine.AddWinToPlayer(User.Identity.GetUserId(), model.LevelID);

                GameState gameState = new GameState
                {
                    IsWin = true,
                    Message = "Level complete...!!!"
                };

                return View("GameMessage", gameState);
            }

            if (model.IsLoss)
            {
                GameState gameState = new GameState
                {
                    IsLoss = true,
                    Message = "You run out of guesses. Game Over...!!!"
                };

                return View("GameMessage", gameState);
            }

            return View("Index", model);
        }
    }
}