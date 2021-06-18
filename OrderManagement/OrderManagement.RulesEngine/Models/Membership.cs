namespace OrderManagement.RulesEngine.Models
{
    public class Membership : OrderItem
    {
        public string Username { get; set; }
        public MembershipTier Tier { get; set; }
        public Status Status { get; set; }
        public override ItemType Type { get => ItemType.Membership; }
    }
}
