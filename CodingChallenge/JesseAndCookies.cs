using System;
namespace CodingChallenge
{
    /*
     *  Hackerrank problem: Jesse and Cookies
     */
    public class JesseAndCookies
    {
        public JesseAndCookies()
        {

        }

        public int Cookies(int k, int[] A)
        {

            Array.Sort(A);
            int i = 0,
            c = A.Length,
            i0 = 0,
            c0 = 0,
            op = 0;
            while ((A[i] < k || A[i0] < k) && (c0 - i0 + c - i) > 1)
            {
                int s1 = i0 == c0 || A[i] <= A[i0] ? A[i++] : A[i0++];
                
                int s2 = i0 == c0 || (i != c && A[i] <= A[i0]) ? A[i++] : A[i0++];

                A[c0++] = s1 + 2 * s2;
                op++;
                if (i == c)
                {
                    i = i0;
                    c = c0;
                    c0 = i0;
                }
            }

            return c - i > 1 || A[i] >= k ? op : -1;
        }
    }
}
