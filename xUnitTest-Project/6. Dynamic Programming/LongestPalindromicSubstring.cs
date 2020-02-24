/*

Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

Example 1:

Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.
Example 2:

Input: "cbbd"
Output: "bb"

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.DynamicProgramming
{
    public partial class Solution
    {
        public static string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }
            else if (s.Length == 1)
            {
                return s;
            }

            int start = 0;
            int end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            int L = left;
            int R = right;

            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }

            return R - L - 1;
        }

        [Fact]
        public static void LongestPalindrome1()
        {
            var input = "babad";
            var expected = "aba";
            var result = LongestPalindrome(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void LongestPalindrome2()
        {
            var input = "cbbd";
            var expected = "bb";
            var result = LongestPalindrome(input);
            Assert.Equal(expected, result);
        }
    }
}
