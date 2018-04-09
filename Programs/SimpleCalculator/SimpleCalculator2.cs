using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    // operators class featuring a list of all supported operators
    public static class Operators
    {
        public static List<char> Operator = new List<char>() { '+', '-', '/', '*' };
    }


    class InputConverter
    {
        private double _convertedInput;
        public bool isConverted = false;


        public InputConverter()
        {
            
        }

        public double ConvertInputToNumeric(string input)
        {
            _convertedInput = 0;

            //_convertedInput = Convert.ToDouble(input);

            // parse input to Double and store it in _convertedInput, if it fails, throw exception
            // if (!double.TryParse(input, out _convertedInput)) throw new ArgumentException("The input cannot be converted to Double");


                if (!Double.TryParse(input, out _convertedInput))
                {
                    throw new ArgumentException("Invalid number!");
                }

            return _convertedInput;
        }

    }

    class CalculatorEngine
    {
        

        // ctor for variable init
        public CalculatorEngine()
        {
            
        }

        public double Calculate(string operation, double first, double second)
        {
                switch (operation)
                {
                    case "+":
                        return first + second;
                    case "-":
                        return first - second;
                    case "*":
                        return first * second;
                    case "/":
                        return first / second;
                    default:
                    throw new ArgumentException("Invalid operator!");
                }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // dev tech: write first what you need (placeholders), define class later 
            InputConverter inputConverter = new InputConverter();
            CalculatorEngine calculatorEngine = new CalculatorEngine();

            try
            {
                Console.Write("Enter the first number: ");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                Console.Write("Enter the second number: ");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

                Console.Write("Enter the operator (+ - / *): ");
                string operation = Console.ReadLine();
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }
            
        }
    }
}
