/*

Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length >= 2)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if ((nums[i] + nums[j]) == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }

            throw new Exception("No two sum solution");
        }

        [Fact]
        public static void TwoSumTest1()
        {
            var input = new int[] { 2, 7, 11, 15};
            int inputTarget = 9;
            var expected = new int[] { 0, 1 }; ;
            var result = TwoSum(input, inputTarget);
            Assert.Equal(expected, result);
        }
    }
}
