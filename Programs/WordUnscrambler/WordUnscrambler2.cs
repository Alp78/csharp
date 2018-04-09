using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WordsUnscrambler2
{
    public class FileReader
    {
        public string[] Read(string wordListFile)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(wordListFile);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return fileContent;
        }
    }

    public class WordMatcher
    {
        public List<MatchWord> Match(string[] scrambleWords, string[] wordList)
        {
            var matchedWords = new List<MatchWord>();

            foreach (var scrambledWord in scrambleWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchWord(scrambledWord, word));
                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchWord BuildMatchWord(string scrambledWord, string word)
        {
            MatchWord matchWord = new MatchWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchWord;
        }
    }

    public struct MatchWord
    {
        public string ScrambledWord { get; set; }
        public string Word { get; set; }
    }


    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFile = @"C:\Users\i344559\Desktop\wordList.txt";

        static void Main(string[] args)
        {
            bool continuePlay = true;
            do
            {
                Console.Write("Enter an option: F for File or M for Manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter file name: ");
                        UnscrambleFile();
                        break;
                    case "M":
                        Console.Write("Enter words manually: ");
                        UnscrambleManual();
                        break;
                    default:
                        Console.Write("Wrong input");
                        break;
                }

                var continueUnscramble = string.Empty;
                do
                {
                    Console.Write("Do you want to continue? (Y/N) ");
                    continueUnscramble = Console.ReadLine() ?? string.Empty;

                } while (!continueUnscramble.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueUnscramble.Equals("N", StringComparison.OrdinalIgnoreCase));
                continuePlay = continueUnscramble.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continuePlay);
        }

        private static void UnscrambleManual()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = manualInput.Split(',');
            DisplayUnscrambleWords(scrambleWords);
        }

        private static void UnscrambleFile()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = _fileReader.Read(fileName);
            DisplayUnscrambleWords(scrambleWords);
        }

        private static void DisplayUnscrambleWords(string[] scrambleWords)
        {
            string[] wordList = _fileReader.Read(wordListFile);

            List<MatchWord> matchWords = _wordMatcher.Match(scrambleWords, wordList);

            if (matchWords.Any())
            {
                foreach (var word in matchWords)
                {
                    Console.WriteLine($"Match found for {word.ScrambledWord} : {word.Word}");
                }
            }
            else
            {
                Console.WriteLine("No matches have been found.");
            }

            
        }
    }
}
