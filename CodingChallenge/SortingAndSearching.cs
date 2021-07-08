using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class SortingAndSearching
    {
        public SortingAndSearching()
        {
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
