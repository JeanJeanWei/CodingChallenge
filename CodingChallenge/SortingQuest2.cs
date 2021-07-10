using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class SortingQuest2
    {
        public SortingQuest2() { }
        
        public void SortColors(int[] nums)
        {
            int zero = 0;
            int one = 0;
            int two = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int num = nums[i];
                if (num == 0)
                {
                    zero++;
                }
                else if (num == 1)
                {
                    one++;
                }
                else
                {
                    two++;
                }
            }
            for (int i = 0; i < zero; i++)
            {
                nums[i] = 0;
            }
            for (int i = zero; i < zero + one; i++)
            {
                nums[i] = 1;
            }
            for (int i = zero + one; i < n; i++)
            {
                nums[i] = 2;
            }
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

        public uint ReverseBits(uint n)
        {
            var bitString = Convert.ToString(n, 2);
            var num = bitString.Length;
            var numOfzeros = 32 - num;
            var zeros = "";
            for (int i = 0; i < numOfzeros; i++)
            {
                zeros += "0";
            }
            //Console.WriteLine(zeros+bitString);
            var rv = Reverse(zeros + bitString);
            //var c = rv.TrimStart('0');
            //Console.WriteLine(rv);
            //Console.WriteLine(c);
            var result = Convert.ToUInt32(rv, 2);
            //Console.WriteLine(result);
            return result;
        }

        private string Reverse(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            var cArr = s.ToCharArray();
            while (left < right)
            {
                char temp = cArr[left];
                cArr[left] = cArr[right];
                cArr[right] = temp;
                left++;
                right--;
            }
            return new string(cArr);
        }
    }
}
