using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interfaces.Test
{
    // TestClass for Interfaces class

    [TestClass]
    public class OrderProcessorTest
    {
        // [UnitOfWork_StateUnderTest_ExpectedBehavior]
        // case the order is already shipped
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsAlreadyShipped_ThrowsAnException()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());

            // creating an instance of Order witha Shipment (not null)
            var order = new Order
            {
                Shipment = new Shipment()
            };

            orderProcessor.Process(order);
        }

        // case the order is mot yet shipped
        [TestMethod]
        public void Process_OrderIsNotShipped_ShouldSetTheShipmentPropertyOfTheOrder()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            // empty order -> shipment is null
            var order = new Order();

            orderProcessor.Process(order);

            Assert.IsTrue(order.IsShipped);
            Assert.AreEqual(1, order.Shipment.Cost);
            Assert.AreEqual(DateTime.Today.AddDays(1), order.Shipment.ShippingDate);
        }

    }

    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 1;
        }
    }
}