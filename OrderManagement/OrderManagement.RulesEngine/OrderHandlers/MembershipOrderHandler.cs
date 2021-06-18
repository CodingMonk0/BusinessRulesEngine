using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class MembershipOrderHandler : IOrderHandler
    {
        private readonly IMembershipManager membershipManager;
        private readonly IEmailService emailService;

        public MembershipOrderHandler(IMembershipManager membershipManager, IEmailService emailService)
        {
            this.membershipManager = membershipManager;
            this.emailService = emailService;
        }
        public void Handle(OrderItem order)
        {
            if (order is Membership membership)
            {
                membershipManager.Activate(membership);
                emailService.Send(membership.Username, "Your membership has been activated");
            }
            else
            {
                throw new Exception("Invalid item type.");
            }
        }
    }
}
