
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

int[] matrix = { 1,2,3,4,5};




var head = LinkedListProblems.FromArray(matrix);
var result = LinkedListProblems.ReverseList(head);
LinkedListProblems.PrintLinkedList(result);

