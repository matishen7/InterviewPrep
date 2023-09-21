
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
char[][] jaggedCharArray = new char[][]
{
    new char[] { 'A', 'B', 'C', 'E' },
    new char[] { 'S', 'F', 'C', 'S' },
    new char[] { 'A', 'D', 'E', 'E' }
};

string s = "";
Arrays2D.Exist(jaggedCharArray, s);