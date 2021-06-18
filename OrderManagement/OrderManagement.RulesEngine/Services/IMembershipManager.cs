using OrderManagement.RulesEngine.Models;

namespace OrderManagement.RulesEngine
{
    public interface IMembershipManager
    {
        void Activate(Membership membership);
        void Upgrade(MembershipUpgrade membershipUpgrade);
    }
}
