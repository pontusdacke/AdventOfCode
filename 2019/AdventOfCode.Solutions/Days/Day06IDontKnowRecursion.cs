using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode.Solutions.Days
{
    /// <summary>
    /// Returns Too low: 102372
    /// Correct: 142497
    /// </summary>
    class Day06IDontKnowRecursion : Day
    {
        public override void Part1()
        {
            var tests = ParseInput();
            var thread = new Thread(_ => CountStuff(tests, tests.Count - 1, tests.Last(), 0), 800000000);
            thread.Start();
            thread.Join();
        }

        private List<Node> ParseInput()
        {
            var tests = new List<Node>();

            foreach (var input in inputs)
            {
                var parts = input.Split(')');
                var parent = parts[0];
                var child = parts[1];

                tests.Add(new Node
                {
                    Parent = parent,
                    Child = child,
                });
            }

            return tests;
        }

        private int CountStuff(List<Node> inputs, int index, Node current, int count)
        {
            if (inputs[index].Parent == "COM")
            {
                Console.WriteLine(count + 1);
                return count + 1;
            }
            else if (current.Parent == "COM")
            {
                var newIndex = index - 1;
                return count + CountStuff(inputs, newIndex, inputs[newIndex], ++count);
            }
            else
            {
                Node next = FindNext(inputs, current);

                return CountStuff(inputs, index, next, ++count);
            }
        }

        private static Node FindNext(List<Node> inputs, Node current)
        {
            Node next = null;
            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Child == current.Parent)
                {
                    next = inputs[i];
                    break;
                }
            }

            return next;
        }

        public override void Part2()
        {
        }

        class Node
        {
            public string Parent { get; set; }
            public string Child { get; set; }
        }
    }
}
