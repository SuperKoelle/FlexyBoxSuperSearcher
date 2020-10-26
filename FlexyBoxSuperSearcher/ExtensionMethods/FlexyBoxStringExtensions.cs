using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexyBoxSuperSearcher.ExtensionMethods
{
    /// <summary>
    /// By using extension methods the methods can be use anywhere in the code. Dorethy likes statistics so maybe she wants
    /// same methods to be used in future iterations.
    /// </summary>
    public static class FlexyBoxStringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int LetterCount(this String str)
        {
            return str.Count(char.IsLetter);
        }

        public static int NumberCount(this String str)
        {
           return str.Count(char.IsNumber);
        }
        
        /// <summary>
        /// Using Microsoft definition for symbols: https://docs.microsoft.com/en-us/dotnet/api/system.char.issymbol?view=netcore-3.1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int SymbolCount(this String str)
        {
           return str.Count(char.IsSymbol);
        }

        public static Dictionary<char, int> CharaterRepresentation(this String str)
        {
            var result = new Dictionary<char, int>();

            foreach(char c in str.ToCharArray())
            {
                if (result.ContainsKey(c))
                {
                    result[c]++;
                }
                else
                {
                    result.Add(c,1);
                }
            }

            return result;
        }
    }
}