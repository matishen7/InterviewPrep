
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
var left = new TreeNode(1);
var right = new TreeNode(3);
var root = new TreeNode(2, left, right);
Console.WriteLine(BinaryTreeProblems.InvertTree(root));