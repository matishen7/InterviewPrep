﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Arrays1D
    {
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
                set.Add(nums[i]);
            var listArr = set.ToArray();
            Array.Sort(listArr);
            var prev = listArr[0];
            int max = 1;
            int count = 1;
            for (int i = 1; i < listArr.Length; i++)
            {
                if ((listArr[i] - prev == 1) || (listArr[i] - prev == 0))
                    count++;
                else
                {
                    if (count > max) max = count;
                    count = 1;
                }
                prev = listArr[i];
            }

            return (max > count) ? max : count;
        }
        public static int maxSubArray(int[] nums)
        {
            int[] maxSum = new int[nums.Length];
            maxSum[0] = nums[0];
            int max = maxSum[0];
            for (int i = 1; i < nums.Length; i++)
            {
                maxSum[i] = Math.Max(nums[i], nums[i] + maxSum[i - 1]);
                if (max < maxSum[i]) max = maxSum[i];
            }
            return max;
        }

        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int side = Math.Min(height[left], height[right]);
                int currArea = side * (right - left);
                if (currArea > maxArea) maxArea = currArea;
                if (height[left] < height[right]) left++;
                else right--;
            }

            return maxArea;
        }

        public static int Search(int[] nums, int target)
        {
            var arr1 = new List<int>();
            var arr2 = new List<int>();
            arr1.Add(nums[0]);
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i - 1]) arr1.Add(nums[i]);
                else break;
            }

            int c = arr1.Count;
            for (int i = c; i < nums.Length; i++)
            {
                arr2.Add(nums[i]);
            }

            int index1 = -1;
            int index2 = -1;

            index1 = BinarySearch(arr1.ToArray(), target);
            index2 = BinarySearch(arr2.ToArray(), target);

            if (index1 == -1 && index2 == -1) return -1;
            else if (index1 == -1 && index2 != -1)
            {
                return arr1.Count + index2;
            }

            return index1;
        }

        public static int BinarySearch(int[] nums, int target)
        {
            return BS(nums, 0, nums.Length - 1, target);
        }

        public static int BS(int[] arr, int left, int right, int target)
        {
            if (right < left || right < 0 || left > arr.Length) return -1;
            int mid = (left + right) / 2;
            if (arr[mid] == target) return mid;
            else if (arr[mid] < target)
                return BS(arr, mid + 1, right, target);
            else return BS(arr, left, mid - 1, target);

        }

        public static IList<IList<int>> ThreeSum(int[] arr)
        {
            var ans = new List<IList<int>>();
            Array.Sort(arr);
            int target = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) continue;
                int left = i + 1;
                int right = arr.Length - 1;
                while (left < right)
                {
                    if (arr[i] + arr[left] + arr[right] > target)
                        right--;
                    else if (arr[i] + arr[left] + arr[right] < target)
                        left++;
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(arr[i]);
                        list.Add(arr[left]);
                        list.Add(arr[right]);
                        ans.Add(list);
                        left++;
                        while (arr[left] == arr[left - 1] && left < right)
                            left++;
                    }
                }
            }
            return ans;
        }

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
            for (int i = 0; i < answer.Length; i++)
                answer[i] = right[i] * left[i];

            return answer;
        }
    }
}
