using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    /*
     * Given an array of integers and a value, 
     * determine the sum of two integers in the array equal to the given value
     */
    public class TwoSum
    {
        public TwoSum()
        {
        }

        /*
         *  Approach:
         *  1. create a Dictionary or HashSet depending on the return value
         *  2. visit each element in the array and add the element to Dictionary/HashSet
         *     Then, said given value = sum and visited element value = a[i]
         *     we know we want to find (sum - a[i]) in the Dictionary/HashSet
         *  3. iterate the whole arry to get the result    
         */

        public int[] TwoSumReturnPositions(int[] nums, int target)
        {
            Dictionary<int, int> visitedDictionary = new Dictionary<int, int>();

            // create int array for return 
            int[] ret = new int[2];
            // loop through the arry to perform the calculation
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                var e = target - num;
                bool found = visitedDictionary.Values.Contains(e);
                if (found)
                {
                    //Console.WriteLine(i + " " + e);
                    ret[0] = i;
                    var temp = visitedDictionary.FirstOrDefault(x => x.Value == e).Key;
                    ret[1] = temp;
                    break;
                }

                visitedDictionary.Add(i, num);
            }
            return ret;
        }

        public bool TryTwoSumExists(int[] nums, int target)
        {
            HashSet<int> visitedSet = new HashSet<int>();

            bool exist = false;
            // loop through the arry to perform the calculation
            for (int i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                var e = target - num;
                bool found = visitedSet.Contains(e);
                if (found)
                {
                    exist = true;
                    break;
                }

                visitedSet.Add(num);
            }
            return exist;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            // sort
            // pick 2th
            // hash find next
            // skip
            var result = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return result;

            var n = nums.Length;

            Array.Sort(nums);

            var hash = new HashSet<int>(nums);

            for (int i = 0; i < n - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                for (int j = i + 1; j < n - 1; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }
                    int t = 0 - nums[i] - nums[j];
                    if (t > nums[j] && hash.Contains(t))
                    {
                        result.Add(new[] { nums[i], nums[j], t });
                    }
                    else if (t == nums[j] && nums[j + 1] == t)
                    {
                        result.Add(new[] { nums[i], t, t });
                    }
                }
            }
            return result;
        }
    }
}
