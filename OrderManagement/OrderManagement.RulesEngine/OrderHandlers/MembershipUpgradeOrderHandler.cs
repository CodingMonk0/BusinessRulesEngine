using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine.OrderHandlers
{
    public class MembershipUpgradeOrderHandler : IOrderHandler
    {
        private readonly IMembershipManager membershipManager;
        private readonly IEmailService emailService;

        public MembershipUpgradeOrderHandler(IMembershipManager membershipManager, IEmailService emailService)
        {
            this.membershipManager = membershipManager;
            this.emailService = emailService;
        }
        public void Handle(OrderItem order)
        {
            if (order is MembershipUpgrade membership)
            {
                membershipManager.Upgrade(membership);
                emailService.Send(membership.Username, "Your membership has been upgraded to premium.");
            }
            else
            {
                throw new Exception("Invalid item type.");
            }
        }
    }
}
