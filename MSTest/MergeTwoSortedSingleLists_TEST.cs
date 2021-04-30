using System;
using System.Collections.Generic;
using CodingChallenge;
using CodingChallenge.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class MergeTwoSortedSingleLists_TEST
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_Queue(string list1, string list2, string expected)
        {
            int[] arr1 = Array.ConvertAll(list1.Split(' '), temp => Convert.ToInt32(temp));
            int[] arr2 = Array.ConvertAll(list2.Split(' '), temp => Convert.ToInt32(temp));
            SinglyLinkedListNode sln = new SinglyLinkedListNode();
            SinglyLinkedListNode head1 = sln.GenerateSinglyLinkedList(arr1);
            SinglyLinkedListNode head2 = sln.GenerateSinglyLinkedList(arr2);

            MergeTwoSortedLinkedLists mts = new MergeTwoSortedLinkedLists();
            SinglyLinkedListNode merged = mts.MergeListsUseQueue(head1, head2);
            string result = "";
            while (merged != null)
            {
                result = result + merged.Data.ToString() + " ";
                merged = merged.Next;
            }
            Assert.AreEqual(result.Trim(), expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_Pointers(string list1, string list2, string expected)
        {
            int[] arr1 = Array.ConvertAll(list1.Split(' '), temp => Convert.ToInt32(temp));
            int[] arr2 = Array.ConvertAll(list2.Split(' '), temp => Convert.ToInt32(temp));
            SinglyLinkedListNode sln = new SinglyLinkedListNode();
            SinglyLinkedListNode head1 = sln.GenerateSinglyLinkedList(arr1);
            SinglyLinkedListNode head2 = sln.GenerateSinglyLinkedList(arr2);

            MergeTwoSortedLinkedLists mts = new MergeTwoSortedLinkedLists();
            SinglyLinkedListNode merged = mts.MergeListsUsePointers(head1, head2);
            string result = "";
            while (merged != null)
            {
                result = result + merged.Data.ToString() + " ";
                merged = merged.Next;
            }
            Assert.AreEqual(result.Trim(), expected);
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                    new object[] { "4 5 6", "1 2 10", "1 2 4 5 6 10"},
                    new object[] { "1 2 3", "3 4", "1 2 3 3 4" },

                };
            }
        }
    }
}
