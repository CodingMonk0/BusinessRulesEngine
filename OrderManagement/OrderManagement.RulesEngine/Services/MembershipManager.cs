using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class MembershipManager : IMembershipManager
    {
        public void Activate(Membership membership)
        {
            membership.Status = Status.Active;
            Console.WriteLine($"Successfully activated membership {membership.Name}");
        }

        public void Upgrade(MembershipUpgrade membershipUpgrade)
        {
            Console.WriteLine($"Successfully upgraded membership {membershipUpgrade.Id} to {membershipUpgrade.NewTier}");
        }
    }
}
