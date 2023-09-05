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
        private List<int> list;
        public MedianFinder()
        {
            list = new List<int>();
        }

        public void AddNum(int num)
        {
            list.Add(num);
            var arr = list.ToArray();
            Array.Sort(arr);
            list = arr.ToList();
            sum += num;
        }

        public double FindMedian()
        {
            if (list.Count%2 == 0)
            {
                return sum/list.Count;
            }

            else return list[(list.Count /2)];
        }
    }
}
