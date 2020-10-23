using ExtensionMethods;
using System;

namespace FlexyBoxSuperSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FlexyBox SuperSearcher");
            Console.Write("Please enter the name you want to search for and press 'enter': ");
            //var consoleInput = Console.ReadLine();
            var consoleInput = "Hej verden 2020 @§";
            Console.WriteLine("You typed in: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(consoleInput);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            PrintStatistics(consoleInput);
        }

        private static void PrintStatistics(string input)
        {
            Console.WriteLine("Statistics for the input string:");
            Console.WriteLine("- Length: " + input.Length);
            Console.WriteLine("- Amount of words: " + input.WordCount());
            Console.WriteLine("- Amount of letters: " + input.LetterCount());
            Console.WriteLine("- Amount of numbers: " + input.NumberCount());
            Console.WriteLine("- Amount of symbols: " + input.SymbolCount());
            Console.WriteLine("- Following characters is represented:");
            
            foreach(var kv in input.CharaterRepresentation())
            {
                Console.WriteLine("- - " + kv.Key + " is represented " + kv.Value + " times.");
            }

        }
    }
}
