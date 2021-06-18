namespace OrderManagement.RulesEngine.Models
{
    public class PhysicalProduct : OrderItem
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public override ItemType Type { get => ItemType.PhysicalProduct; }
    }
}
