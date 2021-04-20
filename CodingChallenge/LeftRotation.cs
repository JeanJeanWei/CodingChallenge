using System;
namespace CodingChallenge
{
    /* definition original array is ordered by sequencial interger d is how many times left shifting the int array
     * Approach 1
     * 1. to reduce the circulaer shift repeated, shift frequence should be d % array.Length
     * 2. store the the position 0 value in a temperary place e.g. temp = a[0]
     *    loop through the array from the postion 1, assign a[j-1] = a[j] and assign a[n-1] = temp (inner loop)
     * 3. repeat step 2 -> (d % array.Length) times (outer loop) 
     * 
     * Approach 2
     * 1. to reduce the circulaer shift repeated, shift frequence should be d % array.Length
     * 2. create a method to take array and d % array.Length as parameter
     *    store the the position 0 value in a temperary place e.g. temp = a[0]
     *    loop through the array from the postion 1, assign a[j-1] = a[j] and assign a[n-1] = temp 
     *   
     * 3. in side the method call itself agaain and pass the 2nd parmeter decrease by 1 until the 2nd parameter 
     *    equals to 0 then return
     * 
     * Approach 3 (this is is more like big data scientist solution time complixity O(n)
     * 1. to reduce the circulaer shift repeated, shift frequence should be t (d % array.Length)
     * 2. create a new array with the same input array length 
     * 3. loop through the array and calculated the new position for a[i] then assign newArray[position] value 
     *    new position = (i + (n - t)) % n. e.g a[1,2,3,4,5] left shift 4 times for "1" should move to position (0+(5-4))%n) = 1
     *    ,"4" should move to position (3+(5-4))%5 = 4
     * 
     */
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

            if (d != 0)
            {
                leftRotateByOne(a, d);
            }
            
            return a;
           
        }

        private void leftRotateByOne(int[] a, int d)
        {
            int start = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                a[i-1] = a[i];
            }
            a[a.Length - 1] = start;
            d--;
            if (d != 0)
            {
                leftRotateByOne(a, d);
            }
            return;
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

            TestLooping(DeepClone(input), expected, d);
            TestRecursive(DeepClone(input), expected, d);
            TestDirectPosition(DeepClone(input), expected, d);

        }

        private int[] DeepClone(int[] a)
        {
            int[] newArr = new int[a.Length];
            for(int i=0; i<a.Length; i++)
            {
                newArr[i] = a[i];
            }
            return newArr;
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
