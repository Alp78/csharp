// Lambda Expressions: 
// anonymous function - no access modifiers, name, and return statement
// used for convenience (less code and more readable)
// args => expression

using System;

namespace Advanced
{

    class Program
    {


        static void Main(string[] args)
        {
            // instead of creating a function "square" we use delegate Func and a lambda expression
            Func<int, int> square = number => number * number;

            Console.WriteLine(square(5));
            Console.ReadKey();

        }
    }
}