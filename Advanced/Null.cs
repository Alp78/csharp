// Nullable Types
// Null Coalescing


using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced
{
   

    class Program
    {
        

        static void Main(string[] args)
        {
            // old way
            Nullable<DateTime> date = null;

            // new way -> is it null? if yes, then assign this value, if no keep the existing value
            DateTime? date2 = new DateTime(2014,1,1);

            // Null Coalescing: is date null? if yes, then assign this value to date3, if no then assign date
            DateTime date3 = date ?? DateTime.Now;
            Console.WriteLine(date3);

            // GetValueOrDefault(): avoids crashing the app if the value is null
            Console.WriteLine($"GetValueOrDefault(): {date2.GetValueOrDefault()}");
            Console.WriteLine($"HasValue: {date2.HasValue}");

            Console.ReadKey();
        }
    }
}
