using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    public class StringQuest
    {
        public StringQuest()
        {
        }

        public void ReverseString(char[] s)
        {

            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        public int Reverse(int x)
        {

            bool negitive = x < 0 ? true : false;
            if (negitive)
            {
                x = -x;
                if (x < 0) return 0;
            }
            var s = x.ToString();
            Console.WriteLine(s);
            char[] array = s.ToCharArray();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                var temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
            var numString = new string(array);

            Console.WriteLine(numString);
            var num = Int64.Parse(numString);
            //return 0;
            if (num > Int32.MaxValue)
            {
                return 0;
            }
            else
            {

                return negitive ? -(int)num : (int)num;
            }
        }
    }

}
