using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StringProblems
    {
        public static bool IsAcronym(IList<string> words, string s)
        {
            if (s.Length != words.Count) return false;
            int i = 0;
            foreach (string word in words)
            {
                if (word[0] != s[i][0]) return false;
            }
        }

        public static int CharacterReplacement(string s, int k)
        {
            var map = new Dictionary<char, int>()
            {
                { 'A', 0 },
                { 'B', 0 },
                { 'C', 0 },
                { 'D', 0 },
                { 'E', 0 },
                { 'F', 0 },
                { 'G', 0 },
                { 'H', 0 },
                { 'I', 0 },
                { 'J', 0 },
                { 'K', 0 },
                { 'L', 0 },
                { 'M', 0 },
                { 'N', 0 },
                { 'O', 0 },
                { 'P', 0 },
                { 'Q', 0 },
                { 'R', 0 },
                { 'S', 0 },
                { 'T', 0 },
                { 'U', 0 },
                { 'V', 0 },
                { 'W', 0 },
                { 'X', 0 },
                { 'Y', 0 },
                { 'Z', 0 },
            };
            int result = 0; int max = 0;
            int l = 0, r = 0;
            while (r < s.Length)
            {
                char c = s[r];
                map[c]++;
                max = Math.Max(max, map[c]);
                while ((r - l + 1) - max > k)
                {
                    char cl = s[l];
                    map[cl]--;
                    l++;
                }
                result = Math.Max(result, r - l + 1);
                r++;
            }
            return result;
        }

        public static int MostFreqChar(Dictionary<char, int> map)
        {
            int result = 0;
            foreach (var keyValue in map)
            {
                var value = keyValue.Value;
                if (result < value) result = value;
            }
            return result;
        }

        public static int CountSubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int left;
                int right;

                left = i;
                right = i;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    count++;
                    left = left - 1;
                    right = right + 1;
                }

                left = i;
                right = i + 1;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    count++;
                    left = left - 1;
                    right = right + 1;
                }
            }
            return count;
        }

        public static string LongestPalindromes(string s)
        {
            if (s.Length == 1) return s.Substring(0, 1);
            string result = s.Substring(0, 1);
            int resLen = 1;
            for (int i = 0; i < s.Length; i++)
            {
                int left;
                int right;

                left = i;
                right = i;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    if (right - left + 1 > resLen)
                    {
                        result = s.Substring(left, right - left + 1);
                        resLen = right - left + 1;
                    }

                    left = left - 1;
                    right = right + 1;
                }

                left = i;
                right = i + 1;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    if (right - left + 1 > resLen)
                    {
                        result = s.Substring(left, right - left + 1);
                        resLen = right - left + 1;
                    }

                    left = left - 1;
                    right = right + 1;
                }


            }
            return result;
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new Dictionary<string, IList<string>>();
            if (strs.Length == 0) return result.Values.ToList();
            foreach (var str in strs)
            {
                var strArray = str.ToCharArray();
                Array.Sort(strArray);
                var sortedStr = new string(strArray);
                if (result.ContainsKey(sortedStr)) result[sortedStr].Add(str);
                else result.Add(sortedStr, new List<string>() { str });

            }
            return result.Values.ToList();
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            if (p.Length > s.Length) return new List<int>();
            var list = new List<int>();
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                var currentStr = s.Substring(i, p.Length);
                if (IsAnagrams(currentStr, p))
                    list.Add(i);
            }

            return list;
        }

        public static bool IsAnagrams(string s, string t)
        {

            int[] arr = new int[127];

            foreach (char c in s.ToArray())
            {

                arr[c]++;
            }

            foreach (char c in t.ToArray())
            {

                arr[c]--;
            }

            foreach (int count in arr)
            {
                if (count > 0 || count < 0)
                {
                    return false;
                }
            }

            return true;
        }



        public static string longestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];
            var prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix)) return "";
                }
            }
            return prefix;
        }

        public static int LongestPalindrome(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else map.Add(c, 1);
            }

            bool one = false;
            int maxCount = 0;

            foreach (var keyValue in map)
            {
                var value = keyValue.Value;
                if (value % 2 == 0) maxCount += value;
                else
                {
                    var wholeValue = value - 1;
                    maxCount += wholeValue;
                    if (one == false)
                    {
                        maxCount++;
                        one = true;
                    }
                }

            }
            return maxCount;

        }
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var s1 = s.ToArray();
            var t1 = t.ToArray();
            Array.Sort(s1);
            Array.Sort(t1);

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != t1[i]) return false;
            }

            return true;
        }

        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            string result = "";
            foreach (char c in s)
                if (char.IsLetterOrDigit(c)) result = c + result;

            result = result.ToLower();
            Console.WriteLine(result);

            int left = 0;
            int right = result.Length - 1;
            while (left < right)
            {
                if (result[left] != result[right]) return false;
                left++;
                right--;
            }

            return true;
        }

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var cc = s[i];
                if (stack.Count == 0) stack.Push(cc);
                else
                {
                    if (cc == '{' || cc == '[' || cc == '(') stack.Push(cc);
                    else if (cc == '}')
                    {
                        var last = stack.Peek();
                        if (last == '{') stack.Pop();
                        else stack.Push(last);
                    }
                    else if (cc == ']')
                    {
                        var last = stack.Peek();
                        if (last == '[') stack.Pop();
                        else stack.Push(last);
                    }
                    else if (cc == ')')
                    {
                        var last = stack.Peek();
                        if (last == '(') stack.Pop();
                        else stack.Push(last);
                    }
                }
            }

            return (stack.Count > 0) ? false : true;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            int maxCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var set = new HashSet<char>();
                int count = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (!set.Contains(s[j]))
                    {
                        set.Add(s[j]);
                        count++;
                    }
                    else break;

                    if (maxCount < count) maxCount = count;

                }
            }

            return maxCount;
        }

        public static string MinWindow(string s, string t)
        {
            if (s.Length == 0 || t.Length == 0) return "";

            int[] charCount = new int[128];  // Assume ASCII
            foreach (char c in t) charCount[c]++;

            int left = 0, right = 0, required = t.Length;
            int minLength = int.MaxValue, minStart = 0;

            while (right < s.Length)
            {
                if (charCount[s[right]] > 0) required--;
                charCount[s[right]]--;

                while (required == 0)
                {
                    if (right - left < minLength)
                    {
                        minLength = right - left;
                        minStart = left;
                    }

                    charCount[s[left]]++;
                    if (charCount[s[left]] > 0) required++;
                    left++;
                }

                right++;
            }

            if (minLength == int.MaxValue) return "";
            return s.Substring(minStart, minLength + 1);

        }

        public static bool ContainsAllChars(string s, string t)
        {

            int[] arr = new int[127];

            foreach (char c in s.ToArray())
            {

                arr[c]++;
            }

            foreach (char c in t.ToArray())
            {

                arr[c]--;
            }

            foreach (char c in t.ToArray())
                if (arr[c] < 0) return false;

            return true;
        }
    }
}
