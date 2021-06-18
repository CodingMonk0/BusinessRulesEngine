namespace OrderManagement.RulesEngine
{
    public interface IRuleRepository
    {
        IOrderHandler GetRule(string key);
    }
}
