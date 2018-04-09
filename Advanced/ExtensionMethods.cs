// Extension Methods
// allows to add methods to a class without:
// - changing its source code
// - creating a new class that inherits from it


using System;

namespace Advanced
{
    // Extending the sealed String class
    public static class StringExtension
    {
        public static string Shorten(this String str, int number)
        {
            return $"{str.Substring(0, number)} [...]";
        }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            string post = "This is supposed to be a very long blog post that needs to be shorten.";

            // calling Shorten as a String instance method
            var shorten = post.Shorten(12);

            Console.WriteLine(shorten);
            Console.ReadKey();
        }
    }
}
