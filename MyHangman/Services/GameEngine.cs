using MyHangman.Enums;
using MyHangman.Models;
using System;
using System.Text;

namespace MyHangman.Services
{
    public static class GameEngine
    {
        // value is 7 due to number of hangman pictures to be replaced untill game over
        public static int NumberOfAvailableGuesses { get { return 7; } }

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

        public static Player GetPlayer(String playerID)
        {
            DataAccess dataAccess = new DataAccess();

            return dataAccess.GetPlayerByID(playerID);
        }

        public static string HideAnswer(int length)
        {
            StringBuilder builder = new StringBuilder();

            return builder.Append('?', length).ToString();
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
    }
}