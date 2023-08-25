﻿using System;
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

        public static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0) return false;
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i])) return true;
                else set.Add(nums[i]);
            }

            return false;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int product = 1;
            var left = new int[nums.Length];
            left[0] = product;
            for (int i = 1; i < nums.Length; i++)
            {
                product = nums[i - 1] * left[i - 1];
                left[i] = product;
            }

            var right = new int[nums.Length];
            right[nums.Length - 1] = 1;
            for (int i = nums.Length; i > 1; i--)
            {
                product = nums[i - 1] * right[i - 1];
                right[i - 2] = product;
            }
            int[] answer = new int[nums.Length];
            for (int i = 0; i < answer.Length;i++)
                answer[i] = right[i] * left[i];

            return answer;
        }
    }
}