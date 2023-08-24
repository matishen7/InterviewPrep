
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

char[][] grid = {
    new char[] {'1','1','0','0','0'},
    new char[] {'1','1','0','0','0'},
    new char[] {'0','0','1','0','0'},
    new char[] {'0','0','0','1','1'}
};


Console.WriteLine(Arrays2D.NumIslands(grid));

