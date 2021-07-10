using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class SortingQuest
    {
        public SortingQuest()
        {
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int[] merged = new int[m + n];
            while (k < m + n)
            {
                if (j == n || (nums1[i] < nums2[j] && i < m))
                {

                    merged[k] = nums1[i];
                    i++;
                }
                else
                {
                    merged[k] = nums2[j];
                    j++;
                }
                k++;
            }
            for (int a = 0; a < n + m; a++)
            {
                nums1[a] = merged[a];
            }
        }

        private bool IsBadVersion(int version)
        {
            return true;
        }
        // binary search
        public int FirstBadVersion(int n)
        {
            int low = 0;
            int high = n - 1;
            int mid = low;

            while (low <= high)
            {
                mid = low + (high - low) / 2;
                //Console.WriteLine("mid: " + mid);
                if (IsBadVersion(mid))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }
            return low;
        }

        public int[] TopKFrequent(int[] nums, int k)
        {

            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (!map.ContainsKey(num))
                {
                    map[num] = 1;
                }
                else
                {
                    map[num] += 1;
                }
            }

            var mf = map.OrderByDescending(x => x.Value).Take(k);
            return mf.Select(x => x.Key).ToArray();
        }
    }
}
