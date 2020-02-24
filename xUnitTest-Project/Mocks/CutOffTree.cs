/*

You are asked to cut off trees in a forest for a golf event. The forest is represented as a non-negative 2D map, in this map:

0 represents the obstacle can't be reached.
1 represents the ground can be walked through.
The place with number bigger than 1 represents a tree can be walked through, and this positive number represents the tree's height.
 

You are asked to cut off all the trees in this forest in the order of tree's height - always cut off the tree with lowest height first. And after cutting, the original place has the tree will become a grass (value 1).

You will start from the point (0, 0) and you should output the minimum steps you need to walk to cut off all the trees. If you can't cut off all the trees, output -1 in that situation.

You are guaranteed that no two trees have the same height and there is at least one tree needs to be cut off.

Example 1:

Input: 
[
 [1,2,3],
 [0,0,4],
 [7,6,5]
]
Output: 6
 

Example 2:

Input: 
[
 [1,2,3],
 [0,0,0],
 [7,6,5]
]
Output: -1
 

Example 3:

Input: 
[
 [2,3,4],
 [0,0,5],
 [8,7,6]
]
Output: 6
Explanation: You started from the point (0,0) and you can cut off the tree in (0,0) directly without walking.
 

Hint: size of the given matrix will not exceed 50x50.

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
        public static int CutOffTree(IList<IList<int>> forest)
        {
            var f = forest.Select(x => x.ToArray()).ToArray();
            if (f[0][0] == 0)
            {
                return -1;
            }

            List<(int x, int y, int t)> trees = new List<(int, int, int)>();
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    if (f[i][j] > 1)
                    {
                        trees.Add((i, j, f[i][j]));
                    }
                }
            }

            trees = trees.OrderBy(x => x.t).ToList();
            int steps = 0;
            int fromx = 0, fromy = 0;
            f[fromx][fromy] = 1;

            foreach (var tree in trees)
            {
                int currentStep = findMinSteps(f, (fromx, fromy), (tree.x, tree.y));
                if (currentStep == -1)
                {
                    return -1;
                }

                fromx = tree.x;
                fromy = tree.y;

                // cut the tree
                f[fromx][fromy] = 1;
                steps += currentStep;
            }

            return steps;
        }


        private static int findMinSteps(int[][] f, (int x, int y) start, (int x, int y) end)
        {

            Queue<(int, int)> q = new Queue<(int, int)>();
            int[,] directions = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
            bool[,] visited = new bool[f.Length, f[0].Length];

            q.Enqueue(start);
            visited[start.x, start.y] = true;
            int walks = 0;

            while (q.Count > 0)
            {
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    (int x, int y) = q.Dequeue();
                    if (x == end.x && y == end.y)
                    {
                        return walks;
                    }

                    int h = f[x][y];

                    for (int d = 0; d < directions.GetLength(0); d++)
                    {
                        int newx = x + directions[d, 0];
                        int newy = y + directions[d, 1];

                        if (newx >= 0 && newy >= 0 && newx < f.Length && newy < f[0].Length
                           && !visited[newx, newy]
                           && f[newx][newy] != 0)
                        {
                            visited[newx, newy] = true;
                            q.Enqueue((newx, newy));
                        }
                    }
                }
                walks++;
            }

            return -1;
        }
    }
}
