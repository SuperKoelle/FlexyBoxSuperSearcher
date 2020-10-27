using FlexyBoxSuperSearcher.ExtensionMethods;
using FlexyBoxSuperSearcher.FileFolderSearcher;
using FlexyBoxSuperSearcher.WeatherSearcher;
using System;

namespace FlexyBoxSuperSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FlexyBox SuperSearcher");

            var consoleInput = GetInput();

            while (consoleInput.Length < 2)
            {
                Console.WriteLine("You have to type in at least two characters.");
                consoleInput = GetInput();
            }

            Console.Write("You typed in: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(consoleInput);
            Console.ResetColor();
            Console.WriteLine();

            PrintStatistics(consoleInput);
            PrintWeatherResults(consoleInput);
            PrintFilesAndFolders(consoleInput, 3);

            System.Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }

        /// <summary>
        /// Get the input from the console.
        /// </summary>
        /// <returns>The input from the console.</returns>
        private static string GetInput()
        {
            Console.Write("Please enter the name you want to search for and press 'enter': ");
            var consoleInput = Console.ReadLine();
            return consoleInput;
        }

        /// <summary>
        /// Prints statistics for the input. Available statistics are: length, amount of words, amount of letters, 
        /// amount of numbers, amount of symbols and representation of characters.
        /// </summary>
        /// <param name="input">Input to get statistics for</param>
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
                Console.WriteLine($" is represented {kv.Value} times.");
            }

            Console.WriteLine();
        }
        
        /// <summary>
        /// Prints names of files and folders found on the computer where the name contains. 
        /// the input query. The search starts in the root of the partition running the applications 
        /// and traverses recusivly through sub folders. Folders and files inaccessible due to security
        /// restrictions are not included in the search.
        /// </summary>
        /// <param name="input">Search query</param>
        /// <param name="maxResultsToShow">Maximum results to print.</param>
        private static void PrintFilesAndFolders(string input, int maxResultsToShow)
        {
            Console.WriteLine($"Searching for files and folders containing '{input}'.");

            var fileFolderSearcherDao = new FileFolderSearcherImpl();
            var fileFolderObjects = fileFolderSearcherDao.FileFolderSearcher(input);
            var actualMax = maxResultsToShow > fileFolderObjects.Count ? fileFolderObjects.Count : maxResultsToShow;

            Console.WriteLine($"- Total items found: " + fileFolderObjects.Count);
            var print = actualMax > 0 ? $"Showing the first {actualMax} files or folders:" : "There are no items to show";
            Console.WriteLine("- " + print);

            for (int i = 0; i < actualMax; i++)
            {
                Console.WriteLine($"- Item {(i + 1)}: " + fileFolderObjects[i].FileInfo.FullName);
            }

            Console.WriteLine();
        }
        
        /// <summary>
        /// Prints the weather for the city in search query if a city with name is found.
        /// </summary>
        /// <param name="input">The name of the city to get the weather for.</param>
        private static void PrintWeatherResults(string input)
        {
            Console.WriteLine($"Searching for weather containing '{input}'.");

            var weatherSearcherDao = new WeatherSearcherImpl();
            var weatherSearchResult = weatherSearcherDao.WeatherSearcher(input);
            if (weatherSearchResult.Message.Length == 0)
            {
                Console.WriteLine($"- In {weatherSearchResult.PlaceName}");
                Console.WriteLine($"- it is {weatherSearchResult.Weather}.");
                Console.WriteLine($"- The temperature is {weatherSearchResult.TemperatureCelcius}° cel.");
                Console.WriteLine($"- and the windspeed is {weatherSearchResult.WindspeedMS} Ms.");
            }
            else
            {
                Console.WriteLine("- No cities found with that name.");
            }
            
            Console.WriteLine();
        }
    }
}
