using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December07
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            Console.WriteLine($"Root: {FindRoot(input)}");
            Console.WriteLine($"Correct: {GetCorrectedValue(input)}");
        }

        private static string FindRoot(string[] input)
        {
            return input
                .Select(x => x.Split(' ')[0])
                .Where(x => !input
                    .Where(y => y.Contains(">"))
                    .Select(z => z
                        .Split('>')[1]
                        .Replace(" ", string.Empty)
                        .Split(','))
                    .SelectMany(q => q)
                    .Contains(x))
                .Single();
        }

        private static int GetCorrectedValue(string[] input)
        {
            var nodes = input.Select(x => GetNodeFromInput(x)).ToList();
            var rootName = FindRoot(input);
            Node root = nodes.Single(x => x.Name == rootName);

            Fill(root, input, nodes, 0);
            return GetCorrectedValueRecursive(root, 0);
        }

        private static int GetCorrectedValueRecursive(Node current, int previousSum)
        {
            var childSums = current
                .Children
                .Select(x => new
                {
                    Sum = SumOfMeAndChildren(x, 0),
                    Name = x.Name
                })
                .GroupBy(x => x.Sum);

            if (childSums.Count() > 1)
            {
                var child = current
                    .Children
                    .Single(x => childSums
                        .Single(y => y.Count() == 1)
                        .Single()
                        .Name == x.Name);
                var otherSum = childSums.Single(x => x.Count() != 1).First().Sum;

                return GetCorrectedValueRecursive(child, otherSum);
            }
            return current.Weight - (SumOfMeAndChildren(current, 0) - previousSum);
        }

        private static int SumOfMeAndChildren(Node node, int sum)
        {
            return node.Weight + node.Children.Sum(x => SumOfMeAndChildren(x, sum));
        }

        private static Node Fill(Node current, string[] input, List<Node> nodes, int depth)
        {
            var children = GetChildrenNames(current.Name, input);
            if (children.Any())
            {
                var childrenNodes = nodes.Where(x => children.Contains(x.Name)).ToList();

                childrenNodes.ForEach(x => x.Depth = depth + 1);

                current.Children.AddRange(childrenNodes.Select(x => Fill(x, input, nodes, depth + 1)));
            }

            return current;
        }

        private static List<string> GetChildrenNames(string name, string[] input)
        {
            var row = input.Single(x => x.Split(' ')[0] == name);
            if (row.Contains(">"))
            {
                return row.Split('>')[1]
                        .Replace(" ", string.Empty)
                        .Split(',')
                        .Select(x => x.Split(' ')[0].Split(' ')[0])
                        .ToList();
            }
            return new List<string>();
        }

        private static Node GetNodeFromInput(string input)
        {
            var name = input.Split(' ')[0];
            var start = input.Split('(')[1];
            var end = start.IndexOf(")");
            var weight = Convert.ToInt32(start.Substring(0, end));

            return new Node { Name = name, Weight = weight };
        }

        private class Node
        {
            public string Name;
            public int Weight;
            public List<Node> Children = new List<Node>();
            public int Depth;
        }
    }
}
