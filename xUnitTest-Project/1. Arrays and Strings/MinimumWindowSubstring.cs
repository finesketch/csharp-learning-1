/*

Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
   Hide Hint #1  
Use two pointers to create a window of letters in S, which would have all the characters from T.
   Hide Hint #2  
Since you have to find the minimum window in S which has all the characters from T, you need to expand and contract the window using the two pointers and keep checking the window for all the characters. This approach is also called Sliding Window Approach. 

L ------------------------ R , Suppose this is the window that contains all characters of T 
                          
        L----------------- R , this is the contracted window. We found a smaller window that still contains all the characters in T

When the window is no longer valid, start expanding again using the right pointer. 

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
        public static string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            {
                return "";
            }
            else if (s.Length < t.Length)
            {
                return "";
            }
            else if (s == t)
            {
                return s;
            }

            //s = s.ToUpper();
            //t = t.ToUpper();

            var tempT = t.ToCharArray();
            int start = s.Length - 1;
            int end = 0;

            for (int i = 0; i < t.Length; i++)
            {
                var indexStart = s.IndexOf(tempT[i]);
                if (indexStart > -1)
                {
                    if (start > indexStart)
                    {
                        start = indexStart;
                    }
                }
                else
                {
                    return "";
                }

                var indexEnd = s.LastIndexOf(tempT[i]);
                if (indexEnd > -1)
                {
                    if (end < indexEnd)
                    {
                        end = indexEnd;
                    }
                }
            }

            string subtext = s.Substring(start, end - start);
            string found = "";
            bool whileLoop = true;

            while (whileLoop)
            {
                for (int i = start; i < end; i++)
                {
                    subtext = s.Substring(i, end - i + 1);

                    for (int j = 0; j < t.Length - 1; j++)
                    {
                        var index = subtext.IndexOf(tempT[j]);
                        if (index < 0)
                        {
                            whileLoop = false;
                        }
                    }

                    if (whileLoop)
                    {
                        found = s.Substring(i, end - i + 1);
                    }
                }
            }

            return found;
        }

        [Fact]
        public static void MinWindow1()
        {
            var input = "ADOBECODEBANC";
            var input1 = "ABC";
            var expected = "BANC";
            var result = MinWindow(input, input1);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MinWindow2()
        {
            var input = "a";
            var input1 = "a";
            var expected = "a";
            var result = MinWindow(input, input1);
            Assert.Equal(expected, result);
        }
    }
}
