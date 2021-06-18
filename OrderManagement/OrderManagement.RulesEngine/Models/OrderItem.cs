using System;

namespace OrderManagement.RulesEngine.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ItemType Type { get; }
        public string Description { get; set; }
        public double Mrp { get; set; }
        public double SellingPrice { get; set; }
    }
}
