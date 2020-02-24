/*

A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.

Return a deep copy of the list.

The Linked List is represented in the input/output as a list of n nodes. Each node is represented as a pair of [val, random_index] where:

val: an integer representing Node.val
random_index: the index of the node (range from 0 to n-1) where random pointer points to, or null if it does not point to any node.
 

Example 1:


Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]
Example 2:


Input: head = [[1,1],[2,1]]
Output: [[1,1],[2,1]]
Example 3:



Input: head = [[3,null],[3,0],[3,null]]
Output: [[3,null],[3,0],[3,null]]
Example 4:

Input: head = []
Output: []
Explanation: Given linked list is empty (null pointer), so return null.
 

Constraints:

-10000 <= Node.val <= 10000
Node.random is null or pointing to a node in the linked list.
Number of Nodes will not exceed 1000.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.LinkedLists
{
    public partial class Solution
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
        static Dictionary<Node, Node> VisitedHash = new Dictionary<Node, Node>();

        public static Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            if (VisitedHash.ContainsKey(head))
            {
                return VisitedHash[head];
            }

            Node node = new Node(head.val);

            VisitedHash.Add(head, node);

            node.next = CopyRandomList(head.next);
            node.random = CopyRandomList(head.random);

            return node;
        }

        [Fact]
        public static void CopyRandomList1()
        {
            // input
            var input = new Node(7);

            input.next = new Node(13);
            input.random = input;

            input.next.next = new Node(11);
            //input.next.random = input.next.next.next.next;

            input.next.next.next = new Node(10);
            input.next.next.random = input.next.next;

            input.next.next.next.next = new Node(1);
            input.next.next.next.random = input;

            input.next.random = input.next.next.next.next;

            // expected
            var expected = new Node(7);

            expected.next = new Node(13);
            expected.random = expected;

            expected.next.next = new Node(11);
            //expected.next.random = expected.next.next.next.next;

            expected.next.next.next = new Node(10);
            expected.next.next.random = expected.next.next;

            expected.next.next.next.next = new Node(1);
            expected.next.next.next.random = expected;

            expected.next.random = expected.next.next.next.next;

            var result = CopyRandomList(input);

            Assert.Equal(expected, result);
        }

    }
}
