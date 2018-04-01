/*
Upcasting & Downcasting:
- Upcasting: conversion from a derived class to a base class
- Downcasting: conversion from a base class to a derived class
- "as" keyword: allows null instead of error
- "is" keyword: conditionals
*/

using System;
using System.Collections.Generic;

namespace UpcastingDowncasting {

    public class Shape {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(){

        }

    }

    public class Text : Shape{
        public int FontSize { get; set; }
        public int FontName { get; set; }
    }

    class Program {
        static void Main (string[] args) {

            Text text = new Text();
            
            // assigning a derived type to shape object: won't be able to access the Text methods
            // upcasting: convert the derived class reference to its parent class ref -> implicit
            // at compile time shape will be of Shape type, but at runtime it will be Text
            Shape shape = text;

            // both text and shape refer to the same object but have different views on it
            text.Width = 200;
            shape.Width = 500;
            Console.WriteLine(text.Width);
            Console.WriteLine(shape.Width);

            // downcasting: convert the shape object to its derived class Text
            Text shapeConverted = (Text) shape;
            text.FontSize = 14;

            // now the property of the derived class Text is accessible
            Console.WriteLine(shapeConverted.FontSize);

            // the converted object still refers to the same object 
            Console.WriteLine(shapeConverted.Width);

        }
    }
}
