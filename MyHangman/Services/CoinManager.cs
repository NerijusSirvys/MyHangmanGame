using MyHangman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.Services
{
    public static class CoinManager
    {
        private const double BaseCoinReward = 0.5;

        public static int AddCoins(LevelDifficulty levelDifficulty)
        {
            return (int)(BaseCoinReward * (int)levelDifficulty);
        }
    }
}