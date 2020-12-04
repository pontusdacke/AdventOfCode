//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Solutions.Days
//{
//    class Day06 : Day
//    {
//        public override void Part1()
//        {
//            var totalSum = 0;
//            var tests = ParseInput(inputs).ToList();

//            for (int i = tests.Count - 1; i >= 0; i--)
//            {
//                Node parent;
//                Node current = tests[i];
//                do
//                {
//                    parent = FindParent(tests, current);
//                    current = parent;
//                    totalSum++;

//                } while (parent != null);
//            }

//            Console.WriteLine("Part 1: " + totalSum);
//        }

//        public override void Part2()
//        {
//            var paths = new Dictionary<string, List<Node>>();
//            var tests = ParseInput(inputs).ToList();

//            GetAllPaths(paths, tests);

//            var you = paths["YOU"];
//            var san = paths["SAN"];

//            var (stepsToSharedParent, sharedParent) = GetSharedParent(you, san);

//            int stepsToSharedParent2 = 0;
//            for (int i = 0; i < san.Count; i++)
//            {
//                stepsToSharedParent2++;
//                if (san[i].Parent == sharedParent.Parent)
//                {
//                    break;
//                }
//            }

//            Console.WriteLine("Part 2: " + (stepsToSharedParent + stepsToSharedParent2));
//        }

//        private static (int steps, Node sharedParent) GetSharedParent(List<Node> you, List<Node> san)
//        {
//            Node sharedParent = null;
//            int stepsToSharedParent = 0;
//            for (int i = 0; i < you.Count; i++)
//            {
//                var potentialParent = san.SingleOrDefault(x => x.Parent == you[i].Parent);
//                stepsToSharedParent++;
//                if (potentialParent != null)
//                {
//                    sharedParent = potentialParent;
//                    break;
//                }
//            }

//            return (stepsToSharedParent, sharedParent);
//        }

//        private static void GetAllPaths(Dictionary<string, List<Node>> paths, List<Node> tests)
//        {
//            for (int i = tests.Count - 1; i >= 0; i--)
//            {
//                Node parent;
//                Node current = tests[i];

//                if (current.Child != "YOU" && current.Child != "SAN")
//                {
//                    continue;
//                }

//                var path = new List<Node>();
//                do
//                {
//                    parent = FindParent(tests, current);
//                    current = parent;
//                    if (current != null)
//                    {
//                        path.Add(current);
//                    }

//                } while (parent != null);
//                paths.Add(tests[i].Child, path);
//            }
//        }

//        private IEnumerable<Node> ParseInput(List<string> inputs)
//        {
//            return inputs
//                .Select(i => i.Split(')'))
//                .Select(n => new Node { Parent = n[0], Child = n[1] });
//        }

//        private static Node FindParent(List<Node> inputs, Node current)
//        {
//            return inputs.SingleOrDefault(i => i.Child == current.Parent);
//        }

//        class Node
//        {
//            public string Parent { get; set; }
//            public string Child { get; set; }
//        }
//    }
//}
