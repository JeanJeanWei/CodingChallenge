using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.DataModel;

namespace CodingChallenge
{
    public class LinkedListQuest
    {

        public LinkedListQuest()
        {
        }

       

        public void DeleteNode(ListNode node)
        {
            var nextNode = node.next;
            node.val = nextNode.val;
            node.next = nextNode.next;
            nextNode.next = null;
            nextNode = null;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int total = 1;
            ListNode curr = head;

            while (curr.next != null)
            {
                total++;
                curr = curr.next;
            }
            //Console.WriteLine(total);
            if (total == 1 && n == 1)
            {
                // Console.WriteLine(1);
                return null;
            }
            curr = head;
            if (total - n - 1 < 0)
            {
                return head.next;
            }
            for (int i = 0; i < total - n - 1; i++)
            {
                curr = curr.next;

            }
            curr.next = curr?.next?.next;
            return head;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            Stack<int> s = new Stack<int>();
            var curr = head;
            while (curr != null)
            {
                s.Push(curr.val);
                curr = curr.next;
            }
            //Console.WriteLine(s.Count);

            ListNode newHead = new ListNode(s.Pop());
            curr = newHead;
            int n = s.Count;
            for (int i = 0; i < n; i++)
            {
                curr.next = new ListNode(s.Pop());
                curr = curr.next;
            }
            return newHead;
        }
    }
}
