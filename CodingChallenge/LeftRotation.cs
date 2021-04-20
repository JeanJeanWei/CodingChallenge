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

            int t = d % n;  // reduce circular loop
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

        /*
         * This solution is coming from a big data scientist, O(n) on time complexity a bit out of box from software developer concept
         */
        public int[] CalculateDirectPosition(int[] a, int d)
        {

            int n = a.Length;
            if (n == 1) return a;
            int[] arr = new int[n];
            int t = d % n; // reduce circular loop


            for (int i = 0; i < n; i++)
            {
                int pos = (i + (n - t)) % n;
                //Console.WriteLine(pos);
                arr[pos] = a[i];
            }
            return arr;
        }

        public void TestCase1()
        {
            bool success = true;
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] expected = new int[] { 5, 1, 2, 3, 4 };
           
            int[] output = Looping(input, 4);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("Use nested loop time complexity O(ArrayLength*(rotateTimes%ArrayLength)");
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();

            // reset inputs
            input = new int[] { 1, 2, 3, 4, 5 };
            success = true;
            output = Recursive(input, 4);
            
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("Use recursive method time complexity O(ArrayLength*(rotateTimes%ArrayLength)");
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();

            //reset inputs
            input = new int[] { 1, 2, 3, 4, 5 };
            success = true;
            output = CalculateDirectPosition(input, 4);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("Use calculate direct position time complexity O(ArrayLength)");
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();

        }

    }
}
