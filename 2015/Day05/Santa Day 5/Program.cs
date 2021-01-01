using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").ToList();
            int niceLines = 0;
            foreach (var line in input)
            {
                if (line.Contains("ab")
                 || line.Contains("cd")
                 || line.Contains("pq")
                 || line.Contains("xy")
                 || CountCharOccurences(line, "aeiou") < 3
                 || !HasDoubleLetter(line))
                    continue;
                niceLines++;
            }
            Console.WriteLine("Nice Lines: {0}", niceLines);
        }
        static int CountCharOccurences(string text, string chars)
        {
            int counter = 0;
            foreach (char c in chars)
            {
                foreach (char textChar in text)
                {
                    if (textChar == c) counter++;
                }
            }
            return counter;
        }
        static bool HasDoubleLetter(string text)
        {
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1]) return true;
            }
            return false;
        }
    }
}
