using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StringProblems
    {
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
    }
}
