using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December16
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Single();
            var programs = new string(Enumerable.Range('a', 16).Select(x => (char)x).ToArray());
            var dance = DanceWithMeHoney(input, programs);
            Console.WriteLine(dance);
            Console.WriteLine(DanceWithMeHoneyOnExtacy(input, programs));
        }

        private static string DanceWithMeHoney(string input, string programString)
        {
            var programs = programString.ToCharArray().ToList();
            foreach (var move in input.Split(','))
            {
                switch (move[0])
                {
                    case 's':
                        var spins = int.Parse(move.Substring(1));
                        for (int i = 0; i < spins; i++)
                        {
                            var last = programs.Last();
                            programs.RemoveAt(programs.Count - 1);
                            programs.Insert(0, last);
                        }
                        break;
                    case 'x':
                        var indexes = move.Substring(1).Split('/');
                        var indexA = int.Parse(indexes[0]);
                        var indexB = int.Parse(indexes[1]);
                        var temp = programs[indexA];
                        programs[indexA] = programs[indexB];
                        programs[indexB] = temp;
                        break;
                    case 'p':
                        var partners = move.Substring(1).Split('/');
                        var partnerA = partners[0][0];
                        var partnerB = partners[1][0];
                        int indexOfA = programs.IndexOf(partnerA);
                        int indexOfB = programs.IndexOf(partnerB);
                        var temp2 = programs[indexOfA];
                        programs[indexOfA] = programs[indexOfB];
                        programs[indexOfB] = temp2;
                        break;
                }
            }
            return new string(programs.ToArray());
        }

        private static string DanceWithMeHoneyOnExtacy(string input, string programs)
        {
            List<string> repeats = new List<string>();
            do
            {
                if (!repeats.Contains(programs))
                    repeats.Add(programs);
                programs = DanceWithMeHoney(input, programs);
            } while (!repeats.Contains(programs));

            repeats.Clear();

            do
            {
                if (!repeats.Contains(programs))
                    repeats.Add(programs);
                programs = DanceWithMeHoney(input, programs);
            } while (!repeats.Contains(programs));

            return repeats[1000000000 % repeats.Count];
        }
    }
}
