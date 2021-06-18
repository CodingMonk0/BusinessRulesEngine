namespace OrderManagement.RulesEngine.Models
{
    public class Video : OrderItem
    {
        public string Category { get; set; }
        public string Language { get; set; }
        public int Size { get; set; }
        public override ItemType Type { get => ItemType.Video; }
    }
}
