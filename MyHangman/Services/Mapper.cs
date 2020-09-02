using MyHangman.Models;
using MyHangman.ViewModels;
using System.Collections.Generic;

namespace MyHangman.Services
{
    public static class Mapper
    {
        // TODO make opened hints to apear open for player not for level use hint manager
        public static GameVM MapGameVM(Player player, Level level)
        {
            GameVM viewModel = new GameVM
            {
                LevelID = level.ID,
                IsLoss = false,
                IsWin = false,
                Riddle = level.Riddle,
                OpenAnswer = level.Answer,
                NumberOfGuessesLeft = GameEngine.NumberOfAvailableGuesses,
                NumberOfCorrectGuesses = 0,
                HiddenAnswer = GameEngine.HideAnswer(level.Answer.Length),
                GameScore = player.GameScore,
                GoldenCoins = player.GoldenCoins,
                LevelDifficulty = level.Difficulty,
                Progress = GameEngine.CalculateGameProgress(player),
                Hints = new List<HintVM>
                {
                    new HintVM{OpenHint = level.Hints[0].Body, IsOpen = HintManager.LookForOpenHint(player.Id, level.Hints[0].ID), ID = level.Hints[0].ID},
                    new HintVM{OpenHint = level.Hints[1].Body, IsOpen = HintManager.LookForOpenHint(player.Id, level.Hints[1].ID), ID = level.Hints[1].ID },
                    new HintVM{OpenHint = level.Hints[2].Body, IsOpen = HintManager.LookForOpenHint(player.Id, level.Hints[2].ID), ID = level.Hints[2].ID }
                }
            };

            return viewModel;
        }
    }
}