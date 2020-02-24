using System;
namespace xUnitTest_Project.TreesandGraphs
{
    public partial class Solution
    {
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;

            for (int r = 0; r < nr; r++)
            {
                for (int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        num_islands++;
                        DepthFirstSearch(grid, r, c);
                    }
                }
            }

            return num_islands;
        }

        private static void DepthFirstSearch(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';
            DepthFirstSearch(grid, r - 1, c);
            DepthFirstSearch(grid, r + 1, c);
            DepthFirstSearch(grid, r, c - 1);
            DepthFirstSearch(grid, r, c + 1);
        }
    }
}
