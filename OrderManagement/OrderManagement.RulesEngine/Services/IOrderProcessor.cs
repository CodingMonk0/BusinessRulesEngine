using OrderManagement.RulesEngine.Models;
using System.Collections.Generic;

namespace OrderManagement.RulesEngine
{
    public interface IOrderProcessor
    {
        void Process(List<Order> orders);
    }
}
