/*



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
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var lists = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            if (!IsExisting(lists, nums[i], nums[j], nums[k]))
                            {
                                var newList = new List<int>() { nums[i], nums[j], nums[k] };
                                newList.Sort();
                                lists.Add(newList);
                            }
                        }
                    }
                }
            }

            return lists;
        }

        private static bool IsExisting(IList<IList<int>> lists, int first, int second, int third)
        {
            foreach (var list in lists)
            {
                var newList = new List<int>(list);

                newList.Remove(first);
                newList.Remove(second);
                newList.Remove(third);

                if (!newList.Any())
                {
                    return true;
                }

                //if (newList.Remove(first))
                //{
                //    if (newList.Remove(second))
                //    {
                //        if (newList.Remove(third))
                //        {
                //            return true;
                //        }
                //        else
                //        {
                //            return false;
                //        }
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else
                //{
                //    return false;
                //}
            }

            return false;
        }

        [Fact]
        public static void ThreeSum1()
        {
            var input = new int[] { -1, 0, 1, 2, -1, -4 };
            var expected = new int[2][];
            expected[0] = new int[] { -1, 0, 1 };
            expected[1] = new int[] { -1, -1, 2 };
            var result = ThreeSum(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void ThreeSum2()
        {
            var input = new int[] { 4, -9, -13, -9, 0, -12, 12, -14, 12, 1, 3, 5, 5, 8, 2, -2, 8, 1, 2, -6, -6, 1, 6, -15, -2, 7, -11, 3, -2, 1, 11, 10, 8, 14, 8, -15, 9, 5, -14, 6, 14, -3, -12, 4, -10, 5, -12, 13, 14, -3, -15, -7, 5, -2, -15, 10, -10, 11, -2, -5, -2, -5, -10, 13, -14, 14, 13, 2, 4, 7, -6, 3, 11, -3, -15, -14, 10, 10, 6, 1, -8, -2, 1, 12, 11, 1, 7, 8, -10, 13, -11, 3, -15, -6, -7, 8, -7, 13, -5, 5, -3, 4, -15, -7, 9, -15, -14, -4, 2, 0, 4, 9, 13, -10, -2, 10 };
            var expected = new int[2][];
            expected[0] = new int[] { -1, 0, 1 };
            expected[1] = new int[] { -1, -1, 2 };
            var result = ThreeSum(input);
            Assert.Equal(6369, result.Count());
        }

        [Fact]
        public static void ThreeSum3()
        {
            var input = new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 };
            var expected = new int[6][];
            expected[0] = new int[] { -4, -2, 6 };
            expected[1] = new int[] { -4, 0, 4 };
            expected[2] = new int[] { -4, 1, 3 };
            expected[3] = new int[] { -4, 2, 2 };
            expected[4] = new int[] { -2, -2, 4 };
            expected[5] = new int[] { -2, 0, 2 };
            var result = ThreeSum(input);
            Assert.Equal(expected, result);
        }
    }
}
