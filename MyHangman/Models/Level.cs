using MyHangman.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor.Editor;

namespace MyHangman.Models
{
    public class Level
    {
        public int ID { get; set; }
        public string Riddle { get; set; }
        public string Answer { get; set; }
        public LevelDifficulty Difficulty { get; set; }
        public List<Hint> Hints { get; set; }
        public List<OpenHint> OpenHints { get; set; }
    }
}