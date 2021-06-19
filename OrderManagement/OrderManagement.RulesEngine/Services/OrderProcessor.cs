using OrderManagement.RulesEngine.Models;
using System;
using System.Collections.Generic;

namespace OrderManagement.RulesEngine
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IRulesEngine rulesEngine;

        public OrderProcessor(IRulesEngine rulesEngine)
        {
            this.rulesEngine = rulesEngine;
        }
        public void Process(List<Order> orders)
        {
            foreach (var order in orders)
            {
                try
                {
                    Console.WriteLine($"Started processing order {order.Id}, type: {order.Item.Type}");
                    rulesEngine.ExecuteRule(order);
                    Console.WriteLine($"Finished processing order {order.Id}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured while executing the rule {order.Item.Type}. Details: {ex.Message}");
                }
            }
        }
    }
}
