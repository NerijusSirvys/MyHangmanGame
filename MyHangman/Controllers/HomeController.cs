using Microsoft.AspNet.Identity;
using MyHangman.Enums;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class HomeController : Controller
    {

        private List<int> LevelSetIDs { get; set; }

        public HomeController()
        {
            LevelSetIDs = new List<int>();
        }

        public ActionResult BeginNewLevel()
        {
            Player player = GameEngine.GetPlayer(User.Identity.GetUserId());

            Level level = GameEngine.GetRandomLevel(LevelSetIDs, player.CompleteLevels);

            LevelSetIDs.Remove(level.ID);

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

            model.GameScore = GameEngine.UpdatePlayerGameScore(User.Identity.GetUserId(), model.LevelDifficulty, isGuessCorrect, model.IsWin, model.IsLoss);

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