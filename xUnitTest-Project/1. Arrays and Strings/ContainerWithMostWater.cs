/*
 
Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.

Example:

Input: [1,8,6,2,5,4,8,3,7]
Output: 49

 */

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static int MaxArea(int[] height)
        {
            if (height.Length < 2)
            {
                return 0;
            }

            int maxArea = 0;

            for (int i = 0; i < height.Length; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var first = height[i];
                    var second = height[j];
                    var waterLevel = Math.Min(first, second);
                    var distance = j - i;
                    var area = waterLevel * distance;

                    if (maxArea < area)
                    {
                        maxArea = area;
                    }
                }
            }

            return maxArea;
        }

        [Fact]
        public static void MaxArea1()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var expected = 49;
            var result = MaxArea(input);
            Assert.Equal(expected, result);
        }
    }
}
