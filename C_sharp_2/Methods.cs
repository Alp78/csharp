/*
- Method signature
- Method Overloading
- Params modifier
- Ref modifier
- Out modifier
*/

/*
Method Signature:
- name of the method
- number and type of its paramaeters

Overloading:
- method with same name but different signatures
- each overload of the moethod has different parameters

params: modifier keyword to use with a varying number of parameters
--> public int Add(params int[] numbers);

ref: modifier keyword to use when referencing a value type in the method (pointer) 
so the original value is used instead of a local copy in the method

out: similar ro ref, but return a value to the caller

*/

using System;
using System.Collections.Generic;

namespace Methods
{

    public class Calculator
    {
        // method that take indifinte numbers and returns an integer --> params
        public int Add(params int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        // LINQ = Language Integrated Query
    }

    // Point class with 2 integers
    public class Point
    {
        public int x;
        public int y;

        // Constructor to initialize the fields
        public Point (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Move method for Point type
        public void Move(int x, int y){
            this.x = x;
            this.y = y;
        }

        // overload the method
        public void Move(Point newLocation){

            // setting up condition to avoid NonReference Exception
            // --> defensive programming (improves robusteness of the code)
            // --> avoids invalid states of the program
            if (newLocation == null)
                throw new ArgumentNullException("newLocation");

            // calling the first contructor to avoid repeating the assignments
            Move(newLocation.x, newLocation.y);
        }

    }

    


    class Program
    {
        static void UsePoints(){
             // testing the null exception with exception handling mechanism TryCatch
            try
            {
            var testpoint = new Point(0, 0);
            Console.WriteLine("X: {0} Y: {1}", testpoint.x, testpoint.y);
            // following instruction will fail
            testpoint.Move(null);
            }
            // if an exception is thrown, then execute this code
            catch (Exception)
            {
                Console.WriteLine("Cannot take Null arguments.");
            }

            // New Point isntance
            var point = new Point(10, 20);
            Console.WriteLine("X: {0} Y: {1}", point.x, point.y);

            // affecting new values with the contructor taking 2 args
            point.Move(30, 60);
            Console.WriteLine("X: {0} Y: {1}", point.x, point.y);

             // affecting new values with the contructor taking a Point object
            var newLocation = new Point(100, 140);
            point.Move(newLocation);
            Console.WriteLine("X: {0} Y: {1}", point.x, point.y);
        }

        static void UseParams()
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(10, 20, 30));
        }

        static void ParseTry()
        {
            int number;
            // TryParse returns a boolean type: true if parse succeeded
            var result = int.TryParse("123", out number);
            if (result)
                Console.WriteLine(number);
            else
                Console.WriteLine("Conversion failed.");
        }

        static void Main(string[] args)
        {
           UsePoints();
           UseParams();
           ParseTry();
        }
    }
}

