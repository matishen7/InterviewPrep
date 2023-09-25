using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InterVals
    {
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            for (int i = 0;  i < nums1.Length;i++)
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
        public  static int EraseOverlapIntervals(int[][] intervals)
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
