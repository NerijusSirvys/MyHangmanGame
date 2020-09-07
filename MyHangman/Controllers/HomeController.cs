using Microsoft.AspNet.Identity;
using MyHangman.DTO;
using MyHangman.Models;
using MyHangman.Services;
using MyHangman.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyHangman.Controllers
{
    public class HomeController : Controller
    {
        public GameEngine GameEngine { get; set; }

        public HomeController()
        {
            GameEngine = new GameEngine();
        }

        public ActionResult BeginNewLevel()
        {
            GameDTO gameDTO = GameEngine.ConstructGameModel(User.Identity.GetUserId());

            GameVM viewModel = Mapper.MapGameVM(gameDTO);

            return View("Index", viewModel);
        }

        public ActionResult GuessLetter(char key, GameVM model)
        {
            ModelState.Clear();

            LetterProcessingDTO dto = Mapper.MapModelToLetterProcessingDTO(model, User.Identity.GetUserId());

            dto = GameEngine.ProcessLetterGuess(dto, key);

            model = Mapper.MapVMToLetterProcessingDTO(dto, model);

            if (model.IsWin)
            {
                GameEngine.AddWinToPlayer(User.Identity.GetUserId(), model.LevelID);

                GameStateVM gameState = new GameStateVM
                {
                    IsWin = true,
                    Message = "Level complete...!!!"
                };

                return View("GameMessage", gameState);
            }

            if (model.IsLoss)
            {
                GameStateVM gameState = new GameStateVM
                {
                    IsLoss = true,
                    Message = "You run out of guesses. Game Over...!!!"
                };

                return View("GameMessage", gameState);
            }

            return View("Index", model);
        }

        public ActionResult OpenHint(GameVM model, int hintPosition, int hintID)
        {
            if (model.GoldenCoins < HintManager.CalculatePrice(model.LevelDifficulty, hintPosition))
            {
                return View("Index", model);
            }

            ModelState.Clear();

            model.GoldenCoins = GameEngine.PayForHint(User.Identity.GetUserId(), model.LevelID, hintPosition);

            model.Hints.Find(x => x.ID == hintID).IsOpen = GameEngine.OpenHint(User.Identity.GetUserId(), model.LevelID, hintID);

            return View("Index", model);
        }

        public ActionResult LeaderBoard()
        {
            List<LeaderBoardEntryDTO> dto = GameEngine.ConstructLeaderBoard();

            List<LeaderBoardEntryVM> model = Mapper.MapDTOToVM(dto);

            return View(model);
        }
    }
}