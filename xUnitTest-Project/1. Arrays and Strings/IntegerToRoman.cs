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
Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.

Example 1:

Input: 3
Output: "III"
Example 2:

Input: 4
Output: "IV"
Example 3:

Input: 9
Output: "IX"
Example 4:

Input: 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.
Example 5:

Input: 1994
Output: "MCMXCIV"
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
        public static string IntToRoman(int num)
        {
            if (num < 1 || num >= 4000)
            {
                return string.Empty;
            }

            int remains = num;
            double temp = 0;
            var output = new StringBuilder();

            if (num >= 1000)
            {
                temp = remains / 1000;
                int thousands = (int)Math.Floor(temp);

                for (int i = 0; i < thousands; i++)
                {
                    output.Append("M");
                }

                remains = remains % 1000;
            }

            if (remains >= 900)
            {
                output.Append("CM");
                remains = remains % 900;
            }

            if (remains >= 500)
            {
                output.Append("D");
                remains = remains % 500;
            }

            if (remains >= 400)
            {
                output.Append("CD");
                remains = remains % 400;
            }

            if (remains >= 100)
            {
                temp = remains / 100;
                int hundreds = (int)Math.Floor(temp);
                for (int i = 0; i < hundreds; i++)
                {
                    output.Append("C");
                }
                remains = remains % 100;
            }

            if (remains >= 90)
            {
                output.Append("XC");
                remains = remains % 90;
            }

            if (remains >= 50)
            {
                output.Append("L");
                remains = remains % 50;
            }

            if (remains >= 40)
            {
                output.Append("XL");
                remains = remains % 40;
            }

            if (remains >= 10)
            {
                temp = remains / 10;
                int ten = (int)Math.Floor(temp);

                for (int i = 0; i < ten; i++)
                {
                    output.Append("X");
                }

                remains = remains % 10;
            }

            if (remains >= 9)
            {
                output.Append("IX");
                remains = remains % 9;
            }

            if (remains >= 5)
            {
                output.Append("V");
                remains = remains % 5;
            }

            if (remains >= 4)
            {
                output.Append("IV");
                remains = remains % 4;
            }

            if (remains >= 1)
            {
                temp = remains / 1;
                int one = (int)Math.Floor(temp);

                for (int i = 0; i < one; i++)
                {
                    output.Append("I");
                }
            }

            return output.ToString();
        }

        [Fact]
        public static void IntToRoman1()
        {
            var input = 3;
            var expected = "III";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void IntToRoman2()
        {
            var input = 4;
            var expected = "IV";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void IntToRoman3()
        {
            var input = 9;
            var expected = "IX";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void IntToRoman4()
        {
            var input = 58;
            var expected = "LVIII";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void IntToRoman5()
        {
            var input = 1994;
            var expected = "MCMXCIV";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void IntToRoman6()
        {
            var input = 1;
            var expected = "I";
            var result = IntToRoman(input);
            Assert.Equal(expected, result);
        }
    }
}
