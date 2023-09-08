using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DPProblems
    {
        public static int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1) return 0;
            int minSoFar = prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var currentProfit = prices[i] - minSoFar;
                if (profit < currentProfit) profit = currentProfit;
                minSoFar = Math.Min(minSoFar, prices[i]);
            }

            return profit;
        }
    }
}
