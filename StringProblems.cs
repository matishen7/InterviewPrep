﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StringProblems
    {

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var cc = s[i];
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
            if (t.Length > s.Length) return "";
            int w = t.Length;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= s.Length - w; j++)
                {
                    var currentStr = s.Substring(j, w);
                    if (ContainsAllchars(currentStr, t)) { return currentStr; }
                }

                w++;

            }

            return "";

        }

        public static bool ContainsAllchars(string str, string t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (!str.Contains(t[i])) return false;
            }

            return true;
        }
    }
}
