using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordsUnscrambler
{
    public class Menu
    {
        public string input;
        public Menu()
        {

        }

        public void MenuChoice()
        {
            while (true)
            {
                Console.Write("Enter 'p' to play, or 'm' to maintain the list, or 'e' to exit: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "p":
                        Console.WriteLine("Let's play!\n");
                        var scrambleWords = new ScrambleWords();
                        scrambleWords.Unscramble();
                        continue;
                    case "m":
                        Console.WriteLine("Let's maintain!\n");
                        var fileHandler = new FileHandler();
                        fileHandler.CurrentList();
                        Console.Write("\nEnter 'A' to add a word to the list, 'D' to delete a word, or 'E' to exit: ");
                        switch (Convert.ToChar(Console.ReadLine().ToLower()))
                        {
                            case 'a':
                                fileHandler.AddWord();
                                continue;
                            case 'd':
                                fileHandler.DeleteWord();
                                continue;
                            case 'e':
                                return;
                            default:
                                break;
                        }

                        continue;
                    case "e":
                        Console.WriteLine("Good Bye!");
                        return;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            
            }
        }

    }


    public class FileHandler
    {
        private string path;
        private string word;
        private string tempWords;
        public string[] tempArray;
        private int indexInput;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private List<string> wordsList;

        public FileHandler()
        {
            path = @"C:\Users\i344559\Desktop\words.txt";
            wordsList = new List<string>();
        }

        public void CurrentList()
        {
            streamReader = File.OpenText(path);
            using (streamReader)
            {
                tempWords = streamReader.ReadToEnd();
                tempArray = tempWords.Split(' ');
            }
            // removing the last element of the array (empty element) with Linq
            tempArray = tempArray.Where(w => w != tempArray[tempArray.Length - 1]).ToArray();

            Console.WriteLine("Current list of words: ");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < tempArray.Length; i++)
            {
                Console.WriteLine($" {i + 1} - {tempArray[i]}");
            }
            Console.ResetColor();
        }


        public void DeleteWord()
        {

            Console.Write("\nEnter the index of the word you want to remove: ");
            Console.ForegroundColor = ConsoleColor.Green;
            indexInput = Convert.ToInt16(Console.ReadLine());
            Console.ResetColor();

            Console.Write($"\nYour choice: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(tempArray[indexInput -1]);
            Console.ResetColor();

            Console.Write("\nConfirm deletion? (Y/N) ");
                switch (Convert.ToChar(Console.ReadLine().ToLower()))
                {
                    case 'y' :
                        Console.WriteLine($"The word {tempArray[indexInput - 1]} is deleted from the list.");
                        tempArray = tempArray.Where(w => w != tempArray[indexInput - 1]).ToArray();
                        Console.WriteLine($"\nNew list: \n");

                        // false instructs to override the content rather than append (true)
                        streamWriter = new StreamWriter(path, false);
                        Console.ForegroundColor = ConsoleColor.Green;
                        using (streamWriter)
                        { 
                            for (int i = 0; i < tempArray.Length; i++)
                            {
                                Console.WriteLine($" {i + 1} - {tempArray[i]}");
                                streamWriter.Write($"{tempArray[i]} ");
                            }
                        }
                        Console.ResetColor();
                        return;

                    case 'n':
                        return;
                    default:
                        break;
                }

        }

        public void AddWord()
        {
            if (!File.Exists(path))
            {
                streamWriter = File.CreateText(path);
            }

            streamWriter = new StreamWriter(path, true);
            while (true)
            {
                Console.Write("Enter a word or return to exit: ");
                Console.ForegroundColor = ConsoleColor.Green;
                word = Console.ReadLine();
                Console.ResetColor();
                if (string.IsNullOrWhiteSpace(word))
                {
                    break;
                }
                else
                {
                    wordsList.Add(word);
                }
            }

            using (streamWriter)
            {
                foreach (var w in wordsList)
                {
                    streamWriter.Write($"{w} ");
                }
            }

            CurrentList();

        }

    }

    public class ScrambleWords
    {
        private string scrambledWord;
        private FileHandler fileHandler;
        private List<Char> charList;
        private string[] wordsInList;
        private bool isFound = false;

        public ScrambleWords()
        {
            
            fileHandler = new FileHandler();
            fileHandler.CurrentList();
            wordsInList = fileHandler.tempArray;
        }

        public void Unscramble()
        {
            while (true)
            {
                Console.Write("\nEnter a scrambled word: ");
                Console.ForegroundColor = ConsoleColor.Green;
                scrambledWord = Console.ReadLine();
                Console.ResetColor();

                foreach (var word in wordsInList)
                {
                    charList = new List<Char>();
                    if (word.Length == scrambledWord.Length)
                    {
                        // creating a list with all characters of word
                        foreach (var c in word)
                        {
                            charList.Add(c);
                        }


                        for (int i = 0; i < scrambledWord.Length; i++)
                        {
                            for (int j = 0; j < charList.Count; j++)
                            {
                                if (scrambledWord[i] == charList[j])
                                {
                                    charList.Remove(charList[j]);
                                    break;
                                }
                            }
                        }
                        if (charList.Count == 0)
                        {
                            Console.Write("Word found: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(word);
                            Console.ResetColor();
                            isFound = true;
                            break;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWord not found.");
                    Console.ResetColor();
                }

                Console.Write("\nContinue? Y/N ");
                switch (Convert.ToChar(Console.ReadLine().ToLower()))
                {
                    case 'y':
                        continue;
                    case 'n':
                        return;
                    default:
                        break;
                }
            }
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            try
            {
                menu.MenuChoice();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
