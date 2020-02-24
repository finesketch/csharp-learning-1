/*

Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

Example:

Given array nums = [-1, 2, 1, -4], and target = 1.

The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

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
        public static int ThreeSumClosest(int[] nums, int target)
        {
            int returnValue = int.MaxValue;
            int sumValue = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        var smallest = Math.Abs(target - sum);

                        if (returnValue > smallest)
                        {
                            returnValue = smallest;
                            sumValue = sum;
                        }
                    }
                }
            }

            return sumValue;
        }

        [Fact]
        public static void ThreeSumClosest1()
        {
            var input = new int[] { -1, 2, 1, -4 };
            int target = 1;
            var expected = 2;
            var result = ThreeSumClosest(input, target);
            Assert.Equal(expected, result);
        }
    }
}
