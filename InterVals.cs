using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InterVals
    {
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
