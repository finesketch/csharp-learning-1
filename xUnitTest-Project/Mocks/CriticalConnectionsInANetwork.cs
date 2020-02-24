/*

There are n servers numbered from 0 to n-1 connected by undirected server-to-server connections forming a network where connections[i] = [a, b] represents a connection between servers a and b. Any server can reach any other server directly or indirectly through the network.

A critical connection is a connection that, if removed, will make some server unable to reach some other server.

Return all critical connections in the network in any order.

 

Example 1:



Input: n = 4, connections = [[0,1],[1,2],[2,0],[1,3]]
Output: [[1,3]]
Explanation: [[3,1]] is also accepted.
 

Constraints:

1 <= n <= 10^5
n-1 <= connections.length <= 10^5
connections[i][0] != connections[i][1]
There are no repeated connections.

https://www.geeksforgeeks.org/bridge-in-a-graph/

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
        // Array of lists for Adjacency List Representation  
        static List<int>[] adj;
        int time = 0;

        //*********public static IList<PairInt> CriticalConnections(int V, IList<PairInt> connections)
        public static void CriticalConnections(int V, IList<PairInt> connections)
        {
            // Mark all the vertices as not visited  
            bool[] visited = new bool[V];
            int[] disc = new int[V];
            int[] low = new int[V];
            int[] parent = new int[V];


            // Initialize parent and visited,   
            // and ap(articulation point) arrays  
            for (int i = 0; i < V; i++)
            {
                parent[i] = -1;
                visited[i] = false;
            }

            // Call the recursive helper function to find Bridges  
            // in DFS tree rooted with vertex 'i'  
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    bridgeUtil(i, visited, disc, low, parent);

        }

        // A recursive function that finds and prints bridges  
        // using DFS traversal  
        // u --> The vertex to be visited next  
        // visited[] --> keeps tract of visited vertices  
        // disc[] --> Stores discovery times of visited vertices  
        // parent[] --> Stores parent vertices in DFS tree  
        private static void bridgeUtil(int u, bool[] visited, int[] disc,
                        int[] low, int[] parent)
        {

            // Mark the current node as visited  
            visited[u] = true;

            // Initialize discovery time and low value  
            // ******* disc[u] = low[u] = time++;

            // Go through all vertices aadjacent to this  
            foreach (int i in adj[u])
            {
                int v = i; // v is current adjacent of u  

                // If v is not visited yet, then make it a child  
                // of u in DFS tree and recur for it.  
                // If v is not visited yet, then recur for it  
                if (!visited[v])
                {
                    parent[v] = u;
                    bridgeUtil(v, visited, disc, low, parent);

                    // Check if the subtree rooted with v has a  
                    // connection to one of the ancestors of u  
                    low[u] = Math.Min(low[u], low[v]);

                    // If the lowest vertex reachable from subtree  
                    // under v is below u in DFS tree, then u-v is  
                    // a bridge  
                    if (low[v] > disc[u])
                        Console.WriteLine(u + " " + v);
                }

                // Update low value of u for parent function calls.  
                else if (v != parent[u])
                    low[u] = Math.Min(low[u], disc[v]);
            }
        }
    }

    public class PairInt
    {
        public int First;
        public int Second;
    }
}
