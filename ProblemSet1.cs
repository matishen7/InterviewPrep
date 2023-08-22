using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.BST;

namespace ConsoleApp1
{
    internal class ProblemSet1
    {
        public static int CalPoints(string[] operations)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i].Equals("C")) stack.Pop();
                else if (operations[i].Equals("D"))
                {
                    int op;
                    if (stack.Count != 0)
                    {
                        op = stack.Peek();
                        op *= 2;
                        stack.Push(op);
                    }
                }
                else if (operations[i].Equals("+"))
                {
                    int s = 0, count = 0, j = 0;
                    while (count < 2)
                    {
                        s += stack.ElementAt(j);
                        j++;
                        count++;
                    }
                    stack.Push(s);

                }
                else
                    stack.Push(Int32.Parse(operations[i]));
            }
            int sum = 0;
            while (stack.Count > 0)
                sum += stack.Pop();
            return sum;

        }
        public static int SumOfUnique(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], 1);
                else
                    dic[nums[i]]++;
            }
            int sum = 0;
            foreach (var num in dic)
            {
                var count = num.Value;
                if (count <= 1) sum += num.Key;
            }
            return sum;
        }

        static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var dic1 = new Dictionary<int, int>();
            var dic2 = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
                if (!dic1.ContainsKey(nums1[i]))
                    dic1.Add(nums1[i], i);
            for (int i = 0; i < nums2.Length; i++)
                if (!dic2.ContainsKey(nums2[i]))
                    dic2.Add(nums2[i], i);

            var list1 = new List<int>();
            var list2 = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!dic2.ContainsKey(nums1[i]) && !list1.Contains(nums1[i]))
                    list1.Add(nums1[i]);
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (!dic1.ContainsKey(nums2[i]) && !list2.Contains(nums2[i]))
                    list2.Add(nums2[i]);
            }

            return new List<IList<int>>() { list1, list2 };
        }

        static int MyAtoi(string s)
        {
            int minusSign = -1;
            s = s.Trim();
            var sb = new StringBuilder(s);
            minusSign = s.IndexOf('-');
            if (minusSign != -1)
                sb.Remove(minusSign, 1);

            s = IgnoreLeadingZeros(sb.ToString());
            s = RemoveAlphas(s);
            double pow = s.Length - 1.0;
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int digit = s[i] - '0';
                double p = Math.Pow(10, pow);
                result += digit * (int)p;
                pow--;
            }
            return (minusSign != -1) ? (-1) * result : result;
        }

        static int CompareVersion(string version1, string version2)
        {
            var v1 = version1.Split('.').ToList();
            var v2 = version2.Split('.').ToList();
            if (v1.Count > v2.Count)
                while (v1.Count > v2.Count)
                    v2.Add("0");
            else if (v1.Count < v2.Count)
                while (v1.Count < v2.Count)
                    v1.Add("0");

            for (int i = 0; i < v1.Count; i++)
                v1[i] = IgnoreLeadingZeros(v1[i]);
            for (int i = 0; i < v2.Count; i++)
                v2[i] = IgnoreLeadingZeros(v2[i]);
            int v1Num;
            int v2Num;
            for (int i = 0; i < v1.Count; i++)
            {
                if (v1[i] == "") v1Num = 0; else v1Num = Int32.Parse(v1[i]);
                if (v2[i] == "") v2Num = 0; else v2Num = Int32.Parse(v2[i]);

                if (v1Num > v2Num) return 1;
                else if (v1Num < v2Num) return -1;
            }

            return 0;
        }

        static string RemoveAlphas(string s)
        {
            HashSet<char> alphabeticSet = new HashSet<char>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                alphabeticSet.Add(c);
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabeticSet.Add(c);
            }
            alphabeticSet.Add('+');
            var sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                if (alphabeticSet.Contains(sb[i]))
                {
                    sb.Remove(i, 1);
                    i--;
                }
            }
            return sb.ToString().Trim();
        }

        static string IgnoreLeadingZeros(string s)
        {
            Stack<char> chars = new Stack<char>();
            var result = "";
            for (int i = s.Length - 1; i >= 0; i--)
                chars.Push(s[i]);
            while (true)
            {
                if (chars.Count != 0 && chars.Peek() == '0') chars.Pop();
                else break;
            }

            while (chars.Count != 0)
                result += chars.Pop();

            return result;
        }

        static string ReverseWords(string s)
        {
            string result = "";
            string[] words = s.Split(' ');
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i] == string.Empty) continue;
                result += words[i] + " ";
            }
            return result.Trim();
        }

        static int CountSeniors(string[] details)
        {
            int count = 0;
            foreach (var detail in details)
            {
                var f = detail[11];
                var s = detail[12];
                int age = ((int)f - 48) * 10 + (int)s - 48;
                if (age > 60) count++;
            }
            return count;
        }

        static float[] To1DArray(float[,] input)
        {
            // Step 1: get total size of 2D array, and allocate 1D array.
            int size = input.Length;
            float[] result = new float[size];

            // Step 2: copy 2D array elements into a 1D array.
            int write = 0;
            for (int i = 0; i <= input.GetUpperBound(0); i++)
            {
                for (int z = 0; z <= input.GetUpperBound(1); z++)
                {
                    result[write++] = input[i, z];
                }
            }
            // Step 3: return the new array.
            return result;
        }

        static void Print1DArray(float[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + "\t");
        }

        static string RemoveTrailingZeros(string num)
        {
            string result = "";
            bool flag = true;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == '0' && flag == true)
                    continue;
                else
                {
                    result = num[i] + result;
                    flag = false;
                }
            }

            return result;
        }

        static int MaximumNumberOfStringPairs(string[] words)
        {
            int count = 0;
            var dic = new Dictionary<string, int>();
            for (var i = 0; i < words.Length; i++)
            {
                var reverse = ReverseString(words[i]);
                dic.Add(words[i], i);

            }
            for (var i = 0; i < words.Length; i++)
            {
                var reverse = ReverseString(words[i]);
                if (dic.TryGetValue(reverse, out int index) && index != i)
                {
                    count++;
                }

            }

            return count / 2;
        }

        static string ReverseString(string s)
        {
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                result = s[i] + result;
            }

            return result;
        }

        static string MakeSmallestPalindrome(string s)
        {
            var sb = new StringBuilder(s);
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if ((int)sb[left] > (int)sb[right])
                {
                    sb.Replace(sb[left], sb[right], left, 1);
                }
                else if ((int)sb[left] < (int)sb[right])
                {
                    sb.Replace(sb[right], sb[left], right, 1);
                }
                left++; right--;
            }
            return sb.ToString();
        }

        static bool SameTree(Node node1, Node node2)
        {
            var bst = new BST();
            var list1 = bst.BFS(node1);
            var list2 = bst.BFS(node2);
            return SameList(list1, list2);
        }

        static bool SameList(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
                if (list1[i] != list2[i]) return false;
            return true;
        }

        static int TitleToNumber(string columnTitle)
        {
            var dic = new Dictionary<char, int>()
    {
        { 'A', 1},
        { 'B', 2},
        { 'C', 3},
        { 'D', 4},
        { 'E', 5},
        { 'F', 6},
        { 'G', 7},
        { 'H', 8},
        { 'I', 9},
        { 'J', 10},
        { 'K', 11},
        { 'L', 12},
        { 'M', 13},
        { 'N', 14},
        { 'O', 15},
        { 'P', 16},
        { 'Q', 17},
        { 'R', 18},
        { 'S', 19},
        { 'T', 20},
        { 'U', 21},
        { 'V', 22},
        { 'W', 23},
        { 'X', 24},
        { 'Y', 25},
        { 'Z', 26},
    };
            int result = 0;

            for (int i = 0; i < columnTitle.Length; i++)
            {
                int t = columnTitle.Length - i;
                int k = 1;
                while (t > 1)
                {
                    k *= 26;
                    t--;
                }
                result += k * dic[columnTitle[i]];
            }
            return result;
        }

        static string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length)
            {
                return s;
            }

            var result = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
            {
                result[i] = new StringBuilder();
            }

            int index = 0;
            int step = 1;

            foreach (char c in s)
            {
                result[index].Append(c);
                if (index == 0)
                {
                    step = 1;
                }
                else if (index == numRows - 1)
                {
                    step = -1;
                }
                index += step;
            }

            var finalResult = new StringBuilder();
            foreach (var sb in result)
            {
                finalResult.Append(sb);
            }

            return finalResult.ToString();

        }

        static void PrintArray(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Console.WriteLine("------------");
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != '\0') Console.Write(matrix[row, col]); else Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
