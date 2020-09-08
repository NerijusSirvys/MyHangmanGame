using MyHangman.DTO;
using MyHangman.Enums;
using MyHangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace MyHangman.Services
{
    public class GameEngine
    {
        private Random Random { get; }
        private DataAccess DataAccess { get; }
        private List<Level> LevelsToComplete { get; set; }

        public GameEngine()
        {
            DataAccess = new DataAccess();
            Random = new Random();
            LevelsToComplete = new List<Level>();
        }

        //--------------------------------------------------------------------------------------------------------
        //-----------------------------------PUBLIC METHODS-------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        public GameDTO ConstructGameModel(string playerID)
        {
            GameDTO gameDTO = new GameDTO();

            Player player = DataAccess.GetPlayerByID(playerID);
            Level level = GetRandomLevel(player.CompleteLevels);

            if(level == null)
            {
                return null;
            }

            gameDTO.Player = Mapper.MapPlayerToDTO(player);
            gameDTO.Level = Mapper.MapLevelToDTO(level);


            return gameDTO;
        }

        public void AddWinToPlayer(string playerID, int levelID)
        {
            Player player = DataAccess.GetPlayerByID(playerID);
            player.CompleteLevels.Add(new CompleteLevel { LevelID = levelID });

            DataAccess.Save();
        }

        // no callers at the moment but this will be implemented in the future
        public Level GetLevelByDifficulty(LevelDifficulty levelDifficulty)
        {
            List<Level> levels = DataAccess.GetAllLevels();

            return levels.Find(x => x.Difficulty == levelDifficulty);
        }

        public Level GetRandomLevel(IEnumerable<CompleteLevel> completeLevels)
        {
            List<Level> incompleteLevels = GetAllIncompleteLevels(completeLevels);

            if(incompleteLevels.Count == 0)
            {
                return null;
            }

            if (LevelsToComplete.Count == 0)
            {
                LevelsToComplete = GetSameDifficultyLevels(incompleteLevels);
            }

            int index = Random.Next(0, LevelsToComplete.Count);

            return LevelsToComplete.ElementAtOrDefault(index);
        }

        public LetterProcessingDTO ProcessLetterGuess(LetterProcessingDTO dto, char key)
        {
            dto.Secret = UpdateSecret(dto.Answer, dto.Secret, key, out bool IsGuessCorrect);

            if (IsGuessCorrect)
            {
                dto.CorrectGuesses++;
                dto.GoldenCoins += CoinManager.AddCoins(dto.LevelDifficulty);
                dto.GameScore += GameScoreManager.AddScoreForCorrectLetterGuess(dto.LevelDifficulty);
            }
            else
            {
                dto.FailedGuesses++;
                dto.GameScore -= GameScoreManager.SubtractScoreForFailedLetterGuess(dto.LevelDifficulty);
            }

            DataAccess.UpdatePlayer(dto);

            return dto;
        }

        public List<LeaderBoardEntryDTO> ConstructLeaderBoard()
        {
            List<Player> players = DataAccess.GetAllPlayers();

            if (players == null) return null;

            List<LeaderBoardEntryDTO> dto = new List<LeaderBoardEntryDTO>();

            foreach (var item in players)
            {
                dto.Add(new LeaderBoardEntryDTO { GameScore = item.GameScore, PlayerName = item.UserName, LevelsCompleted = item.CompleteLevels.Count });
            }

            return dto;
        }

        public int PayForHint(string playerID, int levelID, int hintPosition)
        {
            Level currentLevel = DataAccess.GetLevelByID(levelID);

            Player player = DataAccess.GetPlayerByID(playerID);

            player.GoldenCoins -= HintManager.SubtractHintPrice(currentLevel.Difficulty, hintPosition);

            DataAccess.Save();

            return player.GoldenCoins;
        }

        public bool OpenHint(string playerID, int levelID, int hintID)
        {
            Level currentLevel = DataAccess.GetLevelByID(levelID);

            OpenHint openHint = new OpenHint
            {
                HintID = hintID,
                PlayerID = playerID
            };

            DataAccess.SaveOpenHint(openHint);

            return true;
        }


        //--------------------------------------------------------------------------------------------------------
        //------------------------------PRIVATE METHODS-----------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        private List<Level> GetSameDifficultyLevels(IEnumerable<Level> incompleteLevels)
        {
            List<Level> output = new List<Level>();

            int levelDifficultyNumVal = 0;

            // runs through all incomplete levels looking for same difficulty levels
            // if no level is available, it increases difficulty by one and searches again


            do
            {
                if (levelDifficultyNumVal == Enum.GetNames(typeof(LevelDifficulty)).Length)
                {
                    break;
                }

                output = incompleteLevels.Where(x => x.Difficulty == (LevelDifficulty)levelDifficultyNumVal).ToList();
                levelDifficultyNumVal++;

            } while (output.Count == 0);

            return output;
        }

        private List<Level> GetAllIncompleteLevels(IEnumerable<CompleteLevel> completeLevels)
        {
            List<Level> allLevels = DataAccess.GetAllLevels();

            List<Level> output = new List<Level>();

            foreach (var level in allLevels)
            {
                CompleteLevel completeLevel = completeLevels.SingleOrDefault(x => x.LevelID == level.ID);

                if (completeLevel == null)
                {
                    output.Add(level);
                }
            }

            return output;
        }

        private string UpdateSecret(string answer, string secret, char key, out bool isGuessCorrect)
        {
            StringBuilder builder = new StringBuilder(secret);

            isGuessCorrect = false;

            // if letter guessed is correct hidden answer gets updated with that letter
            // only single letter gets captured
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == key && builder[i] != key)
                {
                    builder[i] = key;
                    isGuessCorrect = true;
                    break;
                }

                if (answer[i] == char.ToLower(key) && builder[i] != char.ToLower(key))
                {
                    builder[i] = char.ToLower(key);
                    isGuessCorrect = true;
                    break;
                }
            }

            return builder.ToString();
        }

        //--------------------------------------------------------------------------------------------------------
        //------------------------------STATIC METHODS-----------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------

        public static string GetGameProgress(int completeLevels)
        {
            DataAccess dataAccess = new DataAccess();

            int totalNumOfLevels = dataAccess.GetAllLevels().Count;

            return $"{completeLevels + 1} of {totalNumOfLevels}";
        }
    }
}