using MyHangman.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHangman.ViewModels
{
    public class GameVM
    {
        public int LevelID { get; set; }
        public string Riddle { get; set; }
        public string OpenAnswer { get; set; }
        public string HiddenAnswer { get; set; }
        public List<HintVM> Hints { get; set; }

        [Display(Name ="Game Score")]
        public int GameScore { get; set; }

        [Display(Name ="Golden Coins")]
        public int GoldenCoins { get; set; }

        [Display(Name ="Level Difficulty")]
        public LevelDifficulty LevelDifficulty { get; set; }
        public string Progress { get; set; }
        public int NumberOfGuessesLeft { get; set; }
        public int NumberOfCorrectGuesses { get; set; }
        public bool IsWin { get; set; }
        public bool IsLoss { get; set; }
    }
}