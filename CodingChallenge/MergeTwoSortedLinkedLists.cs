using System;
using System.Collections.Generic;
using CodingChallenge.DataModel;

namespace CodingChallenge
{
    public class MergeTwoSortedLinkedLists
    {

        public MergeTwoSortedLinkedLists()
        {
        }

        public SinglyLinkedListNode MergeListsUsePointers(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode curr1 = head1;
            SinglyLinkedListNode curr2 = head2;
            SinglyLinkedListNode newHead;
            SinglyLinkedListNode newCurr;
            if (curr1.Data <= curr2.Data)
            {
                newHead = head1;
                curr1 = curr1.Next;
            }
            else
            {
                newHead = head2;
                curr2 = curr2.Next;
            }
            newCurr = newHead;
            while (curr1 != null || curr2 != null)
            {
                if (curr1 == null)
                {
                    newCurr.Next = curr2;
                    break;
                }
                if (curr2 == null)
                {
                    newCurr.Next = curr1;
                    break;
                }

                if (curr1.Data <= curr2.Data)
                {
                    newCurr.Next = curr1;
                    curr1 = curr1.Next;
                    newCurr = newCurr.Next;
                }

                else
                {
                    newCurr.Next = curr2;
                    curr2 = curr2.Next;
                    newCurr = newCurr.Next;
                }
            }

            return newHead;
        }


        public SinglyLinkedListNode MergeListsUseQueue(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode curr1 = head1;
            SinglyLinkedListNode curr2 = head2;
            Queue<int> s = new Queue<int>();
            if (curr1.Data <= curr2.Data)
            {
                s.Enqueue(curr1.Data);
                curr1 = curr1.Next;
            }
            else
            {
                s.Enqueue(curr2.Data);
                curr2 = curr2.Next;
            }
            while (curr1 != null || curr2 != null)
            {
                if (curr1 == null)
                {
                    while (curr2 != null)
                    {
                        s.Enqueue(curr2.Data);
                        curr2 = curr2.Next;
                    }
                    break;
                }
                if (curr2 == null)
                {
                    while (curr1 != null)
                    {
                        s.Enqueue(curr1.Data);
                        curr1 = curr1.Next;
                    }
                    break;
                }

                if (curr1.Data <= curr2.Data)
                {
                    s.Enqueue(curr1.Data);
                    curr1 = curr1.Next;
                }
                else
                {
                    s.Enqueue(curr2.Data);
                    curr2 = curr2.Next;
                }
            }
            SinglyLinkedListNode newHead = new SinglyLinkedListNode(s.Dequeue());
            SinglyLinkedListNode curr = newHead;
            int n = s.Count;
            for (int i = 0; i < n; i++)
            {
                SinglyLinkedListNode temp = new SinglyLinkedListNode(s.Dequeue());
                curr.Next = temp;
                curr = curr.Next;
            }
            return newHead;
        }

    }
}
