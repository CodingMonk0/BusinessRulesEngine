using System;

namespace OrderManagement.RulesEngine
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string body)
        {
            Console.WriteLine($"Successfully sent email to {to}.");
        }
    }
}
