using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.DTO
{
    public class LeaderBoardEntryDTO
    {
        public string PlayerName { get; set; }
        public int GameScore { get; set; }
        public int LevelsCompleted { get; set; }
    }
}