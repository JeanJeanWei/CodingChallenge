using System;
using System.Collections.Generic;
using CodingChallenge.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    public class DoubleLinkedListNode_TEST
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_Reverse(string input, string expected)
        {
            int[] arr1 = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            DoublyLinkedListNode sln = new DoublyLinkedListNode();
            DoublyLinkedListNode head = sln.GenerateDoubleLinkedList(arr1);
            sln.Reverse(head);
            string result = "";
            while (head != null)
            {
                result = result + head.Data.ToString() + " ";
                head = head.Next;
            }
            Assert.AreEqual(result.Trim(), expected);
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                    new object[] { "1 2 3 4 5", "5 4 3 2 1"},
                    new object[] { "1 2 3 7 9 10 20", "20 10 9 7 3 2 1"},
                    new object[] { "2 6 8 9", "9 8 6 2"}
                };
            }
        }
    }
}
