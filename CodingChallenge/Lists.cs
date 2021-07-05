using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class Lists
    {
        public Lists()
        {
        }

        public List<int> UniqueList(List<int> nums)
        {
            // Microsoft documentation about HashSet
            //The HashSet<T> class provides high-performance set operations.
            //A set is a collection that contains no duplicate elements, and whose elements are in no particular order.
            HashSet<int> h = new HashSet<int>(); 

            for(int i=0; i<nums.Count; i++)
            {
                h.Add(nums[i]);
            }
            return h.ToList();
        }
    }
}
