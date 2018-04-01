/*
Indexer: 
- way to access elements in a class that represents a list of values
--> easier way to access fields in class that have list/dictionary
*/

using System;
using System.Collections.Generic;

namespace Indexer
{
    public class HttpCookie {
        // delcaration of a dictionary in readonly
        private readonly Dictionary <string, string> _dictionary;



        // constructor to initialize an empty dictionary
        public HttpCookie(){
            _dictionary = new Dictionary <string, string>();
        }

        // setting an indexer
        public string this[string key]{
            get{
                return _dictionary[key];
            }
            // value: keyword for the value that is passed as argument
            set{
                _dictionary[key] = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args){

            var cookie = new HttpCookie();
            // using the indexer to affect a value
            // set
            cookie["name"] = "Alex";
            // get
            Console.WriteLine(cookie["name"]);
        }
    }
}