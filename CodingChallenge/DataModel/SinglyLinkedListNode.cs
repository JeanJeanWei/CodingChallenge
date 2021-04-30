using System;
namespace CodingChallenge.DataModel
{
    public class SinglyLinkedListNode
    {
        private int _data;
        private SinglyLinkedListNode _next;

        public SinglyLinkedListNode()
        {
        }

        public SinglyLinkedListNode(int data)
        {
            _data = data;
        }

        public SinglyLinkedListNode GenerateSinglyLinkedList(int[] arr)
        {
            SinglyLinkedListNode head = null;
            if (arr == null || arr.Length == 0)
                return head;

            
            SinglyLinkedListNode curr = null;

            for (int i = 0; i<arr.Length; i++)
            {
                if (i == 0)
                {
                    head = new SinglyLinkedListNode(arr[i]);
                    curr = head;
                }
                else
                {
                    SinglyLinkedListNode temp = new SinglyLinkedListNode(arr[i]);
                    curr.Next = temp;
                    curr = curr.Next;
                }
            }
            return head;
        }

        

        public int Data   // property
        {
            get { return _data; }   // get method
            set { _data = value; }  // set method
        }

        public SinglyLinkedListNode Next   // property
        {
            get { return _next; }   // get method
            set { _next = value; }  // set method
        }

    }
}
