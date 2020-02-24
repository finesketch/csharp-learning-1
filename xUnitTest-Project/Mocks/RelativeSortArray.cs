/*

Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1.

Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2.  Elements that don't appear in arr2 should be placed at the end of arr1 in ascending order.

 

Example 1:

Input: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
Output: [2,2,2,1,4,3,3,9,6,7,19]
 

Constraints:

arr1.length, arr2.length <= 1000
0 <= arr1[i], arr2[i] <= 1000
Each arr2[i] is distinct.
Each arr2[i] is in arr1.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.Mocks
{
    public partial class Solution
    {
        List<int> results = new List<int>();
        List<int> notFound = new List<int>();


        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        results.Add(arr1[j]);
                    }
                }
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                //var item = results.Find(x => x == arr1[i]);
                bool isInList = results.IndexOf(arr1[i]) != -1;

                if (!isInList)
                {
                    notFound.Add(arr1[i]);
                }
            }

            notFound.Sort();

            return results.Concat(notFound).ToArray();
        }
    }
}
