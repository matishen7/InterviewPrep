using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GraphProblems
    {
        public static void GraphAdjacencyListBFS(int[][] graph)
        {
            Queue<int[]> queue = new Queue<int[]>();
            var seen = new bool[graph.Length];
            queue.Enqueue(graph[0]);
            seen[0] = true;
            Console.WriteLine(0);
            while (queue.Count > 0)
            {
                var edges = queue.Dequeue();
                foreach (var edge in edges)
                {
                    if (seen[edge] != true)
                    {
                        Console.WriteLine(edge);
                        seen[edge] = true;
                        queue.Enqueue(graph[edge]);
                    }

                }
            }
        }
    }
}
