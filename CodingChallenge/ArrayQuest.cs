using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class ArrayQuest
    {
        public ArrayQuest()
        {
        }

        public List<int> UniqueList(List<int> nums)
        {
            // Microsoft documentation about HashSet
            //The HashSet<T> class provides high-performance set operations.
            //A set is a collection that contains no duplicate elements, and whose elements are in no particular order.
            HashSet<int> h = new HashSet<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                h.Add(nums[i]);
            }
            return h.ToList();
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;

            int currentPos = 0;
            int nextPos = 1;
            while (nextPos < nums.Length)
            {
                if (nums[currentPos] == nums[nextPos])
                {
                    nextPos++;
                }
                else
                {
                    currentPos++;
                    nums[currentPos] = nums[nextPos];
                }
            }
            return currentPos + 1;
        }

        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0 || prices.Length == 1)
                return 0;
            int profit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                {
                    profit += prices[i + 1] - prices[i];
                }
            }
            return profit;
        }

        public void Rotate(int[] nums, int k)
        {

            int n = nums.Length;

            k %= n;

            Reverse(nums, 0, n - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, n - 1);
        }

        private void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }

        // HashSet doesn't contain duplicate
        public bool ContainsDuplicate(int[] nums)
        {
            var noDup = nums.Distinct().ToArray();
            return noDup.Length == nums.Length ? false : true;
        }

        // find single number
        public int SingleNumber(int[] nums)
        {
            var temp = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (temp.Contains(num))
                {
                    temp.Remove(num);
                }
                else
                {
                    temp.Add(num);
                }
            }
            return temp.ElementAt(0);
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var l1 = nums1.ToList();
            l1.Sort();
            var l2 = nums2.ToList();
            l2.Sort();

            int n1 = nums1.Length;
            int n2 = nums2.Length;
            if (n1 > n2)
            {
                return It1(l1, l2);
            }
            else
            {
                return It1(l2, l1);
            }


        }
        public int[] It1(List<int> l1, List<int> l2)
        {
            List<int> output = new List<int>();
            foreach (var num in l2)
            {
                if (l1.Remove(num))
                {
                    output.Add(num);
                }
            }
            return output.ToArray();
        }

        public int MissingNumber(int[] nums)
        {

            if (nums == null || nums.Length == 0) return 0;

            int posTotal = nums.Length;
            int numTotal = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                posTotal += i;
                numTotal += nums[i];
            }
            var diff = posTotal - numTotal;
            return diff;
        }
    }
}
