/*

Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

Example:

Input:
[
  1->4->5,
  1->3->4,
  2->6
]
Output: 1->1->2->3->4->4->5->6

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.LinkedLists
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0 || lists[0] == null)
            {
                return null;
            }
            else if (lists.Length == 1)
            {
                return lists[0];
            }

            ListNode list = new ListNode(lists[0].val);

            for (int i = 0; i < lists.Length - 1; i++)
            {
                list = MergeTwoLists(lists[i], lists[i + 1]);
            }

            return list;
        }
    }
}
