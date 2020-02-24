/*

Implement strStr().

Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2
Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1
Clarification:

What should we return when needle is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static int StrStr(string haystack, string needle)
        {
            if (haystack == null || needle == null)
            {
                return -1;
            }

            if (haystack == "" && needle == "")
            {
                return 0;
            }

            if (needle == "")
            {
                return 0;
            }

            var haystackArray = haystack.ToUpper().ToCharArray();
            var needleArray = needle.ToUpper().ToCharArray();
            bool found = false;
            int index = -1;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystackArray[i] == needleArray[0])
                {
                    found = true;
                    index = i;

                    for (int j = 1; j < needle.Length; j++)
                    {
                        if ((i + j) < haystack.Length)
                        {
                            if (haystackArray[i + j] != needleArray[j])
                            {
                                found = false;
                            }
                        }
                        else
                        {
                            found = false;
                        }
                    }

                    if (found)
                    {
                        return index;
                    }
                }
            }

            if (!found)
            {
                return -1;
            }

            return index;
        }

        [Fact]
        public static void StrStr1()
        {
            var input1 = "";
            var input2 = "";
            var expected = 0;
            var result = StrStr(input1, input2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void StrStr2()
        {
            var input1 = "a";
            var input2 = "";
            var expected = 0;
            var result = StrStr(input1, input2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void StrStr3()
        {
            var input1 = "aaaaa";
            var input2 = "aaaaaaa";
            var expected = -1;
            var result = StrStr(input1, input2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void StrStr4()
        {
            var input1 = "hello";
            var input2 = "ll";
            var expected = 2;
            var result = StrStr(input1, input2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void StrStr5()
        {
            var input1 = "aaaaa";
            var input2 = "bba";
            var expected = -1;
            var result = StrStr(input1, input2);
            Assert.Equal(expected, result);
        }
    }
}
