using FlexyBoxSuperSearcher.ExtensionMethods;
using FlexyBoxSuperSearcher.FileFolderSearcher;
using FlexyBoxSuperSearcher.InternetSearcher;
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
            var consoleInput = "odense";
            Console.WriteLine("You typed in: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(consoleInput);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Start searching folders
            //PrintFilesAndFolders(consoleInput, 3);
            PrintInternetResults(consoleInput);
            // Start seatching internet

            //PrintStatistics(consoleInput);

            // Print result from folders or print waiting
            // Print result from internet or print waiting
            System.Console.WriteLine("Press any key to stop");
            Console.ReadKey();
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
                Console.Write("- - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(kv.Key);
                Console.ResetColor();
                Console.WriteLine(" is represented " + kv.Value + " times.");
            }

            Console.WriteLine();
        }

        private static void PrintFilesAndFolders(string input, int maxResultsToShow)
        {
            Console.WriteLine($"Searching for files and folders containing '{input}'.");

            var fileFolderSearcherDao = new FileFolderSearcherImpl();
            var fileFolderObjects = fileFolderSearcherDao.FileFolderSearcher(input);
            var actualMax = maxResultsToShow > fileFolderObjects.Count ? fileFolderObjects.Count : maxResultsToShow;

            Console.WriteLine("- Total items found: " + fileFolderObjects.Count);
            var print = actualMax > 1 ? "Showing the first " + maxResultsToShow + ":" : "There are no items to show";
            Console.WriteLine("- " + print);

            for (int i = 0; i < actualMax; i++)
            {
                Console.WriteLine("- Item " + (i + 1) + ": " + fileFolderObjects[i].FileInfo.FullName);
            }

            Console.WriteLine();
        }

        private static void PrintInternetResults(string input)
        {
            Console.WriteLine($"Searching for weather containing '{input}'.");

            var internetSearcherDao = new InternetSearcherImpl();
            var internetSearchResult = internetSearcherDao.InternetSearcher(input);

            Console.WriteLine($"- In {internetSearchResult.PlaceName}");
            Console.WriteLine($"- it is {internetSearchResult.Weather}.");
            Console.WriteLine($"- The temperature is {internetSearchResult.TemperatureCelcius}° cel.");
            Console.WriteLine($"- and the windspeed is {internetSearchResult.WindspeedMS} Ms.");
            
            Console.WriteLine();
        }
    }
}
