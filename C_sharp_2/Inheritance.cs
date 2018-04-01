/*
Coupling = measure of how interconnected classes and subsystems are
- tightly coupled: all classes are interdependent
- loosely coupled: change in a class is isolated

--> encapsulation: access modifiers
--> relationship between classes: inheritance / composition

- inheritance: kink of relationship between two classes that allows one to inherit code from the other - IS relationship
--> code reuse, polymorphic behavior

- composition: kind of relationship between two classes that allows one to contain the other - HAS relationship
*/

using System;
using System.Collections.Generic;

namespace Inheritance
{
    public class PresentationObject{
        public int Width {get; set; }
        public int Height { get; set; }

        public void Copy(){
            Console.WriteLine("Object copied to clipboard.");
        }

        public void Duplicate(){
            Console.WriteLine("Object duplicated.");
        }
    }

    // Text class inherited from PresentationObject
    public class Text : PresentationObject{
        public int FontSize {get; set; }
        public int FontName {get; set; }

        public void AddHyperlink(string url){
            Console.WriteLine("Link added to: {0}", url);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Width = 100;
            // Text instance calls for base class method
            text.Copy();
        }
    }
}