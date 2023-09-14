
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
int[][] graph = {
new int[] {1, 0 },
new int[] {2, 1 },
new int[] {2, 5 },
new int[] {0, 3 },
new int[] {4, 3 },
new int[] {3, 5 },
new int[] {4, 5 },
};
GraphProblems.CanFinish(6, graph);