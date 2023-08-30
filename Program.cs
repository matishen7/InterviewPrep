
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

int[] arr1 = { 1 };

var head = LinkedListProblems.GetLinkedListFromArray(arr1);
var result = LinkedListProblems.RemoveNthFromEnd(head, 1);
LinkedListProblems.PrintLinkedList(result);

