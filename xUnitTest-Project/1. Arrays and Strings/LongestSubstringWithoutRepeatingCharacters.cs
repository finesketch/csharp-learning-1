/*
Given a string, find the length of the longest substring without repeating characters.

Example 1:

Input: "abcabcbb"
Output: 3 
Explanation: The answer is "abc", with the length of 3. 
Example 2:

Input: "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3. 
             Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
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
        }

        [Fact]
        public static void LengthOfLongestSubstringTest1()
        {
            var input = "ckilbkd";
            var expected = 5;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest2()
        {
            var input = "dvdk";
            var expected = 3;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest3()
        {
            var input = "abcabcbb";
            var expected = 3;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest4()
        {
            var input = "bbbbb";
            var expected = 1;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LengthOfLongestSubstringTest5()
        {
            var input = "pwwkew";
            var expected = 3;
            var result = LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }
    }
}
