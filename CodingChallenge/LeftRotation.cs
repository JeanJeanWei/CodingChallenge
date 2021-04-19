using System;
namespace CodingChallenge
{
    public class LeftRotation
    {
        public LeftRotation()
        {
        }

        public int[] Looping(int[] a, int d)
        {
            int n = a.Length;
            if (n <= 1) return a;

            int t = d % n; // remove unnessesay 
            for (int i = 0; i < t; i++)
            {
                int start = a[0];

                for (int j = 1; j < a.Length; j++)
                {
                    a[j - 1] = a[j];
                }
                a[a.Length - 1] = start;
            }
            return a;
        }

        public int[] Recursive(int[] a, int d)
        {

            int n = a.Length;
            if (n == 1) return a;

            int t = d % n;
            for (int i = 0; i < t; i++)
            {
                leftRotateByOne(a, n);
            }
            return a;
        }

        private void leftRotateByOne(int[] a, int n)
        {
            int start = a[0];

            for (int i = 0; i < n - 1; i++)
            {
                a[i] = a[i + 1];
            }
            a[n - 1] = start;
        }

    }
}
