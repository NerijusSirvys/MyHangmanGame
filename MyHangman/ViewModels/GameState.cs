using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.ViewModels
{
    public class GameState
    {
        public string Message { get; set; }
        public bool IsWin { get; set; }
        public bool IsLoss { get; set; }
    }
}