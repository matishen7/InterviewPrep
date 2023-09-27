using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InterVals
    {

        public static IList<int> AddToArrayForm(int[] num, int k)
        {
            int currentIndex = num.Length - 1;
            int carry = 0;
            var list = new List<int>();
            while (k > 0)
            {
                var d = k % 10;
                var add = num[currentIndex] + d;

                if (add >= 10)
                {
                    list.Add(add % 10);
                    carry = add / 10;
                }
                else list.Add(add);

                k /= 10;
                currentIndex--;
            }

            while (currentIndex >= 0)
            {
                var add = num[currentIndex] + carry;
                list.Add(add % 10);
                carry = add / 10;
                currentIndex--;
            }
            if (carry > 0)
            {
                var add = carry + list[list.Count - 1];
                list[list.Count - 1] = add % 10;
                carry = add / 10;
            }
            if (carry > 0) list.Add(carry);
            return ReverseList(list);

        }

        public static List<int> ReverseList(List<int> list)
        {
            var reversed = new List<int>();
            for (int i = list.Count - 1; i >= 0; i--)
                reversed.Add(list[i]);
            return reversed;
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var currNodeA = headA;
            var currNodeB = headB;

            while (currNodeA != null && currNodeB == null)
            {
                currNodeA = currNodeA.next;
                currNodeB = currNodeB.next;
            }

            return null;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var map1 = new Dictionary<int, int>();
            var map2 = new Dictionary<int, int>();
            foreach (int num in nums1)
            {
                if (map1.ContainsKey(num)) map1[num]++;
                else map1.Add(num, 1);
            }

            foreach (int num in nums2)
            {
                if (map2.ContainsKey(num)) map2[num]++;
                else map2.Add(num, 1);
            }

            var answer = new List<int>();

            foreach (var pair in map1)
            {
                var num = pair.Key;
                var count1 = pair.Value;
                if (map2.ContainsKey(num))
                {
                    var count2 = map2[num];
                    var min = (count1 > count2) ? count2 : count1;
                    for (int j = 0; j < min; j++)
                        answer.Add(num);
                }
            }

            return answer.ToArray();
        }

        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
                set1.Add(nums1[i]);
            for (int i = 0; i < nums2.Length; i++)
                set2.Add(nums2[i]);

            var answer = new HashSet<int>();

            foreach (var num in set1)
            {
                if (set2.Contains(num)) answer.Add(num);
            }

            return answer.ToArray();
        }
        public static int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length <= 1) return 0;
            intervals = intervals.OrderBy(innerArr => innerArr[0]).ToArray();
            int result = 0;
            int prevEnd = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                if (start >= prevEnd) prevEnd = intervals[i][1];
                else
                {
                    result++;
                    prevEnd = Math.Min(prevEnd, intervals[i][1]);
                }
            }

            return result;
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;
            intervals = intervals.OrderBy(innerArr => innerArr[0]).ToArray();
            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);
            int currentInterval = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];
                var currentStart = result[currentInterval][0];
                var currentEnd = result[currentInterval][1];

                if (currentEnd < start)
                {
                    result.Add(intervals[i]);
                    currentInterval++;
                }
                else
                {
                    int newStart = (currentStart < start) ? currentStart : start;
                    int newEnd = (currentEnd <= end) ? end : currentEnd;
                    result[currentInterval][0] = newStart;
                    result[currentInterval][1] = newEnd;
                }
            }

            return result.ToArray();
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var newIntervals = intervals.ToList();
            newIntervals.Add(newInterval);
            intervals = newIntervals.OrderBy(innerArr => innerArr[0]).ToArray();
            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);
            int currentInterval = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];
                var currentStart = result[currentInterval][0];
                var currentEnd = result[currentInterval][1];

                if (currentEnd < start)
                {
                    result.Add(intervals[i]);
                    currentInterval++;
                }
                else
                {
                    int newStart = (currentStart < start) ? currentStart : start;
                    int newEnd = (currentEnd <= end) ? end : currentEnd;
                    result[currentInterval][0] = newStart;
                    result[currentInterval][1] = newEnd;
                }
            }

            return result.ToArray();
        }
    }
}
