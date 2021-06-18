using OrderManagement.RulesEngine.Models;
using OrderManagement.RulesEngine.OrderHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace OrderManagement.RulesEngine
{
    public class Startup
    {
        public static IServiceProvider RegisterServices()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IRuleRepository, RuleRepository>()
            .AddTransient<IEmailService, EmailService>()
            .AddTransient<IMembershipManager, MembershipManager>()
            .AddTransient<IOrderHandler, BookOrderHandler>()
            .AddTransient<IOrderHandler, MembershipOrderHandler>()
            .AddTransient<IOrderHandler, MembershipUpgradeOrderHandler>()
            .AddTransient<IOrderHandler, PhysicalProductOrderHandler>()
            .AddTransient<IOrderHandler, VideoOrderHandler>()
            .AddTransient<IRulesEngine, RulesEngine>()
            .AddTransient<IOrderProcessor, OrderProcessor>()
            .BuildServiceProvider();

            return serviceProvider;
        }

        public static List<Order> CreateTestData()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Item = new Book
                    {
                        Id = Guid.NewGuid(),
                        Name = "The Alchemist",
                        Author = "Paulo Coelho"
                    }
                } ,
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Item = new Membership
                    {
                        Id = Guid.NewGuid(),
                        Name = "Annual Subscription",
                        Username = "rajnish.maurya16@gmail.com"
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Item = new MembershipUpgrade
                    {
                        Id = Guid.NewGuid(),
                        Name = "Lifetime",
                        Username = "rajnish.maurya16@gmail.com",
                        NewTier = MembershipTier.Lifetime
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Item = new Video
                    {
                        Id = Guid.NewGuid(),
                        Name = "Learning to Ski"
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Item = new PhysicalProduct
                    {
                        Id = Guid.NewGuid(),
                        Name = "Washing Machine"
                    }
                }
            };
        }
    }
}
