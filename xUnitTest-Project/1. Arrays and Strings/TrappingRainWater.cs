/*

Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

|
|       *
|   *   ** *
| * ** ******
-------------

The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!

Example:

Input: [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static int Trap(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }

            var highest = height.Max();
            int total = 0;
            int start = 0;
            int end = 0;

            for (int i = 1; i < highest + 1; i++)
            {
                // start
                for (int j = 0; j < height.Length; j++)
                {
                    if (height[j] >= i)
                    {
                        start = j;
                        break;
                    }
                }

                // end
                for (int j = height.Length - 1; j > -1; j--)
                {
                    if (height[j] >= i)
                    {
                        end = j;
                        break;
                    }
                }

                // loop
                for (int j = start; j < end; j++)
                {
                    if (height[j] < i)
                    {
                        total++;
                    }
                }
            }

            return total;
        }

        [Fact]
        public static void Trap1()
        {
            var input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var expected = 6;
            var result = Trap(input);
            Assert.Equal(expected, result);
        }
    }
}
