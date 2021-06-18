namespace OrderManagement.RulesEngine
{
    public interface IEmailService
    {
        void Send(string to, string body);
    }
}
