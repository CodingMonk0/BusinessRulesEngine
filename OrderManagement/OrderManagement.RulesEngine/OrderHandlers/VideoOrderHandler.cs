using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine
{
    public class VideoOrderHandler : IOrderHandler
    {
        public void Handle(OrderItem order)
        {
            if (order is Video video)
            {
                if(video.Name.Equals("Learning to Ski", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Added a free \"First Aid\" video to the packing slip.");
                }
                else
                {
                    Console.WriteLine($"Processed video {video.Name}");
                }
            }
            else
            {
                throw new Exception("Invalid item type.");
            }
        }
    }
}
