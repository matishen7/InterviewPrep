using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GraphProblems
    {
        public static void GraphTraversalBFS(int[][] graph)
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

        public static void GraphTraversalDFS(int[][] graph)
        {
            var seen = new bool[graph.Length];
            GraphDFS(0, graph, seen);
        }

        internal static void GraphDFS(int vertex, int[][] graph, bool[] seen)
        {
            Console.WriteLine(vertex);
            seen[vertex] = true;
            var connections = graph[vertex];
            foreach (var connection in connections)
            {
                if (seen[connection]!=true)
                    GraphDFS(connection, graph, seen);
            }
        }
    }
}
