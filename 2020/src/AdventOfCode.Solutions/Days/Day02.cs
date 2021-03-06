﻿using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day02 : Day
    {
        protected override long Part1()
        {
            var validPasswords = 0;

            foreach (var i in Inputs)
            {
                var parameters = InputParameters.FromInput(i);
                var occurences = parameters.Password.Count(c => c == parameters.Letter);

                if (occurences >= parameters.X && occurences <= parameters.Y)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        protected override long Part2()
        {
            var validPasswords = 0;

            foreach (var i in Inputs)
            {
                var parameters = InputParameters.FromInput(i);

                if ((parameters.Password[parameters.X - 1] == parameters.Letter)
                    ^ (parameters.Password[parameters.Y - 1] == parameters.Letter))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        private class InputParameters
        {
            public string Password { get; private set; }
            public int X { get; private set; }
            public int Y { get; private set; }
            public char Letter { get; private set; }

            public static InputParameters FromInput(string input)
            {
                var policyAndPassword = input.Split(':');
                var policy = policyAndPassword[0].Split(' ');
                var positions = policy[0].Split('-');
                var x = int.Parse(positions[0]);
                var y = int.Parse(positions[1]);
                var letter = policy[1][0];
                var password = policyAndPassword[1].Trim();

                return new InputParameters
                {
                    Password = password,
                    Letter = letter,
                    X = x,
                    Y = y,
                };
            }
        }
    }
}
