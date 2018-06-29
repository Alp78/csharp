using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

namespace GERT_v1._1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ConsoleV consoleV = new ConsoleV(args);
            string date, currency;
            List<string> stringList = consoleV.run(out currency, out date);

            if (stringList == null)
            {
                Console.WriteLine("Error.");
            }
            else
            {
                if (!Directory.Exists("./output/"))
                    Directory.CreateDirectory("./output/");

                string outputFilename = "currency_" + currency.ToUpper() + "_" + date;
                                                    

                using (TextWriter console = Console.Out)
                {
                    using (TextWriter textWriter = new StreamWriter($"./output/{outputFilename}.txt", false))
                    {
                        foreach (string str in stringList)
                        {
                            textWriter.WriteLine(str);
                            console.WriteLine(str);
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Done! The rates file has been created in the application output directory. Press any key to terminate the program.");
                Console.ReadKey();
            }
        }
    }
}