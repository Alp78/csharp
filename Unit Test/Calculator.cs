using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library
{
    // creation of class and method
    public class Calculator
    {
        public static int Divide(int numerator, int denominator)
        {
            int result = numerator / denominator;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a numerator: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a denominator: ");
            int den = Convert.ToInt32(Console.ReadLine());

            int res = Calculator.Divide(num, den);
            Console.WriteLine("The quotient = {0}", res);
        }
    }
}

