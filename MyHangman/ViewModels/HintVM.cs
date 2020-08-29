namespace MyHangman.ViewModels
{
    public class HintVM
    {
        public int ID { get; set; }
        public string OpenHint { get; set; }
        public string HiddenHint { get { return "Use Golden Coins to open this clue"; } }
        public bool IsOpen { get; set; }
    }
}