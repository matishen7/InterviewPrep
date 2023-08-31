using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MedianFinder
    {
        private double sum = 0;
        private PriorityQueue<int> list;
        public MedianFinder()
        {
            list = new PriorityQueue<int>((a, b) => a.CompareTo(b));
        }

        public void AddNum(int num)
        {
            list.Enqueue(num);
            sum += num;
        }

        public double FindMedian()
        {
            if (list.Count%2 == 0)
            {
                return sum/list.Count;
            }

            else return list.GetElementAt(list.Count/2);
        }
    }
}
