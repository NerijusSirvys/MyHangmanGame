using MyHangman.Enums;
using System.Collections.Generic;

namespace MyHangman.DTO
{
    public class LevelDTO
    {
        public int LevelID { get; set; }
        public string Riddle { get; set; }
        public string Secret { get; set; }
        public LevelDifficulty Difficulty { get; set; }
        public List<HintDTO> Hints { get; set; }
    }
}