namespace OrderManagement.RulesEngine.Models
{
    public class Book : OrderItem
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public override ItemType Type { get => ItemType.Book; }
    }
}
