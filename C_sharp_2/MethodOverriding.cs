/*
Method Overriding:
- modifying the implementation of an inherited method
--> fine-tune derived classes
--> use "virtual" keyword to decorate the base class's method
--> use "override" keyword to decorate the derived class method

- design loosely coupled apps
*/

using System;
using System.Collections;
using System.Collections.Generic;


namespace MethodOverriding {


    public class Shape {
        public int Width { get; set; }
        public int Height { get; set; }

        // virtual: Draw() will apply for both Circle and Rectangle, but method implementation will be different for both
        public virtual void Draw(){

        }
    }
    // losely copuple application: creating a new shape Triangle doesn't imply to modify any other class or method elsewhere
    public class Triangle : Shape{
        // override Draw() method
        public override void Draw(){

            Console.WriteLine("Draw a triangle.");

        }
    }

    public class Circle : Shape{
        // override Draw() method
        public override void Draw(){

            Console.WriteLine("Draw a circle.");

        }
    }

    public class Rectangle : Shape{
        // override Draw() method
        public override void Draw(){

            Console.WriteLine("Draw a rectangle.");

        }
    }



    public class Canvas{
        public void DrawShapes(List<Shape> shapes){
            foreach (var shape in shapes)
            {
                // calling the Draw() method of Shape class: due to virtual/override the appropriate overriden method will be used depending if the shape is Rectangle, Circle...
                // --> polymorphism: Draw() will have a different "form" depending on the object used at runtime
                shape.Draw();
            }
        }
    }

    class Program {
        static void Main (string[] args) {
            var shapes = new List<Shape>();
            shapes.Add(new Circle() {Width = 100, Height = 200});
            shapes.Add(new Rectangle() {Width = 30, Height = 40});
            shapes.Add(new Triangle() {Width = 70, Height = 80});

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);

        }
    }
}
