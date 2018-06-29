/*
Single Responsibility: a class takes care of only one responsibility (set of methods functionnaly related) 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace DesignPatterns
{
    // Single responsibility: Journal class only handles the content of the journal
    public class Journal
    {
        // a list must be initialized to avoid NuLLReferenceException
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        // Add an entry
        public int AddEntry(string text)
        {
            // $: Interpolated Strings
            // an interpolated string expression creates a string by replacing the contained expressions 
            // with the ToString representations of the expressions' results
            entries.Add($"{++count}: {text}");

            return count;
        }

        // remove an entry
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        // override Object.ToString()
        public override string ToString()
        {
            // Environment.newline : gets the newline string defined for this environment
            return string.Join(Environment.NewLine, entries);
        }
    }

    // Single responsibility: instead of embedding the persistence (or any other paradigm) methods to the class
    // create a separate class handling them
    public class Persistence
    {

        public static void Save(Journal j, string filename, bool overwrite = false)
        {
            // if overwrite is trues or the journal doesn't exist with this filename
            if (overwrite || !File.Exists(filename))
            {
                // creates a file and writes the content
                File.WriteAllText(filename, j.ToString());
            }
          
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("Today it rains.");
            journal.AddEntry("Today is sunny.");

            // ToString() is implicit, no need to append it
            Console.WriteLine(journal);
            Persistence.Save(journal, "testJournal.txt", false);

            // Process.Start: Starts a process resource and associates it with a Process component
            // in this case it will open the text file at runtime
            Process.Start("testJournal.txt");
            Console.ReadKey();
        }
    }
}
