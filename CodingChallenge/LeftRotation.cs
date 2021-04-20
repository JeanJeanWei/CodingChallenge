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

        public void TestLooping(int[] input, int[] expected, int d)
        {
            bool success = true;
            int[] output = Looping(input, d);

            Console.WriteLine("Use nested loop time complexity O(ArrayLength*(rotateTimes%ArrayLength)");
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();
        }

        public void TestRecursive(int[] input, int[] expected, int d)
        {
            bool success = true;
            int[] output = Recursive(input, d);

            Console.WriteLine("Use recursive method time complexity O(ArrayLength*(rotateTimes%ArrayLength)");
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();
        }

        public void TestDirectPosition(int[] input, int[] expected, int d)
        {

            Console.WriteLine("Use calculate direct position time complexity O(ArrayLength)");
            bool success = true;
            int[] output = CalculateDirectPosition(input, d);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("output: " + output[i] + "  " + "Expected: " + expected[i]);
                if (output[i] != expected[i])
                {
                    success = false;
                }
            }
            Console.WriteLine(success ? "Success" : "Fail");
            Console.WriteLine();
        }

        public void TestAll(int[]input, int[]expected, int d)
        {

            TestLooping((int[])input.Clone(), expected, d);
            TestRecursive((int[])input.Clone(), expected, d);
            TestRecursive((int[])input.Clone(), expected, d);

        }

        public void TestCase1()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] expected = new int[] { 5, 1, 2, 3, 4 };

            TestAll(input, expected, 4);
        }

        public void TestCase2()
        {
            int[] input = new int[] { 41, 73, 89, 7, 10, 1, 59, 58, 84, 77, 77, 97, 58, 1, 86, 58, 26, 10, 86, 51 };
            int[] exp = new int[] { 77, 97, 58, 1, 86, 58, 26, 10, 86, 51, 41, 73, 89, 7, 10, 1, 59, 58, 84, 77};

            TestAll(input, exp, 10);
        }

    }
}
