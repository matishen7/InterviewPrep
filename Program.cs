
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

int[] arr1 = { 1,2,3,4,5};
int[] arr2 = { 6,6,1,7,8};




var head1 = LinkedListProblems.FromArray(arr1);
var head2 = LinkedListProblems.FromArray(arr2);
var result = LinkedListProblems.MergeTwoLists(head1, head2);
LinkedListProblems.PrintLinkedList(result);

