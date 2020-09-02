using MyHangman.Enums;
using MyHangman.Models;
using MyHangman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHangman.Services
{
    public static class GameEngine
    {
        // value is 6 due to number of hangman pictures to be replaced untill game over
        public static int NumberOfAvailableGuesses { get { return 6; } }

        public static void AddWinToPlayer(string playerID, int levelID)
        {
            DataAccess dataAccess = new DataAccess();

            Player player = dataAccess.GetPlayerByID(playerID);
            player.CompleteLevels.Add(new CompleteLevel { LevelID = levelID });

            dataAccess.Save();
        }

        public static string CalculateGameProgress(Player player)
        {
            DataAccess dataAccess = new DataAccess();

            int completedLevels = player.CompleteLevels.Count;
            int totalNumOfLevels = dataAccess.GetNumberOfLevels();

            return $"{completedLevels + 1} of {totalNumOfLevels}";
        }

        public static bool CheckForLoss(int numberOfGuessesLeft)
        {
            return numberOfGuessesLeft == 0;
        }

        public static bool CheckForWin(int numberOfCorrectGuesses, int numOfLettersToGuess)
        {
            return numberOfCorrectGuesses == numOfLettersToGuess;
        }

        public static Level GetLevelByDifficulty(LevelDifficulty levelDifficulty)
        {
            DataAccess dataAccess = new DataAccess();

            return dataAccess.GetGameLevelByDifficulty(levelDifficulty);
        }

        public static Level GetLevelByID(int levelID)
        {
            DataAccess dataAccess = new DataAccess();

            return dataAccess.GetLevelByID(levelID);
        }

        public static Player GetPlayer(String playerID)
        {
            DataAccess dataAccess = new DataAccess();

            return dataAccess.GetPlayerByID(playerID);
        }

        public static Level GetRandomLevel(IEnumerable<int> levelSetIDs, IEnumerable<CompleteLevel> completeLevels)
        {
            Random random = new Random();

            // .Any() returns true if collection have any members
            if (!levelSetIDs.Any())
            {
                levelSetIDs = LoadLevelSet(completeLevels);
            }

            int index = random.Next(0, levelSetIDs.Count() - 1);

            int levelID = levelSetIDs.ElementAtOrDefault(index);

            Level level = GetLevelByID(levelID);

            return level;
        }

        public static string HideAnswer(int length)
        {
            StringBuilder builder = new StringBuilder();

            return builder.Append('?', length).ToString();
        }

        // Load set of available levels that player have not completed yet with same difficulty starting from lowest
        public static IEnumerable<int> LoadLevelSet(IEnumerable<CompleteLevel> completeLevels)
        {
            IEnumerable<Level> incompleteLevels = GetAllIncompleteLevels(completeLevels);

            IEnumerable<int> requiredLevels = GetSameDifficultyLevelIDs(incompleteLevels);

            return requiredLevels;
        }

        public static string ProcessLetterGuess(char key, string hiddenAnswer, string openAnswer, out bool isGuessCorrect)
        {
            StringBuilder builder = new StringBuilder(hiddenAnswer);

            isGuessCorrect = false;

            for (int i = 0; i < openAnswer.Length; i++)
            {
                if (openAnswer[i] == key && builder[i] != key)
                {
                    builder[i] = key;
                    isGuessCorrect = true;
                    break;
                }

                if (openAnswer[i] == char.ToLower(key) && builder[i] != char.ToLower(key))
                {
                    builder[i] = char.ToLower(key);
                    isGuessCorrect = true;
                    break;
                }
            }

            return builder.ToString();
        }

        public static int UpdateCorrectGuessCount(bool isGuessCorrect, int currentNumberOfGuesses)
        {
            if (isGuessCorrect)
            {
                // this adds one correct guess to total
                currentNumberOfGuesses++;
            }
            return currentNumberOfGuesses;
        }

        public static int UpdateFailedGuessCount(bool isGuessCorrect, int numberOfGuessesLeft)
        {
            if (!isGuessCorrect)
            {
                // this adds one correct guess to total
                numberOfGuessesLeft--;
            }

            return numberOfGuessesLeft;
        }

        public static int UpdatePlayerGameScore(string playerID, LevelDifficulty levelDifficulty, bool isGuessCorrect, bool isWin, bool isLoss)
        {
            DataAccess dataAccess = new DataAccess();
            Player player = dataAccess.GetPlayerByID(playerID);

            if (isGuessCorrect)
            {
                player.GameScore = GameScoreManager.AddScoreForCorrectLetterGuess(levelDifficulty, player.GameScore);
            }

            if (!isGuessCorrect)
            {
                player.GameScore = GameScoreManager.SubtractScoreForFailedLetterGuess(levelDifficulty, player.GameScore);
            }

            if (isWin)
            {
                player.GameScore = GameScoreManager.AddScoreForCompletedLevel(levelDifficulty, player.GameScore);
            }

            if (isLoss)
            {
                player.GameScore = GameScoreManager.SubtractScoreForFailedLevel(levelDifficulty, player.GameScore);
            }

            dataAccess.Save();

            return player.GameScore;
        }

        // returns all levels that players have not completed yet
        private static IEnumerable<Level> GetAllIncompleteLevels(IEnumerable<CompleteLevel> completeLevels)
        {
            DataAccess dataAccess = new DataAccess();
            List<Level> allLevels = dataAccess.GetAllLevels();
            List<Level> incompleteLevels = new List<Level>();

            foreach (var level in allLevels)
            {
                CompleteLevel completeLevel = completeLevels.SingleOrDefault(x => x.LevelID == level.ID);

                if (completeLevel == null)
                {
                    incompleteLevels.Add(level);
                }
            }

            return incompleteLevels;
        }

        // returns ID's of all incomplete levels that have required difficulty level
        private static IEnumerable<int> GetSameDifficultyLevelIDs(IEnumerable<Level> incompleteLevels)
        {
            List<int> requiredLevels = new List<int>();

            IEnumerable<Level> sameDifficultyLevels = new List<Level>();

            int levelDifficultyNumVal = 0;

            // .Any() returns true if collection have any members
            // runs through all incomplete levels looking for same difficulty levels
            // if no level is available, it increases difficulty by one and searches again
            while (!sameDifficultyLevels.Any())
            {
                sameDifficultyLevels = incompleteLevels.Where(x => x.Difficulty == (LevelDifficulty)levelDifficultyNumVal).ToList();
                levelDifficultyNumVal++;
            }

            foreach (var item in sameDifficultyLevels)
            {
                requiredLevels.Add(item.ID);
            }

            return requiredLevels;
        }


        // TODO redo this after db update
        public static bool OpenHint(string playerID, int levelID, int hintID)
        {
            DataAccess dataAccess = new DataAccess();

            Level currentLevel = dataAccess.GetLevelByID(levelID);

            OpenHint openHint = new OpenHint();
            
            openHint.HintID = hintID;
            openHint.PlayerID = playerID;

            dataAccess.AddOpenHint(openHint);

            return true;

        }

        public static int BuyHint(string playerID, int levelID, int hintPosition)
        {
            DataAccess dataAccess = new DataAccess();

            Level currentLevel = dataAccess.GetLevelByID(levelID);

            Player player = dataAccess.GetPlayerByID(playerID);
            player.GoldenCoins = HintManager.PayForHint(player.GoldenCoins, currentLevel.Difficulty, hintPosition);

            dataAccess.Save();

            return player.GoldenCoins;
        }
    }
}