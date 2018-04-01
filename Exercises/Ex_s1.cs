using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // A) Series 1

            //1 - Write a program and ask the user to enter a number. 
            //    The number should be between 1 to 10. If the user enters a valid number, 
            //    display "Valid" on the console. Otherwise, display "Invalid".
            //    (This logic is used a lot in applications where values 
            //    entered into input boxes need to be validated.)

            /*
            int numIn = new int();

            Console.Write("Enter a integer between 1 and 10 : ");
            numIn = Convert.ToInt32(Console.ReadLine());

            if (numIn >= 1 && numIn <=10)
            {
                Console.WriteLine("The number {0} is between 1 and 10. Good job!", numIn);
            }
            else
            {
                Console.WriteLine("The number {0} is out of range :(", numIn);
            }
            */

            //2 - Write a program which takes two numbers from the console 
            //    and displays the maximum of the two.

            /*
            var numIn1 = new int();
            var numIn2 = new int();

            Console.Write("Enter the first number : ");
            numIn1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number : ");
            numIn2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The bigger number between {0} and {1} is {2}", numIn1, numIn2, Math.Max(numIn1, numIn2));
            */

            //3 - Write a program and ask the user to enter the width and height of an image.
            //    Then tell if the image is landscape or portrait.


            /*
            var height = new decimal();
            var width = new decimal();

            Console.Write("Enter the height : ");
            height = Convert.ToDecimal((Console.ReadLine()));

            Console.Write("Enter the width : ");
            width = Convert.ToDecimal((Console.ReadLine()));

            if (height > width)
            {
                Console.WriteLine("Portrait!");
            }
            else if (width > height)
            {
                Console.WriteLine("Landscape!");
            }
            else
            {
                Console.WriteLine("Square!");
            }
            */

            //4 - Your job is to write a program for a speed camera.
            //    For simplicity, ignore the details such as camera, sensors, etc 
            //    and focus purely on the logic. Write a program that asks the user 
            //    to enter the speed limit. Once set, the program asks for the speed of a car.
            //    If the user enters a value less than the speed limit, 
            //    program should display Ok on the console.
            //    If the value is above the speed limit, the program should calculate 
            //    the number of demerit points. For every 5km / hr above the speed limit, 
            //    1 demerit points should be incurred and displayed on the console.
            //    If the number of demerit points is above 12, the program should display 
            //    License Suspended.

            /*
            var sLimit = new int();
            var sCar = new int();
            var dPoint = new int();

            Console.Write("Enter a speed limit : ");
            sLimit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the car speed : ");
            sCar = Convert.ToInt32(Console.ReadLine());

            dPoint = ((sCar - sLimit) / 5);

            if (sCar <= sLimit)
            {
                Console.WriteLine("You're good to go!");
            }

            else if ((sCar > sLimit) && (dPoint <= 12))
            {

                Console.WriteLine("You have exceed the speed limit by {0}, " +
                                  "you've penalized by {1} demerit points", (sCar - sLimit), dPoint);
            }

            else if ((sCar > sLimit) && (dPoint >= 12))
            {
                Console.WriteLine("You have exceed the speed limit by {0}, " +
                                  "you've penalized by {1} demerit points " +
                    "and have your driver license suspended.", (sCar - sLimit), dPoint);
                */

            // B) Series 2

            /*1- When you post a message on Facebook, depending on the number of people who like your post,
                Facebook displays different information.

                    If no one likes your post, it doesn't display anything.
                    If only one person likes your post, it displays: [Friend's Name] likes your post.
                    If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
                    If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.

                    Write a program and continuously ask the user to enter different names, 
                    until the user presses Enter (without supplying a name). 
                    Depending on the number of names provided, display a message based on the above pattern.*/

            /* 
            var listName = new List<string>{};
            var listCount = new int();

            while (true)
            {
                Console.WriteLine("Enter a name, or press Enter to break: ");
                string fName = Console.ReadLine();
                if (fName == "") {
                    break;
                }
                 else 
                {
                    listName.Add(fName);
                }
            }

            listCount = listName.Count;

            if (listCount == 0)
            {
                Console.WriteLine("You don't have any friends bro :(");
            }
            else if (listCount == 1)
            {
                Console.WriteLine("Your only friend {0} likes your post!", listName[0]);
            }
            else if (listCount == 2)
            {
                Console.WriteLine("Your friends {0} and {1} like your post!", listName[0], listName[1]);
            }
            else
            {
                var extraFriends = new int();
                extraFriends = listCount - 2;
                Console.WriteLine(" Your friends {0} and {1} + {2} others like your post!", listName[0], listName[1], extraFriends);
            }
            */


            /* 2- Write a program and ask the user to enter their name.
             Use an array to reverse the name and then store the result in a new string. 
             Display the reversed name on the console. */

            /*

            Console.Write("Enter a name: ");
            string fName = Console.ReadLine();
            char[] nArray = new char[fName.Length];
            for (int i = 0; i < fName.Length; i++)
            {
                nArray[i] = fName[i];
            }

            Array.Reverse(nArray);
            string rName = new string(nArray);
            Console.WriteLine("The reverse of {0} is {1}.", fName, rName);
            */

            /* 3- Write a program and ask the user to enter 5 numbers.
             If a number has been previously entered, display an error message and ask the user to re-try. 
             Once the user successfully enters 5 unique numbers, sort them and display the result on the console. */

            /*
            var nArray = new int[5];
            var fNumber = new int();

            Console.Write("Enter number {0}: ", 1);
            fNumber = Convert.ToInt32(Console.ReadLine());
            nArray[0] = fNumber;
            for (int i = 1; i < nArray.Length; i++)
            {
                Console.Write("Enter number {0}: ", i+1);
                fNumber = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j <= i; j++)
                    {
                        if (nArray[j] == fNumber)
                        {
                            Console.WriteLine("The number {0} has already been input. Retry.", fNumber);
                            i = i - 1;
                            break;
                        }
                        else if (j == i)
                        {
                        nArray[i] = fNumber;
                        }
                    }
            }
            Array.Sort(nArray);
            foreach (var n in nArray)
            {
                Console.WriteLine(n);
            }
            */

            /* 4- Write a program and ask the user to continuously
             enter a number or type "Quit" to exit. 
             The list of numbers may include duplicates. 
             Display the unique numbers that the user has entered. */

            /*
            var fNumber = new int();
            var listNumber = new List<int>{};
            var lastIndex = new int();

            Console.Write("Enter a number or 'Quit' to escape: ");
            while (true)
            {
                string fInput = Console.ReadLine();
                if (fInput == "Quit")
                {
                    break;
                }
                else
                {
                    fNumber = Convert.ToInt32(fInput);
                    listNumber.Add(fNumber);
                }
            }

            for (int i = 0; i < listNumber.Count; i++)
            {
                lastIndex = listNumber.LastIndexOf(listNumber[i]);
                if (lastIndex == i)
                {
                    Console.WriteLine(listNumber[i]);
                }
            }
            */

            /*5- Write a program and ask the user to supply a list of comma separated numbers
             (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers, 
             display "Invalid List" and ask the user to re-try; 
             otherwise, display the 3 smallest numbers in the list. */

            /*
            string fInput;
            var nList = new List<int>{};
            var arrayLength = new int();

            Console.Write("Enter a series of minimum 5 integers comma separated: ");
            fInput = Console.ReadLine();

            string[] sNumbers = fInput.Split(',');
            arrayLength = sNumbers.Length;

            if ((arrayLength < 5) || fInput == "")
            {
                Console.WriteLine("Ivalid list!");
            }
            else
            {
                for (int i = 0; i < arrayLength; i++)
                {
                    nList.Add(Convert.ToInt32(sNumbers[i]));
                }
                for (int i = 0; i < 3; i++)
                {
                    int lowest = nList.Min();
                    Console.WriteLine(lowest);
                    var indexLowest = nList.IndexOf(lowest);
                    nList.Remove(nList[indexLowest]);
                }
            }
            */


            // C) Strings

            /*1- Write a program and ask the user to enter a few numbers separated by a hyphen.
             Work out if the numbers are consecutive.
             For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: 
             "Consecutive"; otherwise, display "Not Consecutive". */

            /*
            string fInput = "";
            var iNumbers = new List<int> { };

            Console.Write("Enter a series of numbers separted by hyphens: ");
            fInput = Console.ReadLine();
            string[] sNumbers = fInput.Split('-');


            foreach (var n in sNumbers)
            {
                iNumbers.Add(Convert.ToInt32(n));
            }

            if ((iNumbers[0] - iNumbers[iNumbers.Count - 1] + 1 == iNumbers.Count) ||
                (iNumbers[iNumbers.Count - 1] - iNumbers[0] + 1 == iNumbers.Count))
            {
                Console.Write("The following series is consecutive YAY!: ");
                foreach (var n in iNumbers)
                {
                    Console.Write(n + " ");
                }
            }
            else
            {
                Console.Write("The following series is not consecutive: ");
                foreach (var n in iNumbers)
                {
                    Console.Write(n + " ");
                }
            }
            */

            /* 2- Write a program and ask the user to enter a few numbers separated by a hyphen.
             If the user simply presses Enter, without supplying an input, exit immediately; 
             otherwise, check to see if there are duplicates. 
             If so, display "Duplicate" on the console. */

            /*
            Console.Write("Enter a series of numbers separated by hyphens, or press Enter to exit: ");

            string fInput = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(fInput))
            {
                Console.WriteLine("Exit");
            }
            else
            {
                string[] sNumbers = fInput.Split('-');
                var iNumbers = new List<int> {};
                var isDuplicate = new bool() == false;

                foreach (var n in sNumbers)
                {
                    iNumbers.Add(Convert.ToInt32(n));
                }

                foreach (var m in iNumbers)
                {
                    if (iNumbers.IndexOf(m) != iNumbers.LastIndexOf(m))
                    {
                        isDuplicate = true;
                        break;
                    }
                    else
                    {
                        isDuplicate = false;
                    }
                }

                var message = isDuplicate ? "The series has duplicates" : "The series is clean";
                Console.WriteLine(message);
            }
            */

            /* 3- Write a program and ask the user to enter a time value in the 24-hour time format
             (e.g. 19:00). A valid time should be between 00:00 and 23:59. 
             If the time is valid, display "Ok"; otherwise, display "Invalid Time". 
             If the user doesn't provide any values, consider it as invalid time. */

            /*
            string dInput;
            var dm24Int = new int[2];
            string[] dm24String;

            Console.Write("Enter a time in 24h HH:mm format: ");
            dInput = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(dInput))
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                try
                {
                    dm24String = dInput.Split(':');

                    foreach (var n in dm24String)
                    {
                        dm24Int[Array.IndexOf(dm24String, n)] = Convert.ToByte(n);
                    }

                    if ((dm24Int[0] >= 0 && dm24Int[0] <= 24) && (dm24Int[1] >= 0 && dm24Int[1] <= 59))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid");
                    return;
                }
            }

            */

            /*4- Write a program and ask the user to enter a few words separated by a space.
             Use the words to create a variable name with PascalCase. 
             For example, if the user types: "number of students", display "NumberOfStudents".
             Make sure that the program is not dependent on the input.
             So, if the user types "NUMBER OF STUDENTS", the program should still display 
             "NumberOfStudents". */

            /*
            string sInput;
            var lString = new List<string> {};

            Console.Write("Enter series of work separated by space: ");

            sInput = Console.ReadLine();

            string[] aString = sInput.Split(' ');

            Console.Write("PascalCase: ");

            foreach (var n in aString)
            {
                string word = aString[Array.IndexOf(aString, n)];
                string firstLetter;
                var builder = new StringBuilder(){};
                word = n.ToLower();
                firstLetter = word[0].ToString();
                firstLetter = firstLetter.ToUpper();
                builder.Append(firstLetter);
                for (int i = 1; i < word.Length; i++)
                {
                    builder.Append(word[i]);
                }

                Console.Write(builder.ToString());
            }

            Console.WriteLine("");
            */


            /* 5- Write a program and ask the user to enter an English word.
             Count the number of vowels (a, e, o, u, i) in the word. 
             So, if the user enters "inadequate", the program should display 6 on the console. */

            /*
            string sInput;
            Console.Write("Enter an English word: ");
            sInput = Console.ReadLine();
            Console.WriteLine("Number of vowels: {0}", VowelsCount(sInput));
            */

            // Working with Files

            /* 1- Write a program that reads a text file and displays the number of words.*/

            /*
            var path = @"C:\Users\i344559\Desktop\static.txt";
            var content = File.ReadAllText(path).Split(' ');
            for (int i = 0; i < content.Length; i++)
            {
                Console.WriteLine(content[i] + " " + (i+1));
            }

            Console.WriteLine(content.Length);
            */

            /* 2- Write a program that reads a text file and displays the longest word in the file. */

            /*
            var path = @"C:\Users\i344559\Desktop\static.txt";
            var content = File.ReadAllText(path).Split(' ');
            string longestWord;
            longestWord = content[0];
            for (int i = 1; i < content.Length; i++)
            {
                if (content[i].Length > longestWord.Length)
                {
                    longestWord = content[i];
                }
            }

            Console.WriteLine("The longest word is: {0}", longestWord);
            */
        }
        /*
        static int VowelsCount(string sInput)
        {
            int vCount = 0;
            for (int i = 0; i < sInput.Length; i++)
            {
                if ((sInput[i] == 'a') || (sInput[i] == 'e') || (sInput[i] == 'o') || (sInput[i] == 'u') || (sInput[i] == 'i'))
                {
                    vCount++;
                }
            }

            return vCount;
        }
        */
    }
}