
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
int[][] heights = new int[][]
           {
                 new int[] {1, 2, 2, 3, 5},
                new int[] {3, 2, 3, 4, 4},
                new int[] {2, 4, 5, 3, 1},
                new int[] {6, 7, 1, 4, 5},
                new int[] {5, 1, 1, 2, 4}
           };
Arrays2D.PacificAtlantic(heights);