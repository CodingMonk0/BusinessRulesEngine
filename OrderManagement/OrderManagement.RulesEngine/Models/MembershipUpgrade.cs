using System;
namespace OrderManagement.RulesEngine.Models
{
    public class MembershipUpgrade : OrderItem
    {
        public string Username { get; set; }
        public MembershipTier NewTier { get; set; }
        public override ItemType Type { get => ItemType.MembershipUpgrade; }
    }
}
