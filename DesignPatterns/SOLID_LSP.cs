/*
Liskov Substitution: a base type should be substituted for its derived types
--> derived class able to upcast to base class without change in the output
--> virtual props in base class + override props in derived class
*/

using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Rectangle
    {
        // declaring properites as virtual: let them be overriden by derived classes
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle (int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }

    }

    // inherit from Rectangle
    public class Square : Rectangle
    {
        // properties override virtual props in base class
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    class Program
    {
        // => : return
        static public int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;

        static void Main(string[] args)
        {
            var rectangle = new Rectangle(5, 4);
            Console.WriteLine($"{rectangle} has area {Area(rectangle)}");

            Console.WriteLine("");

            // Liskov Substitution: Square type is assigned to a Rectangle variable without changing the output
            // the system looks at the base props -> virtual
            // then looks in the v-table and finds the appropriate setter for Square
            Rectangle square = new Square();
            square.Width = 4;
            Console.WriteLine($"{square} has area {Area(square)}");
            Console.WriteLine(square.GetType());

            Console.ReadKey();
        }
    }
}
