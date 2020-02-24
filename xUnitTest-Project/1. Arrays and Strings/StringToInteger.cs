/*

Implement atoi which converts a string to an integer.

The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:

Only the space character ' ' is considered as whitespace character.
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.
Example 1:

Input: "42"
Output: 42
Example 2:

Input: "   -42"
Output: -42
Explanation: The first non-whitespace character is '-', which is the minus sign.
             Then take as many numerical digits as possible, which gets 42.
Example 3:

Input: "4193 with words"
Output: 4193
Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.
Example 4:

Input: "words and 987"
Output: 0
Explanation: The first non-whitespace character is 'w', which is not a numerical 
             digit or a +/- sign. Therefore no valid conversion could be performed.
Example 5:

Input: "-91283472332"
Output: -2147483648
Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
             Thefore INT_MIN (−231) is returned.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static int MyAtoi(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var trim = str.Trim();
            var temp = trim.ToCharArray();
            string valueReturn = "";

            for (int i = 0; i < temp.Length; i++)
            {
                if (i == 0)
                {
                    if (temp[i] == '-' || temp[i] == '+' || Char.IsDigit(temp[i]))
                    {
                        valueReturn += temp[i];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (Char.IsDigit(temp[i]))
                {
                    valueReturn += temp[i];
                }
                else
                {
                    return GetInteger(valueReturn);
                }
            }

            return GetInteger(valueReturn);
        }

        private static int GetInteger(string valueReturn)
        {
            try
            {
                if (string.IsNullOrEmpty(valueReturn))
                {
                    return 0;
                }

                return int.Parse(valueReturn);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (OverflowException)
            {
                if (valueReturn.Substring(0, 1) == "-")
                {
                    return int.MinValue;
                }
                else
                {
                    return int.MaxValue;
                }
            }
        }

        [Fact]
        public static void MyAtoiTest1()
        {
            var input = "42";
            var expected = 42;
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MyAtoiTest2()
        {
            var input = "    -42";
            var expected = -42;
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MyAtoiTest3()
        {
            var input = "4193 with words";
            var expected = 4193;
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MyAtoiTest4()
        {
            var input = "words and 987";
            var expected = 0;
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MyAtoiTest5()
        {
            var input = "-91283472332";
            var expected = -2147483648; // or int.MinValue
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MyAtoiTest6()
        {
            var input = "91283472332";
            var expected = 2147483647; // or int.MaxValue
            var result = MyAtoi(input);
            Assert.Equal(expected, result);
        }
    }
}
