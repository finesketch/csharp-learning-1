using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace csharplearning1.ArraysandStrings
{
    public partial class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            else if (s.Length == 1)
            {
                return 1;
            }

            char[] temp = s.ToCharArray();
            var list = new List<char>();
            var lastCount = 0;
            int resetCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (!list.Contains(temp[i]))
                {
                    list.Add(temp[i]);
                    if (lastCount < list.Count())
                    {
                        lastCount = list.Count();
                    }
                }
                else
                {
                    for (int j = i - 1; j >= resetCount; j--)
                    {
                        if (temp[j] == temp[i])
                        {
                            i = j;
                            resetCount = i + 1;
                            list.Clear();
                        }
                    }
                }
            }

            return lastCount;

            /*
            char[] temp = s.ToCharArray();
            var list = new List<char>() { temp[0] };
            char lastMatched = temp[0];
            int lastCount = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (!list.Contains(temp[i]))
                {
                    list.Add(temp[i]);
                    if (lastCount < list.Count())
                    {
                        lastCount = list.Count();
                    }
                }
                else if (lastMatched == temp[i] || list.Contains(temp[i]))
                {
                    if (lastCount < list.Count())
                    {
                        lastCount = list.Count();
                    }
                    list.Clear();
                    list.Add(temp[i]);
                }

                lastMatched = temp[i];
            }

            return lastCount;
            */
        }

        [Fact]
        public static void LengthOfLongestSubstringTest11()
        {
            var input = "ckilbkd";
            var expected = 5;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest22()
        {
            var input = "dvdk";
            var expected = 3;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest33()
        {
            var input = "abcabcbb";
            var expected = 3;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }
    }
}
