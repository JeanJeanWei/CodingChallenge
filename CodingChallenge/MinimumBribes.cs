using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    /*
     * one person can only bribe the person in front at most twice, the initial queue is the postion is sequencial
     * Approch 1
     * 1. Loop throgh the queue if the value (q[i]) - postion (i) -1 is greater than 2, then "Too chaotic"
     * 2. else loop throgh q from 0 to j where j < i check the if q[j] > q[i] is true. If true bribe happened 
     * bribe count + 1;
     * 
     * Approch 2 (optimized)
     * 1. Loop throgh the queue if the value (q[i]) - postion (i) -1 is greater than 2, then "Too chaotic"
     * 2. since 1 persion q[i] can only bribe at most 2 times, we don't need to loop from 0 in the nested loop, 
     *    j can started from q[i] - 2 provided q[i] >= 0 to reduce the looping length
     */
    public class MinimumBribes
    {
        public MinimumBribes()
        {
        }

        public int CalculateMinBribes(int[] q)
        {
            int n = q.Length;
            int total = 0;
            bool chaotic = false;
            for (int i = 0; i < n; i++)
            {
                int temp = q[i];
                int b = temp - 1 - i;

                if (b > 2)
                {
                    chaotic = true;
                    break;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (q[j] > q[i]) total++;
                    }
                }

            }

            return chaotic ? -1 : total;
        }

        public int OptimizeMinimumBribes(int[] q)
        {

            int n = q.Length;
            int total = 0;
            bool chaotic = false;
            for (int i = 0; i < n; i++)
            {
                int temp = q[i];
                int b = temp - 1 - i;

                if (b > 2)
                {
                    chaotic = true;
                    break;

                }
                else
                {
                    /*since 1 persion can only bribe at most 2 times, we don't need to loop from 0, 
                     * j can started from q[i] - 2 provided q[i] >= 0 to reduce the looping length
                     */
                    int m = (q[i] - 2) > 0 ? q[i] - 2 : 0;
                    //Console.WriteLine(m);
                    for (int j = m; j < i; j++)
                    {
                        if (q[j] > q[i]) total++;
                    }
                }

            }
            return chaotic ? -1 : total;
        }

        public void TestNestedLoopMinBribes(int[]input, string expected)
        {
            Console.WriteLine("TestNestedLoopMinBribes");
            int count = CalculateMinBribes(input);
            string output = count == -1 ? "Too chaotic" : count.ToString();
            Console.WriteLine("output: " + output + "  " + "exp: " + expected);
            bool success = output == expected ? true : false;
            Console.WriteLine(success ? "Success" : "Fail");
        }
        

        public void TestOptimizedLoopMinBribes(int[] input, string expected)
        {
            Console.WriteLine("TestOptimizedLoopMinBribes");
            int count = OptimizeMinimumBribes(input);
            string output = count == -1 ? "Too chaotic" : count.ToString();
            Console.WriteLine("output: " + output + "  " + "exp: " + expected);
            bool success = output == expected ? true : false;
            Console.WriteLine(success ? "Success" : "Fail");
        }


        public void TestCase1()
        {
            int[] t1 = new int[]{ 2, 1, 5, 3, 4};
            string s1 = "3";
            TestNestedLoopMinBribes(t1, s1);

            int[] t2 = new int[] { 2, 5, 1, 3, 4 };
            string s2 = "Too chaotic";
            TestOptimizedLoopMinBribes(t2, s2);

            int[] t3 = new int[] { 5, 1, 2, 3, 7, 8, 6, 4 };
            string s3 = "Too chaotic";
            TestNestedLoopMinBribes(t3, s3);

            int[] t4 = new int[] { 1, 2, 5, 3, 7, 8, 6, 4 };
            string s4 = "7";
            TestOptimizedLoopMinBribes(t4, s4);
        }
    }
}
