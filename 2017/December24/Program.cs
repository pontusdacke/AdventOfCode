using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December24
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            List<Component> components = new List<Component>();
            foreach (var row in input)
            {
                var nums = row.Split('/');
                components.Add(new Component
                {
                    a = Convert.ToInt32(nums[0]),
                    b = Convert.ToInt32(nums[1])
                });
            }

            var perms = ParallelEnumerable
                .Range(0, components.Count)
                .Select(x => GetPermutations(components, x)
                    .Where(y => y.First().a == 0)
                    .Where(y => y.Count(z => z.a == 0) == 1)
                    .ToList())
                    .ToList();

            foreach (var compSize in perms)
            {
                for (int j = 0; j < compSize.Count; j++)
                {
                    bool remove = false;
                    for (int i = 1; i < compSize[j].Count(); i++)
                    {
                        var current = new List<int> { compSize.ElementAt(j).ElementAt(i).a, compSize.ElementAt(j).ElementAt(i).b };
                        var previous = new List<int> { compSize.ElementAt(j).ElementAt(i - 1).a, compSize.ElementAt(j).ElementAt(i - 1).b };
                        List<int> prevprev = null;
                        if (i > 1)
                        {
                            prevprev = new List<int> { compSize.ElementAt(j).ElementAt(i - 2).a, compSize.ElementAt(j).ElementAt(i - 2).b };
                        }
                        if (!current.Intersect(previous).Any() || (i > 2 && Enumerable.SequenceEqual(prevprev.Intersect(current), previous.Intersect(current))))
                        {
                            remove = true;
                        } 
                    }
                    if (remove)
                    {
                        compSize.RemoveAt(j);
                        j--;
                    }
                }
            }

            Console.WriteLine(perms.SelectMany(x => x).ToList().Max(x => x.Sum(y => y.strength)));
        }


        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                    {
                        yield return new T[] { item }.Concat(result);
                    }
                }

                ++i;
            }
        }

        class Component
        {
            public int a;
            public int b;
            public int strength => a + b;
        }
    }
}
