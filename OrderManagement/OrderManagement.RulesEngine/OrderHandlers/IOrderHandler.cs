using OrderManagement.RulesEngine.Models;

namespace OrderManagement.RulesEngine
{
    public interface IOrderHandler
    {
        void Handle(OrderItem order);
    }
}
