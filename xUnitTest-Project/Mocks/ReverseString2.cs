/*

Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original.
Example:

Input: s = "abcdefg", k = 2
Output: "bacdfeg"
Restrictions:
The string consists of lower English letters only.
Length of the given string and k will in the range [1, 10000]

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.Mocks
{
    public partial class Solution
    {
        public static string ReverseStr(string s, int k)
        {

            StringBuilder updated = new StringBuilder();
            string needToReverse = "";
            string reversed = "";
            bool flag = true;

            for (int i = 0; i < s.Length; i += k)
            {
                if ((i + k) < s.Length && flag)
                {
                    needToReverse = s.Substring(i, k);
                    reversed = ReverseString(needToReverse);
                    flag = false;
                }
                else
                {
                    flag = true;

                    if ((i + k) < s.Length)
                    {
                        reversed = s.Substring(i, k);
                    }
                    else
                    {
                        reversed = s.Substring(i, s.Length - i);
                    }
                }

                updated.Append(reversed);
            }

            return updated.ToString();

        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        [Fact]
        public static void ReverseStr1()
        {
            var input = "abcdefg";
            var expected = "bacdfeg";

            var result = ReverseStr(input, 2);

            Assert.Equal(expected, result);
        }

    }
}
