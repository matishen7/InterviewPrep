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
            int profit = 0;
            int min = prices[0];
            int max = prices[prices.Length - 1];
            int j = prices.Length - 1;
            for (int i = 0; i < prices.Length; i++)
            {
                if (min > prices[i]) min = prices[i];
                if (max < prices[j]) max = prices[j];
                if (profit < max - min) profit = max - min;
                j--;
                if (j <= i) break;
            }
            return profit;
        }
    }
}
