/*
Constructor inheritance: base
- ctor are not inherited
- use "base" method to call the base ctor in the derived class
- base class ctors are executed first during instantiation
*/

using System;
using System.Collections.Generic;

namespace ConstructorInheritence {
    public class Vehicle {
        // default constructor
        public Vehicle () {
            Console.WriteLine ("Initialization of Vehicle.");
        }

        private readonly string _registrationNumber;

        // ctor with 1 param
        public Vehicle (string registrationNumber) {
            _registrationNumber = registrationNumber;
            Console.WriteLine ("Initialization of Vehicle with {0}", registrationNumber);

        }
    }

    public class Car : Vehicle {
        // constructor using private variable in parent: use "base" method
        public Car (string registrationNumber)
             // base calls for the contructor of the parent class that also take 1 string arg
            : base(registrationNumber)       
        {
            // this instruction will be executed after the parent code fior the same constructor
            Console.WriteLine ("Initialization of Car with {0}", registrationNumber);
        }
    }

    class Program {
        static void Main (string[] args) {
            var car = new Car ("xxxxx");
        }
    }
}