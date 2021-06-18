using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class BookOrderHandler : IOrderHandler
    {
        public void Handle(OrderItem order)
        {
            if (order is Book)
            {
                Console.WriteLine("Created a duplicate packing slip for the royalty department.");
                Console.WriteLine("Generated a commission payment to the agent.");
            }
            else
            {
                throw new Exception("Invalid item type.");
            }
        }
    }
}
