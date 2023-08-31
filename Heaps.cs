using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Heaps
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            var count = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (count.ContainsKey(nums[i]))
                {
                    count[nums[i]]++;
                }
                else count.Add(nums[i], 1);
            }

            MyPriorityQueue<int, int> priorityQueue= new MyPriorityQueue<int, int>((a, b) => b.CompareTo(a));
            foreach(var keyvalue in count)
            {
                var key = keyvalue.Key;
                var value = keyvalue.Value;
                priorityQueue.Enqueue(key, value);
            }
            List<int> list = new List<int>();
            int j = 0;
            while (j < k)
            {
                priorityQueue.TryDequeue(out int item, out int priority);
                list.Add(item);
                j++;
            }

            return list.ToArray();
        }
    }
}
