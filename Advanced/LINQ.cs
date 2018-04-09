// LINQ: Language INtegrated Query
// -> query objects, collections, databases (entities), XML, ADO.NET data sets


using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced
{
   
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "aaaaa", Price = 4},
                new Book() {Title = "bbbbb", Price = 6},
                new Book() {Title = "ccccc", Price = 14},
                new Book() {Title = "ddddd", Price = 3},
                new Book() {Title = "eeeee", Price = 54}
            };
        }
    }


    class Program
    {
        

        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // LINQ Extension Methods
            // Where: narrow down the collection (using Linq)
            // OrderBy(): takes a Lambda as argument (using Linq)
            // Select(): narrow down the members to return (here only Title)
            var cheapBooks = books
                            .Where(b => b.Price < 10)
                            .OrderBy(b => b.Title)
                            .Select(b => b.Title);


            // LINQ query operators
            var cheapBooks2 = from b in books
                              where b.Price < 10
                              orderby b.Title
                              select b.Title;

            //  Single() retrieve a single element (using Linq)
            var singleBook = books.Single(b => b.Title == "aaaaa");

            // Skip() skips elements in the collection and Take() indiactes how many to retrieve (using Linq)
            var chosenBooks = books.Skip(2).Take(3);

            // Count() count elements (using Linq)
            var count = books.Count();
            Console.WriteLine($"Count: {count}");

            // Max() and Min() returns the max and min of a collection(using Linq)
            var maxPrice = books.Max(b => b.Price);
            Console.WriteLine($"Max Price: {maxPrice}");

            // Sum() sums elements
            var sum = books.Sum(b => b.Price);
            Console.WriteLine($"Sum: {sum}");


            Console.WriteLine("\n\n");

            foreach (var chosenBook in chosenBooks)
            {
                Console.WriteLine($"{chosenBook.Title} : {chosenBook.Price}");
            }

            Console.WriteLine("\n\n");

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} : {book.Price}");
            }

            Console.WriteLine("\n\n");

            foreach (var cheapBook in cheapBooks)
            {
                Console.WriteLine($"{cheapBook}");
            }

            Console.WriteLine("\n\n");

            Console.WriteLine(singleBook.Title);

            Console.ReadKey();
        }
    }
}
