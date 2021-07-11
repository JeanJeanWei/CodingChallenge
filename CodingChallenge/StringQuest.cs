using System;
using System.Collections.Generic;
using System.Linq;

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

        public int HammingWeight(uint n)
        {
            var biString = Convert.ToString(n, 2);
            int numOfOnes = 0;
            for (int i = 0; i < biString.Length; i++)
            {
                if (biString[i] == '1')
                {
                    numOfOnes++;
                }
            }
            return numOfOnes;
        }

        public int HammingDistance(int x, int y)
        {
            var biX = Convert.ToString(x, 2);
            var biY = Convert.ToString(y, 2);
            int d = 0;
            if (biX.Length > biY.Length)
            {
                d = CheckDistance(biX, biY);
            }
            else
            {
                d = CheckDistance(biY, biX);
            }
            return d;
        }

        private int CheckDistance(string x, string y)
        {
            int count = 0;
            string zeros = "";
            //Console.WriteLine("x: "+ x + " y: "+y);
            for (int i = 0; i < x.Length - y.Length; i++)
            {
                zeros += "0";
            }
            var newy = zeros + y;
            //Console.WriteLine("x: "+ x + " newy: "+newy);
            for (int i = x.Length - 1; i >= 0; i--)
            {
                //Console.WriteLine("i: "+ i );
                if (newy[i] != x[i])
                {
                    count++;
                }
            }
            return count;
        }

        // 
        public int FirstUniqChar(string s)
        {
            var map = new Dictionary<char, int>();
            char[] cArr = s.ToCharArray();
            for (int i = 0; i < cArr.Length; i++)
            {
                if (map.ContainsKey(cArr[i]))
                {
                    map[cArr[i]] += 1;
                }
                else
                {
                    map[cArr[i]] = 1;
                }
            }
            var u = map.Where(x => x.Value == 1).Select(x => x.Key).ToList();
            if (u.Count == 0)
            {
                return -1;
            }
            int pos = 0;
            bool found = false;
            for (int i = 0; i < cArr.Length; i++)
            {
                var c = cArr[i];
                for (int j = 0; j < u.Count; j++)
                {
                    if (c == u[j])
                    {
                        pos = i;
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            return pos;
        }

        public int[] PlusOne(int[] digits)
        {
            var l = digits.ToList();
            int carry = 0;
            for (int i = l.Count - 1; i >= 0; i--)
            {
                int d = l[i];
                if (i == l.Count - 1)
                {
                    d++;
                }
                else
                {
                    d += carry;
                }
                if (d >= 10)
                {
                    carry = 1;
                    l[i] = d % 10;
                }
                else
                {
                    carry = 0;
                    l[i] = d;
                }
            }
            if (carry == 1)
            {
                l.Insert(0, 1);
            }
            return l.ToArray();
        }

        public string RemoveOuterParentheses(string S)
        {
            Queue<char> q = new Queue<char>();
            string output = String.Empty;

            int c = 0;
            foreach (char p in S)
            {
                if (p == '(')
                {
                    c++;
                    q.Enqueue(p);
                }
                else
                {
                    c--;
                    q.Enqueue(p);
                }

                if (c == 0)
                {
                    q.Dequeue();
                    int n = q.Count;
                    for (int i = 0; i < n - 1; i++)
                    {
                        output = output + q.Dequeue();
                    }
                    q.Dequeue();
                }
            }
            return output;
        }
    }
}
