
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

int[][] grid = {
    new int[] { 0, 1, 0, 0 },
    new int[]{1, 1, 1, 0 },
    new int[]{0, 1, 0, 0 },
    new int[]{1, 1, 0, 0 }};
Console.WriteLine(ProblemSet1.IslandPerimeter(grid));

