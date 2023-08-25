using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Arrays
    {
        public static int[] twoSum(int[] arr, int target)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int ff = target - arr[i];
                if (dic.ContainsKey(ff)) return new int[] { dic[ff], i };
                else if (!dic.ContainsKey(arr[i])) dic.Add(arr[i], i);
            }
            return null;
        }

        public static int MaxProfit(int[] prices)
        {
            int min = Int32.MaxValue;
            int profit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (min > prices[i]) min = prices[i];
                int currProfit = prices[i] - min;
                if (currProfit > profit) profit = currProfit;
            }
            return profit;
        }
    }
}
