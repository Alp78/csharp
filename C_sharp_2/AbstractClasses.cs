/*
Abstract Classes:
- class that bears at least 1 abstract member

Abstract Method:
empty method that is only defined in dervied classes -> contraints on derived classes to implement the method by overriding the abstract one

Abstract Modifier: 
indicates that a class or a member is missing implementation
--> the method is not used in base class, intentedly let empty to let the derived classes define it

1) abstract members don't include implementation
2) if a memeber is delcared as abstract, its class must be declared as abstract too
3) abstract classes cannot be instanciated

--> forces to provide an implementation in dervied class (!= virtual method)
--> forces the design to be followed throughout the code base
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace AbstractClasses 
{
    // Shape has an abstract method, so it needs to be absrtact
    // this class cannot be instanciated, but its derived class can
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // declaring an abstract method
        public abstract void Draw();

        public void Copy()
        {
            Console.WriteLine("Copy shape in clipboard.");
        }

        public void Select()
        {
            Console.WriteLine("Select shape.");
        }
    }

    public class Circle : Shape
    {
        // override the abstract Draw() method: mandatory due to abstract
        public override void Draw()
        {
            Console.WriteLine("Draw a Circle.");
        }
    }

    public class Rectangle : Shape
    {
        // override the abstract Draw() method: mandatory due to abstract
        public override void Draw()
        {
            Console.WriteLine("Draw a Rectangle.");
        }
    }

    class Program 
    {
        static void Main (string[] args) 
        {
            var circle = new Circle();
            circle.Draw();

             var rectangle = new Rectangle();
            rectangle.Draw();           
        }
    }
}