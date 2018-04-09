using System;

namespace Advanced
{
    // Generic list: can take any value type T, without boxing/unboxing
    public class GenericList <T>
    {
        public void Add(T value)
        {

        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Book
    {
        public string Title;
        public string ISBN;
    }

    public class GenericDictionary <TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    public class Utilities
    {
        // classic way: needs to declare type of arguments
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // generic way: the type is defined with "where" clause (constraint)
        // in this example with an IComparable interface as type
        // but could be a class/struct
        public T Max<T>(T a, T b) where T : IComparable
        {

            return a.CompareTo(b) > 0 ? a : b;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

        }
    }
}
