using OrderManagement.RulesEngine.Models;

namespace OrderManagement.RulesEngine
{
    public interface IRulesEngine
    {
        void ExecuteRule(Order order);
    }
}
