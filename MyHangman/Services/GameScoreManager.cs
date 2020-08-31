using MyHangman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace MyHangman.Services
{
    public static class GameScoreManager
    {
        private const int BaseScoreForLetter = 5;
        private const int BaseScoreForLevel = 20;

        private const int BasePenaltyForLetter = 2; // TODO review this
        private const int BasePenaltyForLevel = 8;  // TODO review this

        public static int AddScoreForCorrectLetterGuess(LevelDifficulty levelDifficulty, int currentScore)
        {
            return currentScore + (BaseScoreForLetter * (int)levelDifficulty);
        }

        public static int AddScoreForCompletedLevel(LevelDifficulty levelDifficulty, int currentScore)
        {
            return currentScore + (BaseScoreForLevel * (int)levelDifficulty);
        }

        public static int SubtractScoreForFailedLetterGuess(LevelDifficulty levelDifficulty, int currentScore)
        {
            int output = currentScore - (BasePenaltyForLetter * (int)levelDifficulty);

            return output > 0 ? output : 0;
        }

        public static int SubtractScoreForFailedLevel(LevelDifficulty levelDifficulty, int currentScore)
        {
            int output = currentScore - (BasePenaltyForLevel * (int)levelDifficulty);

            return output > 0 ? output : 0;
        }
    }
}