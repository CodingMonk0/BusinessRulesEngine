using OrderManagement.RulesEngine.OrderHandlers;
using System.Collections.Generic;

namespace OrderManagement.RulesEngine
{
    public class RuleRepository : IRuleRepository
    {
        private static readonly Dictionary<string, IOrderHandler> orderHandlers = new Dictionary<string, IOrderHandler>
        {
            { "PhysicalProduct", new PhysicalProductOrderHandler() },
            { "Book", new BookOrderHandler() },
            { "Membership", new MembershipOrderHandler(new MembershipManager(), new EmailService()) }, // Should be handled with DI
            { "MembershipUpgrade", new MembershipUpgradeOrderHandler(new MembershipManager(), new EmailService()) }, // Should be handled with DI
            { "Video", new VideoOrderHandler() }
        };

        public IOrderHandler GetRule(string key)
        {
            if (orderHandlers.ContainsKey(key))
            {
                return orderHandlers[key];
            }

            return null;
        }
    }
}
