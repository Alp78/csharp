/*
Interface:
language construct that is similar to a class (in term of syntax) but is fundamentally different
--> define the capability that a class should provide
--> build loosely-coupled applications

Unit testing: isolating a class with an interface to test it -> not possiblwe with concrete dependency
--> extract an interface from an existing class
*/

using System;

namespace Interfaces
{
    public class Shipment
    {
        public DateTime ShippingDate { get; set; }
        public float Cost { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime DatePlaced { get; set; }
        public Shipment Shipment { get; set; }
        public float TotalPrice { get; set; }

        public bool IsShipped
        {
            get { return Shipment != null; }
        }
    }

    // extraction of interface from CalculateShipping
    public interface IShippingCalculator
    {
        float CalculateShipping(Order order);

    }

    // ShippingCalculator implements IShippingCalculator
    public class ShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            // 10% cost of shipping if amount is below 30, otherwise free (0)
            if (order.TotalPrice < 30f)
                return order.TotalPrice * 0.1f;

            return 0;
        }
    }


    public class OrderProcessor
    {
        // declare an interface (rather that an instance of class)
        // -> loose dependency (abstract instead of concrete)
        private readonly IShippingCalculator _shippingCalculator;

        // passing the interface as argument
        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            if (order.IsShipped)
                throw new InvalidOperationException("This order is already processed.");

            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculator());
            var order = new Order { DatePlaced = DateTime.Now, TotalPrice = 20f };
            orderProcessor.Process(order);
            Console.WriteLine("Cost {0}", order.Shipment.Cost);
            Console.ReadKey();
        }
    }
}