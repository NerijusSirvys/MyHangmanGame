using MyHangman.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyHangman.ViewModels
{
    public class GameVM
    {
        public int LevelID { get; set; }
        public string Riddle { get; set; }
        public string OpenAnswer { get; set; }
        public string HiddenAnswer { get; set; }
        public List<HintVM> Hints { get; set; }

        [Display(Name = "Game Score")]
        public int GameScore { get; set; }

        [Display(Name = "Golden Coins")]
        public int GoldenCoins { get; set; }

        [Display(Name = "Level Difficulty")]
        public LevelDifficulty LevelDifficulty { get; set; }

        public string Progress { get; set; }
        public int FailedGuesses { get; set; }
        public int CorrectGuesses { get; set; }

        public bool IsWin
        {
            get
            {
                if (OpenAnswer != null)
                {
                    return CorrectGuesses == OpenAnswer.Length;
                }

                return false;
            }
        }

        public bool IsLoss { get { return FailedGuesses == 6; } }


        public static string HideAnswer(int lenghtOfHiddenAnswer)
        {
            StringBuilder builder = new StringBuilder();

            return builder.Append('_', lenghtOfHiddenAnswer).ToString();
        }
    }
}