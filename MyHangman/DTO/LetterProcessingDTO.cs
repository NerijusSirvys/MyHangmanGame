using MyHangman.Enums;

namespace MyHangman.DTO
{
    public class LetterProcessingDTO
    {
        public string PlayerID { get; set; }
        public string Answer { get; set; }
        public string Secret { get; set; }
        public int GoldenCoins { get; set; }
        public int GameScore { get; set; }
        public int CorrectGuesses { get; set; }
        public int FailedGuesses { get; set; }
        public LevelDifficulty LevelDifficulty { get; set; }
    }
}