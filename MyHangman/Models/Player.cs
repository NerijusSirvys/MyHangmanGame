using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.Models
{
    public class Player
    {
        public int GameScore { get; set; }
        public int GoldenCoins { get; set; }
        public List<CompleteLevel> CompleteLevels { get; set; }
    }
}