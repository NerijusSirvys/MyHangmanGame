using MyHangman.Enums;
using System;

namespace MyHangman.Services
{
    public static class CoinManager
    {
        private const double BaseCoinReward = 0.5;

        public static int AddCoins(LevelDifficulty levelDifficulty)
        {
            double coinVal = (double)(BaseCoinReward * (int)levelDifficulty);
            return (int)Math.Ceiling(coinVal);
        }
    }
}