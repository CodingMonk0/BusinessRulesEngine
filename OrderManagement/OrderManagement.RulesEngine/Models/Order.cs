using System;

namespace OrderManagement.RulesEngine.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderItem Item { get; set; }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public double ItemAmount { get; set; }
        public double ShippingCost { get; set; }
        public double TotalValue { get; set; }
    }
}
