using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    // operators class featuring a list of all supported operators
    public static class Operators
    {
        public static List<char> Operator = new List<char>() {'+', '-', '/', '*'};
    }

    // Validator interface
    public interface IValidator
    {
        bool ValidateEntry(string input);
    }

    // double validator
    public class DoubleValidator : IValidator
    {
        public bool ValidateEntry(string input)
        {
            // true if conversion succesfull
            return double.TryParse(input, out var number);
        }
    }


    // operation validator
    public class OperationValidator : IValidator
    {
        public bool ValidateEntry(string input)
        {
            if (!(string.IsNullOrWhiteSpace(input)) && (input.Length == 1) && (Operators.Operator.Contains(input[0])))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class InputConverter
    {
        private double _convertedInput;
        private DoubleValidator doubleValidator;
        public bool isConverted = false;
       

        public InputConverter()
        {
            doubleValidator = new DoubleValidator();
        }

        public double ConvertInputToNumeric(string input)
        {
            _convertedInput = 0;
            
            //_convertedInput = Convert.ToDouble(input);

            // parse input to Double and store it in _convertedInput, if it fails, throw exception
            // if (!double.TryParse(input, out _convertedInput)) throw new ArgumentException("The input cannot be converted to Double");


            if (doubleValidator.ValidateEntry(input))
            {
                _convertedInput = Convert.ToDouble(input);
                isConverted = true;
            }
            else
            {
                isConverted = false;
                _convertedInput = 0;
            }
            
            return _convertedInput;
        }

    }

    class CalculatorEngine
    {
        private OperationValidator _operationValidator;

        // ctor for variable init
        public CalculatorEngine()
        {
            _operationValidator = new OperationValidator();
        }

        public double Calculate(string operation, double first, double second)
        {
            if (_operationValidator.ValidateEntry(operation))
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
                }
                return 0;
            } else { return 0; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // dev tech: write first what you need (placeholders), define class later 
            InputConverter inputConverter = new InputConverter();
            CalculatorEngine calculatorEngine = new CalculatorEngine();

            Console.Write("Enter the first number: ");
            double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

            if (!inputConverter.isConverted)
            {
                Console.WriteLine("Invalid number! Press any key to exit the program.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.Write("Enter the second number: ");
            double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());

            if (!inputConverter.isConverted)
            {
                Console.WriteLine("Invalid number! Press any key to exit the program.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.Write("Enter the operator (+ - / *): ");
            string operation = Console.ReadLine();

            var operatorValidator = new OperationValidator();

            if (operatorValidator.ValidateEntry(operation))
            {
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(result);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"The operator {operation} is invalid! Press any key to exit the program.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
