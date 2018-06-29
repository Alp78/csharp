/*
Open/Closed: any class should be open for extension but closed to modification
--> create interfaces and classes to inject in the existing class instead of modyfying this existing class
*/

using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, XL
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {   
            // if name == null then throw exception, otherwise affect.
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;

        }
    }

    public class ProductFilter
    {
        // filter by size
        // IEnumerable: Exposes an enumerator, which supports a simple iteration over a non-generic collection
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            // retreives all products matching the size passed as argument
            foreach (var product in products)
            {
                if (product.Size == size)
                {
                    // yield return: returns each element one at a time of a IEnumerable
                    // returns a subset (IEnumerable) of products matching the size
                    yield return product;
                }
            }
        }

        // filter by color
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            // retreives all products matching the color passed as argument
            foreach (var product in products)
            {
                if (product.Color == color)
                {
                    // yield return: returns each element one at a time of a IEnumerable
                    // returns a subset (IEnumerable) of products matching the color
                    yield return product;
                }
            }
        }

        // filter by size and color
        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            // retreives all products matching the size and color passed as arguments
            foreach (var product in products)
            {
                if ((product.Color == color) && (product.Size == size))
                {
                    // yield return: returns each element one at a time of a IEnumerable
                    // returns a subset (IEnumerable) of products matching the color
                    yield return product;
                }
            }
        }
    }

    // Open/Closed: instead of updating the ProductFilter class each time we have a new criteria
    // --> create an interface
    // ISpecification implements the Specification Pattern
    // predicate that operates on any type T
    // dictates whether or not a product satisfies a particular criteria
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    // interface defining the Filter method taking a IEnuymerable and ISpecification as arguments 
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    // creating a ColorSpec class implementing the ISpecification interface
    public class ColorSpec : ISpecification<Product>
    {
        private Color color;

        // ctor with Color argument
        public ColorSpec(Color color)
        {
            this.color = color;
        }

        // returns true if the color matches
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    // creating a SizeSpec class implementing the ISpecification interface
    public class SizeSpec : ISpecification<Product>
    {
        private Size size;

        // ctor with Color argument
        public SizeSpec(Size size)
        {
            this.size = size;
        }

        // returns true if the color matches
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    // AndSpecification implements ISpecification interface
    // combines 2 specifications
    public class CombinedSpec<T> : ISpecification<T>
    {
        ISpecification<T> first, second;

        public CombinedSpec(ISpecification<T> first, ISpecification<T> second)
        {
            // if not null then affect
            this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));

        }

        // returns true if both specs are satisifed
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    // BetterFilter class implements the IFilter interface
    // Open/Closed: any new product can be injected in it without modyfying the class
    // which takes a IEnumerable and ISpecification intefaces as arguments
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                // if any item of the list matches the specification
                if (spec.IsSatisfied(item))
                {
                    // returns a IEnumerable of matching items
                    yield return item;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shirt1 = new Product("Cosmic Edge", Color.Blue, Size.Small);
            var shirt2 = new Product("Razor Blade", Color.Red, Size.Medium);
            var shirt3 = new Product("Lonely Wolf", Color.Green, Size.Small);
            var shirt4 = new Product("Sunny Valley", Color.Green, Size.XL);
            var shirt5 = new Product("Tomorrow Land", Color.Red, Size.Large);
            var shirt6 = new Product("Void Attraction", Color.Blue, Size.Large);
            var shirt7 = new Product("Northern light", Color.Green, Size.Large);

            Product[] products = { shirt1, shirt2, shirt3, shirt4, shirt5, shirt6, shirt7};

            var filter = new ProductFilter();

            // going through the IEnumerable of matching products
            foreach (var product in filter.FilterBySize(products, Size.Small))
            {
                Console.WriteLine($"- {product.Name}: {product.Color}, {product.Size}");
            }

            Console.WriteLine("");

            // creating an instance of BetterFilter
            var betterFilter = new BetterFilter();

            // creating a couple of color specifications
            var green = new ColorSpec(Color.Green);
            var blue = new ColorSpec(Color.Blue);

            // outputs each product matching the Green color
            foreach (var product in betterFilter.Filter(products, green))
            {
                Console.WriteLine($"- {product.Name}: {product.Color}, {product.Size}");
            }

            Console.WriteLine("");

            // creating a couple of size specifications
            var small = new SizeSpec(Size.Small);
            var large = new SizeSpec(Size.Large);
            var xl = new SizeSpec(Size.XL);

            // outputs each product matching the Green color
            foreach (var product in betterFilter.Filter(products, large))
            {
                Console.WriteLine($"- {product.Name}: {product.Color}, {product.Size}");
            }


            Console.WriteLine("");

            // creating a couple of combined specifications
            var largeGreen = new CombinedSpec<Product>(large, green);
            var smallBlue = new CombinedSpec<Product>(small, blue);

            // outputs each product matching the Large size and Green color
            foreach (var product in betterFilter.Filter(products, largeGreen))
            {
                Console.WriteLine($"- {product.Name}: {product.Color}, {product.Size}");
            }

            Console.ReadKey();
        }
    }
}
