using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Startup.RegisterServices();
            var orderProcessor = serviceProvider.GetService<IOrderProcessor>();
            var orders = Startup.CreateTestData();
            orderProcessor.Process(orders);
        }
    }
}
