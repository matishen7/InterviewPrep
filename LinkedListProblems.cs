using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinkedListProblems
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            var listResult = new List<int>();
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode currentNode;
                if (lists[i] == null) continue; 
                currentNode = lists[i];
                while(currentNode != null)
                {
                    listResult.Add(currentNode.val);
                    currentNode = currentNode.next;
                }
            }
            var arrResult = listResult.ToArray();
            Array.Sort(arrResult);
            return FromArray(arrResult);

        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null) return null;
            var arrResult = new int[100];
            //Array.Fill(arrResult, -1000);
            var currentNode = list1;
            int i = 0;
            while (currentNode != null)
            {
                arrResult[i] = currentNode.val;
                i++;
                currentNode = currentNode.next;
            }

            currentNode = list2;
            while (currentNode != null)
            {
                arrResult[i] = currentNode.val;
                i++;
                currentNode = currentNode.next;
            }
            Array.Sort(arrResult, 0, i);
            return FromArray(arrResult, i);

        }
        public bool HasCycle(ListNode head)
        {
            var currentNode = head;
            var set = new HashSet<ListNode>();
            while (currentNode != null)
            {
                if (set.Contains(currentNode)) return true;
                else set.Add(currentNode);
                currentNode = currentNode.next;
            }
            return false;
        }

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

        public static ListNode FromArray(int[] arr, int length)
        {
            ListNode listSofar = new ListNode();
            ListNode prev = null;
            for (int i = length; i >= 0; i--)
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
