namespace MyHangman.Messages
{
    public class GameMessage : IMessage
    {
        public string Message { get; set; }
        public bool IsWin { get; set; }
        public bool IsLoss { get; set; }
    }
}