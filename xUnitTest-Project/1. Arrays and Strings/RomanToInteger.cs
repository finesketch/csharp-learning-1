/*

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.

Example 1:

Input: "III"
Output: 3
Example 2:

Input: "IV"
Output: 4
Example 3:

Input: "IX"
Output: 9
Example 4:

Input: "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 5:

Input: "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

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
        public static int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var temp = s.ToUpper().ToCharArray();
            int total = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (temp[i] == 'M')
                {
                    total += 1000;
                }
                else if (temp[i] == 'D')
                {
                    total += 500;
                }
                else if (temp[i] == 'C')
                {
                    if (i < (s.Length - 1) && temp[i + 1] == 'D')
                    {
                        total += 400;
                        i += 1;
                    }
                    else if (i < (s.Length - 1) && temp[i + 1] == 'M')
                    {
                        total += 900;
                        i += 1;
                    }
                    else
                    {
                        total += 100;
                    }
                }
                else if (temp[i] == 'L')
                {
                    total += 50;
                }
                else if (temp[i] == 'X')
                {
                    if (i < (s.Length - 1) && temp[i + 1] == 'L')
                    {
                        total += 40;
                        i += 1;
                    }
                    else if (i < (s.Length - 1) && temp[i + 1] == 'C')
                    {
                        total += 90;
                        i += 1;
                    }
                    else
                    {
                        total += 10;
                    }
                }
                else if (temp[i] == 'V')
                {
                    total += 5;
                }
                else if (temp[i] == 'I')
                {
                    if (i < (s.Length - 1) && temp[i + 1] == 'V')
                    {
                        total += 4;
                        i += 1;
                    }
                    else if (i < (s.Length - 1) && temp[i + 1] == 'X')
                    {
                        total += 9;
                        i += 1;
                    }
                    else
                    {
                        total += 1;
                    }
                }
            }

            return total;
        }

        [Fact]
        public static void RomanToInt1()
        {
            var input = "III";
            var expected = 3;
            var result = RomanToInt(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void RomanToInt2()
        {
            var input = "IV";
            var expected = 4;
            var result = RomanToInt(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void RomanToInt3()
        {
            var input = "IX";
            var expected = 9;
            var result = RomanToInt(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void RomanToInt4()
        {
            var input = "LVIII";
            var expected = 58;
            var result = RomanToInt(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void RomanToInt5()
        {
            var input = "MCMXCIV";
            var expected = 1994;
            var result = RomanToInt(input);
            Assert.Equal(expected, result);
        }
    }
}
