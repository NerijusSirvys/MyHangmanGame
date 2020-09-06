using MyHangman.DTO;
using MyHangman.Models;
using MyHangman.ViewModels;
using System.Collections.Generic;

namespace MyHangman.Services
{
    public static class Mapper
    {
        //--------------------------------------------------------------------------------------------------------
        //------------------------------PUBLIC METHODS-----------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        public static GameVM MapGameVM(GameDTO dto)
        {
            return new GameVM()
            {
                LevelID = dto.Level.LevelID,
                Riddle = dto.Level.Riddle,
                OpenAnswer = dto.Level.Secret,
                HiddenAnswer = GameVM.HideAnswer(dto.Level.Secret.Length),
                FailedGuesses = 0,
                CorrectGuesses = 0,
                GameScore = dto.Player.GameScore,
                GoldenCoins = dto.Player.GoldenCoins,
                LevelDifficulty = dto.Level.Difficulty,
                Progress = GameEngine.GetGameProgress(dto.Player.NumberOfCompleteLevels),
                Hints = new List<HintVM>
                {
                    new HintVM { OpenHint = dto.Level.Hints[0].Body, IsOpen = HintManager.LookForOpenHint(dto.Player.ID, dto.Level.Hints[0].ID), ID = dto.Level.Hints[0].ID },
                    new HintVM { OpenHint = dto.Level.Hints[1].Body, IsOpen = HintManager.LookForOpenHint(dto.Player.ID, dto.Level.Hints[1].ID), ID = dto.Level.Hints[1].ID },
                    new HintVM { OpenHint = dto.Level.Hints[2].Body, IsOpen = HintManager.LookForOpenHint(dto.Player.ID, dto.Level.Hints[2].ID), ID = dto.Level.Hints[2].ID }
                }
            };
        }

        public static GameVM MapVMToLetterProcessingDTO(LetterProcessingDTO dto, GameVM model)
        {
            model.CorrectGuesses = dto.CorrectGuesses;
            model.FailedGuesses = dto.FailedGuesses;
            model.GameScore = dto.GameScore;
            model.GoldenCoins = dto.GoldenCoins;
            model.HiddenAnswer = dto.Secret;

            return model;
        }

        public static PlayerDTO MapPlayerToDTO(Player player)
        {
            return new PlayerDTO
            {
                ID = player.Id,
                GameScore = player.GameScore,
                GoldenCoins = player.GoldenCoins,
                NumberOfCompleteLevels = player.CompleteLevels.Count
            };
        }

        public static LetterProcessingDTO MapModelToLetterProcessingDTO(GameVM model, string playerID)
        {
            return new LetterProcessingDTO
            {
                PlayerID = playerID,
                CorrectGuesses = model.CorrectGuesses,
                FailedGuesses = model.FailedGuesses,
                GameScore = model.GameScore,
                GoldenCoins = model.GoldenCoins,
                Secret = model.HiddenAnswer,
                Answer = model.OpenAnswer,
                LevelDifficulty = model.LevelDifficulty
            };
        }

        public static LevelDTO MapLevelToDTO(Level level)
        {
            return new LevelDTO
            {
                LevelID = level.ID,
                Riddle = level.Riddle,
                Secret = level.Answer,
                Difficulty = level.Difficulty,
                Hints = MapHints(level.Hints)
            };
        }

        //--------------------------------------------------------------------------------------------------------
        //------------------------------PRIVATE METHODS-----------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        private static List<HintDTO> MapHints(List<Hint> hints)
        {
            List<HintDTO> output = new List<HintDTO>();

            foreach (var item in hints)
            {
                output.Add(new HintDTO { ID = item.ID, Body = item.Body });
            }

            return output;
        }
    }
}