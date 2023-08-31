
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

char[][] jaggedArray = new char[][] {
    new char[] { 'C', 'A', 'A' },
    new char[] { 'A', 'A', 'A' },
    new char[] { 'B', 'C', 'D' }
};

var word = "AAB";

Console.WriteLine(Arrays2D.Exist(jaggedArray, word));

