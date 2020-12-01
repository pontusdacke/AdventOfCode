using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December20
{
    class Program
    {
        // 1000 is "a long run" ¯\_(ツ)_/¯
        static int longRun = 1000;

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            List<Particle> particles = LoadParticles(input);
            Console.WriteLine(ClosestIndex(particles));

            particles = LoadParticles(input);
            Console.WriteLine(CountNonColliding(particles));
        }

        static List<Particle> LoadParticles(string[] input)
        {
            List<Particle> particles = new List<Particle>();
            foreach (var line in input)
            {
                var splittedLine = line.Split('<', '>');
                var position = splittedLine[1].Split(',').Select(x => Convert.ToInt64(x)).ToList();
                var velocity = splittedLine[3].Split(',').Select(x => Convert.ToInt64(x)).ToList();
                var acceleration = splittedLine[5].Split(',').Select(x => Convert.ToInt64(x)).ToList();
                particles.Add(new Particle
                {
                    X = position[0],
                    Y = position[1],
                    Z = position[2],
                    vX = velocity[0],
                    vY = velocity[1],
                    vZ = velocity[2],
                    aX = acceleration[0],
                    aY = acceleration[1],
                    aZ = acceleration[2]
                });
            }
            return particles;
        }

        static int ClosestIndex(List<Particle> particles)
        {
            for (int x = 0; x < longRun; x++)
            {
                Simulate(particles);
            }
            return particles.IndexOf(particles.OrderBy(x => x.Distance).First());
        }

        static int CountNonColliding(List<Particle> particles)
        {
            for (int x = 0; x < longRun; x++)
            {
                HashSet<int> indexesToRemove = new HashSet<int>();
                for (int i = 0; i < particles.Count; i++)
                {
                    for (int j = i + 1; j < particles.Count; j++)
                    {
                        if (particles[i].X == particles[j].X &&
                            particles[i].Y == particles[j].Y &&
                            particles[i].Z == particles[j].Z)
                        {
                            indexesToRemove.Add(i);
                            indexesToRemove.Add(j);
                        }
                    }
                }
                int removed = 0;
                foreach (var ind in indexesToRemove)
                {
                    particles.RemoveAt(ind - removed);
                    removed++;
                }
                indexesToRemove.Clear();

                Simulate(particles);
            }

            return particles.Count();
        }

        static void Simulate(List<Particle> particles)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].vX += particles[i].aX;
                particles[i].vY += particles[i].aY;
                particles[i].vZ += particles[i].aZ;

                particles[i].X += particles[i].vX;
                particles[i].Y += particles[i].vY;
                particles[i].Z += particles[i].vZ;
            }
        }

        class Particle
        {
            public long X;
            public long Y;
            public long Z;

            public long vX;
            public long vY;
            public long vZ;

            public long aX;
            public long aY;
            public long aZ;

            public long Distance => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }
    }
}
