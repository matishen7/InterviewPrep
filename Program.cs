
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

int[] arr1 = { };
int[] arr2 = { 1 };
ListNode list1 = null;
ListNode list2 = null;

ListNode[] lists = new ListNode[2];
lists[0] = list1;
lists[1] = list2;

var result = LinkedListProblems.MergeKLists(lists);
LinkedListProblems.PrintLinkedList(result);

