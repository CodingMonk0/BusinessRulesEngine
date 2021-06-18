using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class RulesEngine : IRulesEngine
    {
        private readonly IRuleRepository ruleRepository;

        public RulesEngine(IRuleRepository ruleRepository)
        {
            this.ruleRepository = ruleRepository;
        }

        public void ExecuteRule(Order order)
        {
            var handler = ruleRepository.GetRule(order.Item.Type.ToString());
            if(handler == null)
            {
                throw new InvalidOperationException($"Rule {order.Item.Type} not found.");
            }

            handler.Handle(order.Item);
        }
    }
}
