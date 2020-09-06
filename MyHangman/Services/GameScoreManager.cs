using MyHangman.Enums;

namespace MyHangman.Services
{
    public static class GameScoreManager
    {
        private const int BaseScoreForLetter = 5;
        private const int BaseScoreForLevel = 20;

        private const int BasePenaltyForLetter = 2; // TODO review this
        private const int BasePenaltyForLevel = 8;  // TODO review this

        public static int AddScoreForCorrectLetterGuess(LevelDifficulty levelDifficulty)
        {
            return BaseScoreForLetter * (int)levelDifficulty;
        }

        public static int AddScoreForCompletedLevel(LevelDifficulty levelDifficulty)
        {
            return BaseScoreForLevel * (int)levelDifficulty;
        }

        public static int SubtractScoreForFailedLetterGuess(LevelDifficulty levelDifficulty)
        {
            int output = BasePenaltyForLetter * (int)levelDifficulty;

            return output > 0 ? output : 0;
        }

        public static int SubtractScoreForFailedLevel(LevelDifficulty levelDifficulty)
        {
            int output = BasePenaltyForLevel * (int)levelDifficulty;

            return output > 0 ? output : 0;
        }
    }
}