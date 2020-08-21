using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MyHangman.Models
{
    public class Player : IdentityUser
    {
        public int GameScore { get; set; }
        public int GoldenCoins { get; set; }
        public List<CompleteLevel> CompleteLevels { get; set; }

        public Player()
        {
            GameScore = 0;
            GoldenCoins = 0;
        }
    }
}