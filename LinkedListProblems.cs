using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinkedListProblems
    {
        public static ListNode ReverseList(ListNode head)
        {
            PrintLinkedList(head);
            ListNode result = null;
            var currentNode = head;
            while (currentNode != null)
            {
                ListNode next = currentNode.next;
                currentNode.next = result;
                result = currentNode;
                currentNode = next;
            }
            return result;
        }

        public static ListNode FromArray(int[] arr)
        {
            ListNode listSofar = new ListNode();
            ListNode prev = null;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                ListNode createdNode = new ListNode(arr[i], prev);
                listSofar = createdNode;
                prev = listSofar;
            }
            return listSofar;
        }

        public static void PrintLinkedList(ListNode head)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.val);
                currentNode = currentNode.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
