using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class PhysicalProductOrderHandler : IOrderHandler
    {
        public void Handle(OrderItem order)
        {
            if (order is PhysicalProduct)
            {
                Console.WriteLine("Generated a packing slip for shipping.");
                Console.WriteLine("Generated a commission payment to the agent.");
            }
            else
            {
                throw new Exception("Invalid item type.");
            }
        }
    }
}
