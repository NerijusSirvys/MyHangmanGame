using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHangman.ViewModels
{
    public class LeaderBoardEntryVM
    {
        [Display(Name ="Player Name")]
        public string PlayerName { get; set; }

        [Display(Name ="Score")]
        public int GameScore { get; set; }

        [Display(Name ="Levels Completed")]
        public int LevelsCompleted { get; set; }
    }
}