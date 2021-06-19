using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.RulesEngine.Models;
using System;
using System.Collections.Generic;

namespace OrderManagement.RulesEngine.Test
{
    [TestClass]
    public class OrderProcessorTest
    {
        [TestMethod]
        public void Process_SupportedItemTypes_HandlerExecutedForAll()
        {
            // Arrange
            var orders = new List<Order>
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
                } 
            };

            // Mock IRuleEngine
            var ruleEngineMock = new Mock<IRulesEngine>();
            ruleEngineMock.Setup(o => o.ExecuteRule(It.IsAny<Order>())).Verifiable();

            // Act
            var orderProcessor = new OrderProcessor(ruleEngineMock.Object);
            orderProcessor.Process(orders);

            // Assert
            ruleEngineMock.Verify(o => o.ExecuteRule(It.IsAny<Order>()), Times.Exactly(orders.Count));
        }
    }
}
