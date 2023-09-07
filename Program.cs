
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
int[][] image = {
new int[] { 1, 1, 1 },
new int[]{1, 1, 0 },
new int[]{1, 0, 1 } };
Console.WriteLine(Arrays2D.FloodFill(image, 1, 1, 2));