using Microsoft.AspNet.Identity;
using MyHangman.Enums;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult BeginNewLevel()
        {
            // TODO start levels that players have not completed yet
            //      always start with very easy level
            //      once all current difficulty levels are copmpleted, start next difficulty set of levels
            
            Player player = GameEngine.GetPlayer(User.Identity.GetUserId());

            Level level = GameEngine.GetLevelByDifficulty(LevelDifficulty.Easy);

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

                return RedirectToAction("BeginNewLevel");
            }

            if (model.IsLoss)
            {
                EventState eventState = new EventState
                {
                    IsSuccess = false,
                    Message = "You run out of guesses. Game Over..."
                };

                return RedirectToAction("Status", eventState);
            }

            return View("Index", model);
        }
    }
}