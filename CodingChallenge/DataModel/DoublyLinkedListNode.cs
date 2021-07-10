using System;
using System.Collections.Generic;

namespace CodingChallenge.DataModel
{
    public class DoublyLinkedListNode
    {
        private int _data;
        private DoublyLinkedListNode _next;
        private DoublyLinkedListNode _prev;

        public DoublyLinkedListNode()
        {
        }

        public DoublyLinkedListNode(int data)
        {
            _data = data;
        }

        public int Data   // property
        {
            get { return _data; }   // get method
            set { _data = value; }  // set method
        }

        public DoublyLinkedListNode Next   // property
        {
            get { return _next; }   // get method
            set { _next = value; }  // set method
        }

        public DoublyLinkedListNode Prev   // property
        {
            get { return _prev; }   // get method
            set { _prev = value; }  // set method
        }

        public DoublyLinkedListNode GenerateDoubleLinkedList(int[] arr)
        {
            DoublyLinkedListNode head = null;
            if (arr == null || arr.Length == 0)
                return head;


            DoublyLinkedListNode curr = null;
            int n = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    head = new DoublyLinkedListNode(arr[i]);
                    curr = head;
                }
                else
                {
                    curr.Next = new DoublyLinkedListNode(arr[i]);
                    curr.Prev = new DoublyLinkedListNode(arr[i-1]);
                    curr = curr.Next;
                }
            }
            return head;
        }

        public DoublyLinkedListNode Reverse(DoublyLinkedListNode head)
        {

            Stack<DoublyLinkedListNode> s = new Stack<DoublyLinkedListNode>();
            DoublyLinkedListNode curr = head;
            while (curr != null)
            {
                s.Push(curr);
                curr = curr.Next;
            }
            int n = s.Count;
            DoublyLinkedListNode newHead = s.Pop();
            newHead.Next = newHead.Prev;
            newHead.Prev = null;

            DoublyLinkedListNode newCurr = newHead;
            for (int i = 0; i < n - 1; i++)
            {
                DoublyLinkedListNode temp = s.Pop();
                temp.Next = temp.Prev;
                newCurr.Next = temp;
                newCurr = newCurr.Next;
                if (i == n - 2)
                {
                    newCurr.Next = null;
                }
            }
            return newHead;
        }
    }
}
