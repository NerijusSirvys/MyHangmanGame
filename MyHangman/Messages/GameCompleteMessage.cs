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