using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December19
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            Console.WriteLine(FindDavidLetterman(input));
            Console.WriteLine(CountDracula(input));
        }

        static string FindDavidLetterman(string[] input)
        {
            Position position = new Position { x = 0, y = 0 };
            string result = string.Empty;
            // Find the starting position
            char currentChar = ' ';
            do
            {
                position.x++;
                currentChar = input[position.y][position.x];
            } while (currentChar == ' ');

            var currentDir = Dir.South;

            while (currentChar != ' ')
            {
                if (currentChar == '+')
                {
                    currentDir = FindNewDirection(currentDir, input, position);
                }
                else if (currentChar >= 'A' && currentChar <= 'Z')
                {
                    result += currentChar;
                }

                Move(position, currentDir);

                currentChar = input[position.y][position.x];
            }

            return result;
        }

        static int CountDracula(string[] input)
        {
            Position position = new Position { x = 0, y = 0 };
            int steps = 0;
            // Find the starting position
            char currentChar = ' ';
            do
            {
                position.x++;
                currentChar = input[position.y][position.x];
            } while (currentChar == ' ');

            var currentDir = Dir.South;

            while (currentChar != ' ')
            {
                if (currentChar == '+')
                {
                    currentDir = FindNewDirection(currentDir, input, position);
                }

                Move(position, currentDir);
                steps++;

                currentChar = input[position.y][position.x];
            }

            return steps;
        }

        static void Move(Position position, Dir dir)
        {
            switch (dir)
            {
                case Dir.North:
                    position.y--;
                    break;
                case Dir.South:
                    position.y++;
                    break;
                case Dir.East:
                    position.x++;
                    break;
                case Dir.West:
                    position.x--;
                    break;
            }
        }

        static Dir FindNewDirection(Dir dir, string[] input, Position position)
        {
            // try north
            if (input[position.y - 1][position.x] != ' ' && input[position.y - 1][position.x] != '+' && dir != Dir.South)
                return Dir.North;
            // try south
            else if (input[position.y + 1][position.x] != ' ' && input[position.y + 1][position.x] != '+' && dir != Dir.North)
                return Dir.South;
            // try east
            else if (input[position.y][position.x + 1] != ' ' && input[position.y][position.x + 1] != '+' && dir != Dir.West)
                return Dir.East;
            // try west
            else
                return Dir.West;
        }

        class Position
        {
            public int x;
            public int y;
        }

        enum Dir
        {
            North,
            South,
            East,
            West
        }
    }
}
