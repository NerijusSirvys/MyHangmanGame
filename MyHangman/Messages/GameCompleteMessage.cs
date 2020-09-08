using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHangman.Messages
{
    public class GameCompleteMessage : IMessage
    {
        public GameCompleteMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}