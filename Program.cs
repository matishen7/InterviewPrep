
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
int[][] intervals = { new int[] { 1, 2 },  new int[] { 2, 3 }, new int[] { 3, 4 } , new int[] { 1, 3 }, };
Console.WriteLine(InterVals.EraseOverlapIntervals(intervals));