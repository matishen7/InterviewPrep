
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
int[][] graph = {
new int[] {1, 3 },
new int[] {0 },
new int[] {3, 8 },
new int[] {0, 2, 4, 5 },
new int[] { 3, 6 },
new int[] { 3 },
new int[] { 4,7 },
new int[] { 6 },
new int[] { 2 } };
GraphProblems.GraphTraversalDFS(graph);