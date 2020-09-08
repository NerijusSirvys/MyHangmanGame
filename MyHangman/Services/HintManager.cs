using MyHangman.Enums;
using MyHangman.Models;

namespace MyHangman.Services
{
    public static class HintManager
    {
        private const double baseHintCost = 4;

        public static int CalculatePrice(LevelDifficulty levelDifficulty, int hintPosition)
        {
            // calculates cost of the hint based on current level difficulty and hint number
            // first out of three hints will be cheapest and third will be most expensive
            // level difficulty adds extra costs as well.
            double output = baseHintCost + ((int)levelDifficulty * hintPosition);

            return (int)output;
        }

        public static bool LookForOpenHint(string playerID, int hintID)
        {
            DataAccess dataAccess = new DataAccess();

            OpenHint openHint = dataAccess.GetOpenHint(playerID, hintID);

            if (openHint == null)
            {
                return false;
            }

            return true;
        }

        public static int SubtractHintPrice(LevelDifficulty difficulty, int hintPosition)
        {
            return CalculatePrice(difficulty, hintPosition);
        }
    }
}