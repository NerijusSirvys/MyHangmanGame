using MyHangman.Enums;
using MyHangman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.Services
{
    public static class HintManager
    {
        private const double baseHintCost = 1.3;

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

            if(openHint == null)
            {
                return false;
            }

            return true;
        }

        public static int PayForHint(int goldenCoins, LevelDifficulty difficulty, int hintPosition)
        {
            int output = goldenCoins - CalculatePrice(difficulty, hintPosition);

            return output;
        }
    }
}