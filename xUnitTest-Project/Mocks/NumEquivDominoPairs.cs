/*

Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] if and only if either (a==c and b==d), or (a==d and b==c) - that is, one domino can be rotated to be equal to another domino.

Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].

 

Example 1:

Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
Output: 1
 

Constraints:

1 <= dominoes.length <= 40000
1 <= dominoes[i][j] <= 9

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
        public int NumEquivDominoPairs(int[][] dominoes)
        {

            if (dominoes.Length == 0 || dominoes[0].Length == 0)
            {
                return 0;
            }

            int total = 0;
            bool matched = false;
            for (int i = 0; i < dominoes.Length; i++)
            {
                for (int ii = 0; ii < dominoes.Length; ii++)
                {
                    for (int j = 0; j < dominoes[i].Length; j++)
                    {
                        var first = dominoes[i][j]; //[1,#]
                        var second = dominoes[ii][j]; // [2,#]

                        if ((dominoes[i][j] == dominoes[ii][j]))
                        {
                            matched = true;
                        }
                    }
                }
                if (matched)
                {
                    total++;
                    matched = false;
                }
            }
            return total;
        }
    }
}
