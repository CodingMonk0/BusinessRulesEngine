using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.RulesEngine.Models;
using System;

namespace OrderManagement.RulesEngine.Test
{
    [TestClass]
    public class RulesEngineTest
    {
        [TestMethod]
        public void ExecuteRule_WithBookTypeOrder_ExecuteOrderHandlerOnce()
        {
            // Arrange
            var type = ItemType.Book.ToString();
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Item = new Book
                {
                    Id = Guid.NewGuid(),
                    Name = "The Alchemist",
                    Author = "Paulo Coelho"
                }
            };

            // Mock IOrderHandler
            var orderHandlerMock = new Mock<IOrderHandler>();
            orderHandlerMock.Setup(o => o.Handle(order.Item)).Verifiable();

            // Mock IRuleRepository
            var rulesRepositoryMock = new Mock<IRuleRepository>();
            rulesRepositoryMock.Setup(o => o.GetRule(type)).Returns(orderHandlerMock.Object);
           
            // Act
            var ruleEngine = new RulesEngine(rulesRepositoryMock.Object);
            ruleEngine.ExecuteRule(order);
            
            // Assert
            orderHandlerMock.Verify(o => o.Handle(order.Item), Times.Once);
        }

        [TestMethod]
        public void ExecuteRule_WithInvalidTypeOrder_ThrowsInvalidOperationException()
        {
            // Arrange
            var type = ItemType.Book.ToString();
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Item = new Music
                {
                    Id = Guid.NewGuid(),
                    Name = "Paranoid Android"
                }
            };

            // Mock IOrderHandler
            var orderHandlerMock = new Mock<IOrderHandler>();
            orderHandlerMock.Setup(o => o.Handle(order.Item)).Verifiable();

            // Mock IRuleRepository
            var rulesRepositoryMock = new Mock<IRuleRepository>();
            rulesRepositoryMock.Setup(o => o.GetRule(type)).Returns(orderHandlerMock.Object);

            // Act & Assert
            var ruleEngine = new RulesEngine(rulesRepositoryMock.Object);
            
            Assert.ThrowsException<InvalidOperationException>(() => ruleEngine.ExecuteRule(order));
        }

        private class Music : OrderItem
        { 
        }
    }
}
