using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    /* Enums (Enumerations) */

    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }

    /* classes are defined at the namespace level */

    public class Person
    {
        public int Age;
    }

    class Program
    {
        /* Methods are declared in Program */
        public static void Increment(int number)
        {
            number += 10;
        }

        public static void MakeOld(Person person)
        {
            person.Age += 10;
        }

        public class Person
        {
            public Person(string argFirstName, string argLastName)
            {
                FirstName = argFirstName;
                LastName = argLastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        // const implicitly static but need to be initialized
        public const string consText = "consText";
        // readonly need to be explicitly declared as static
        // but doesn't need to be initialized -> can be done at runtime
        public static readonly string readonlyText = "readonlyText";

        // method taking ref int as argument -> value type act as ref type
        static void ChangeNumber(ref int a)
        {
            a = 90;
        }

        // method taking out int as argument -> value type act as ref type
        static void ChangeNumber(out int b)
        {
            a = 90;
        }

        static void Main(string[] args)
        {

            // declare a dynamic type
            dynamic name = "Vincent";
            // assign a value of another type
            name = 10;

            Console.WriteLine(name);

            // Read-Write operations with System.IO
            string[] lines = { "This is the first line", "This is the SECOND line", "This is the third line"};
            
            //File.WriteAllLines: creates a file if it doesn't exist and write the string array content.
            // if the file exists, it is overwritten
            File.WriteAllLines(@"C:\Users\i344559\Desktop\MyTextFile.txt", lines);

            //File.ReadAllLines: retreives all lines from the file and save them in a string array
            string[] fileContent = File.ReadAllLines(@"C:\Users\i344559\Desktop\MyTextFile.txt");

            foreach (var item in fileContent)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();            

            // 'ref' keyword: conversion of value type to reference type
            // use only with a mtehod taking 'ref' type as argument
            // passing a pointer to stack, not the actual value on stack
            // variable MUST be initialized to a value
            int a = 10;
            ChangeNumber(ref a);
            Console.WriteLine(a);
            Console.ReadKey();

            // 'out' does the same as ref but without need of initialization
            int b;
            ChangeNumber(out b);
            Console.WriteLine(b);
            Console.ReadKey();            

            // const type is implicitly static
            Console.WriteLine(consText);

            // the type has to be declared as static explicitly
            Console.WriteLine(readonlyText);
            Console.ReadKey();

            // Null Coalescing '??'
            // initializing an instance of Person with null
            Person nullPerson = null;

            // will throw a NullRef Exception at runtime
            // Console.WriteLine(nullPerson.FirstName);

            // initializing an instance of Person with null coalesc -> '??'
            // checks if it's null, if yes, then assign values
            // if no, then return existing values back
            nullPerson = nullPerson ?? new Person("Default", "Person");
            Console.WriteLine(nullPerson.FirstName);



            // Inline declaration of list and array
            int[] intArray = {1,2,3,4,5,6};

            List<int> intList = new List<int>() {1,2,3,4,5,6};

            // Check if a string is empty
            string sInput;

            do
            {
                sInput = Console.ReadLine();
            } while (!sInput.Equals(string.Empty));


            // Get the the type of an exception with GetType()
            try
            {
                string newText = "Here is some text.".Substring(8, 1000);
            }
            catch (Exception ex)
            {
                // type of exception
                Console.WriteLine(ex.GetType());
                // message of the exception (Message is a property of Exception class)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Code executed after exception handling, whether or not there was an exception.");
            }

            // create an empty string with string.Empty -> cleaner than = ""
            string emptyString = string.Empty;
            System.Console.WriteLine(emptyString);

            
            // string comparisons
            string text1 = "Here is some text";
            string text2 = "Here is some TEXT";

            // String.Equals() returns true or false
            bool isEqual = text1.Equals(text2);

            // StringComparison specify how the expression should be evaluated
            // OrdinalIgnoreCase ignores case difference
            bool isEqual2 = text1.Equals(text2, StringComparison.OrdinalIgnoreCase);

            Console.WriteLine(isEqual);
            Console.WriteLine(isEqual2);

            // convert a string to integer
            string input = Console.ReadLine();
            int convertedInput;
            // TryParse returns 0 (false) in case string could not be converted
            // if input is 0, we need to know if it's an error or the input
            if (int.TryParse(input, out convertedInput))
            {
                int.TryParse(input, out convertedInput);
                Console.WriteLine(convertedInput);
            } else
            {
                Console.WriteLine("Input NaN.");
            }

            /* declare the values directly after within a container */
            var numbers = new int[3] {1, 2, 3};
            int i = 0;
            for (i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            /* join method of the string class, using a separator as first argument */
            string list = string.Join(" | ", numbers);
            Console.WriteLine(list);

            /* Escape characters in a string:
             \n     New Line
             \t     Tab
             \\     Backslash
             \'     Single Quotation Mark
             \"     Double Quotation Mark
             */

            /* Verbatim Strings: use @ in front of a string to avoid special character */
            string path = @"c:\projects\project1\folder1";

            Console.WriteLine(path);

            /* Format String */
            var firstName = "Alfred";
            var lastName = "Dupont";

            var fullName = string.Format("My name is {0} {1}", firstName, lastName);
            System.Console.WriteLine(fullName);

            /* Enum: datatype - set of name/value pairs (constants)
             -> to be used when an umber of related  constant must be grouped 
             Enums can then be expressed as Integeres or their corresponding string*/

            /* casting the enum label as Integer */
            var method = ShippingMethod.Express;
            Console.WriteLine((int) method);

            /* casting an integer as enum label */
            var methodId = 3;
            Console.WriteLine((ShippingMethod) methodId);

            /* cast the enum label as string */
            Console.WriteLine(method.ToString());

            /* parsing the string into an enum */
            var methodName = "Express";
            var shippingMethod = (ShippingMethod) Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine(shippingMethod);

            /* Types are either Classes or Structures
             - Primitive types: structures (int, char, float, bool) -> Value Types
             - Non Primitive types: classes (arrays, strings) -> Reference Types
             
            Value types (structures): part of memory is allocated and removed on/from stack automatically
            Reference types (classes): need to allocate the memory on heap (stays longer) -> garbage collection by CLR
             */

            var a6 = 10;
            var b6 = a6;
            b6++;
            Console.WriteLine("a6: {0}, b6: {1}", a6, b6);
            /* a6 = 10 -> only value is copied, not variable itself b6 (value type)*/

            var array1 = new int[3] {1, 2, 3};
            var array2 = array1;
            array2[0] = 0;
            Console.WriteLine(array1[0]);
            Console.WriteLine(array2[0]);
            /* array1[0] is 0 because  arrays is a reference type: the variable array is created on the stack as an adress referring to a location on the heap.
             Any variable copied as these, will result of a synchronised content (as they share the same reference on the heap) */

            var number = 1;
            Increment(number);
            Console.WriteLine(number);
            /* number is not affected by the increment method, because it's a value type,
             and both "number" scopes are respectively the main class, and the Increment method */

            var person = new Person() {Age = 20};
            MakeOld(person);
            Console.WriteLine(person.Age);
            /* person is affected by the MakeOld method as it is a reference type,
             both "person" variable point to the same reference of the class on the heap*/

            /* Array = represents a fixed number of variables of a particular type */
            /* 2 types of arrays: single and multiple dimension (matrix) */
            /* 2 types of multidimensional arrays: Rectangular and Jagged */

            /* declare a 2-dimensional array with its object initialization syntax*/
            var matrix1 = new int[3, 5] /* 3 rows of each 5 columns */
            {
                {1, 2, 3, 4, 5},
                {5, 7, 8, 9, 10},
                {11, 12, 13, 14, 15}
            };
            /* finding the length of an array */
            Console.WriteLine("The Length of matrix1 is : " + matrix1.Length);

            /* IndexOf() method: find the position of an element in an array (only for single array) */
            var singleArray1 = new int[10] {12, 2, 3, 4, 22, 45, 13, 0, 91, 100};
            var element1 = new int();
            element1 = 4;
            var index1 = Array.IndexOf(singleArray1, element1);
            Console.WriteLine("Index of element {0} in singleArray1 is : {1}", element1, index1);

            // Clear() method: set elements to 0 - 1st param is start index of the clearing, second is the length of the series

            Array.Clear(singleArray1, 0, 3);
            Console.WriteLine("Effect of Clear(): ");
            foreach (var n in singleArray1)
                Console.WriteLine(n);

            // Copy() method - 1st param: source array, 2nd: destination, 3rd: number of elements to copy
            var singleArray2 = new int[3];
            Array.Copy(singleArray1, singleArray2, 3);
            Console.WriteLine("Effect of Copy() : ");
            foreach (var n in singleArray2)
            {
                Console.WriteLine(n);
            }

            // Sort() method
            Array.Sort(singleArray1);
            Console.WriteLine("Effect of Sort() : ");
            foreach (var n in singleArray1)
            {
                Console.WriteLine(n);
            }

            //Reverse() method
            Array.Reverse(singleArray1);
            Console.WriteLine("Effect of Reverse() : ");
            foreach (var n in singleArray1)
            {
                Console.WriteLine(n);
            }

            /* declare a jagged array */
            /* first declare top level array with number of elements (rows) leaving the column empty*/
            var jaggedArray = new int[3][];
            /* second initialize each element of this array to a different array */
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[2];

            /*Arrays have fixed sizes, when you need to work with extensible collection, a List is the way */
            // List: dynamic size

            var list1 = new List<int>() {1, 2, 3, 4, 5};
            /*Useful List methods:
             Add() AddRange() Remove() RemoveAt() IndexOf() Contains() Count*/

            //Add an element to the list
            list1.Add(1);
            Console.WriteLine("Effect of Add(): ");
            foreach (var n in list1)
            {
                Console.WriteLine(n);
            }

            // AddRange() - IEnumerable -> can use array or list to add elements
            list1.AddRange(new int[3] {6, 7, 8});
            Console.WriteLine("Effect of AddRange(): ");
            foreach (var n in list1)
            {
                Console.WriteLine(n);
            }

            //IndexOf() returns the first index of the value
            Console.WriteLine("Index of 1: " + list1.IndexOf(1));
            //LastIndexOf() returns the last element in the list that has this value
            Console.WriteLine("Last Index of 1: " + list1.LastIndexOf(1));

            //Count
            Console.WriteLine("Count list1 :" + list1.Count);

            //Remove() - remove the first element in the list with this value

            list1.Remove(1);
            Console.WriteLine("Effect of Remove(): ");
            foreach (var n in list1)
            {
                Console.WriteLine(n);
            }

            //Remove all elements with a certain value (1 here)

            for (int j = 0; j < list1.Count; j++)
            {
                if (list1[j] == 1)
                    list1.Remove(list1[j]);
            }

            Console.WriteLine("Effect of Remove with iteration: ");
            foreach (var n in list1)
            {
                Console.WriteLine(n);
            }

            //Clear() removes all elements of the list

            list1.Clear();
            Console.WriteLine("Count list1 after Clear:" + list1.Count);


            // Date and Time

            var dateTime = new DateTime(2018, 1, 16);
            var now = DateTime.Now;
            var today = DateTime.Today;

            Console.WriteLine("Today: " + today);
            Console.WriteLine("Hour now: " + now.Hour);
            Console.WriteLine("Minute now: " + now.Minute);

            // can add time to a datetime

            var tomorrow = now.AddDays(1);
            var yesterday = now.AddDays(-1);

            Console.WriteLine("Tomorrow: " + tomorrow);
            Console.WriteLine("Yesterday: " + yesterday);

            // Convert to string

            Console.WriteLine("ToLongDateString: " + now.ToLongDateString());
            Console.WriteLine("ToShortDateString: " + now.ToShortDateString());
            Console.WriteLine("ToLongTimeString: " + now.ToLongTimeString());
            Console.WriteLine("ToShortTimeString: " + now.ToShortTimeString());
            Console.WriteLine("ToString: " + now.ToString());

            // Format specifier
            Console.WriteLine("ToString with Format specifier: " + now.ToString("dd-MM-yyyy HH:mm"));

            // Time span: constructor has multiple overloads

            var timeSpan = new TimeSpan(1, 2, 3);
            Console.WriteLine("TimeSpan(1,2,3): " + timeSpan);

            // using static methods of the Timespan structure (more readable)

            var timeSpan2 = TimeSpan.FromHours(1);
            Console.WriteLine("TimeSpan.FromHours(1): " + timeSpan2);

            // Calculate a TimeSpan from DateTime

            var start = DateTime.Now;
            var end = DateTime.Now.AddHours(2);
            var duration = end - start;
            Console.WriteLine("Duration: " + duration);

            // Properties of TimeSpan

            Console.WriteLine("Minutes: " + timeSpan.Minutes); // Returns only the minutes
            Console.WriteLine("Total Minutes: " + timeSpan.TotalMinutes); // Returns the total time expressed in minutes


            // Add 
            Console.WriteLine("Add Example: " + timeSpan.Add(TimeSpan.FromMinutes(8)));
            Console.WriteLine("Subtract Example: " + timeSpan.Subtract(TimeSpan.FromMinutes(8)));

            // ToString (greyed out: by defaut CW calls this method on any object we pass through
            Console.WriteLine("ToString: " + timeSpan.ToString());

            // Parse (converts a String into TimeSpan)
            Console.WriteLine("Parse: " + TimeSpan.Parse("01:02:03"));

            //String

            var myName = "Alfred Dupont ";

            //Trim: remove extar end and start spaces
            Console.WriteLine("Trim: '{0}'", myName.Trim());

            //ToUpper
            Console.WriteLine("ToUpper: '{0}'", myName.Trim().ToUpper());

            //separate words: method with IndexOf and Substring
            var sIndex = myName.IndexOf(' ');
            var fName = myName.Substring(0, sIndex);
            var lName = myName.Substring(sIndex + 1);

            Console.WriteLine("First Name with Substring and IndexOf: " + fName);
            Console.WriteLine("Last Name with Substring and IndexOf: " + lName);

            //separate words: split method
            var names = myName.Split(' ');

            Console.WriteLine("First Name with Split: " + names[0]);
            Console.WriteLine("Last Name with Split: " + names[1]);

            //Replace method
            var cName = myName.Replace("Alfred", "Alex");
            Console.WriteLine("Effect of Replace(): " + cName);

            //Validation if empty or white space
            if (String.IsNullOrWhiteSpace(" "))
                Console.WriteLine("Invalid");

            //Conversion
            var str = "25";
            var age = Convert.ToByte(str);
            Console.WriteLine("Age converted into Byte: " + age);

            //conversion of float into string formatted in currency
            float price = 29.95f;
            var sPrice = price.ToString("C");
            Console.WriteLine("String converted into String and formatted into Currency: " + sPrice);


            //Summarizing text (calling a method)
            var sentence =
                "This is a long text full of unuseful words that you absolutely want to summarize.";
            var summary = SummarizeText(sentence, 25);
            Console.WriteLine(summary);

            //StringBuilder (modify string faster than maniuplation of strings directly)
            // --> mutable string of string chars
            // string methods will not work on builders, eg. IndeOf.
            // builder needs to be converted into string first --> builder.ToString().IndexOf('X')

            var builder = new StringBuilder();
            // methods can be chained instead of distinct declarations for cleaner code
            builder.Append('-', 10)
            .AppendLine()
            .Append("Header")
            .Append('-', 10);

            // replace a character with another
            builder.Replace('-', '+');

            // remove some characters (from.. length...)
            builder.Remove(0, 10);

            // insert (start index, anything)
            builder.Insert(0, new string('-', 10));

            Console.WriteLine("Effect of StringBuilder: " + builder);

            Console.WriteLine("First char of the StringBuilder: " + builder[0]);
            

        }
        //creation of a method for summarizing

        static string SummarizeText(string sentence, int maxLength = 20)
        {
            var summaryWords = new List<string>();
            if (sentence.Length < maxLength)
            {
                return sentence;
            }
            else
            {
                var words = sentence.Split(' ');
                var totalChar = 0;

                foreach (var word in words)
                {
                    summaryWords.Add(word);
                    totalChar += word.Length + 1;
                    if (totalChar > maxLength)
                        break;
                }
            }
            return String.Join(" ", summaryWords) + "...";
        }
    }
}