using System;
namespace CodingChallenge
{
    public class MinimumSwaps
    {
        public MinimumSwaps()
        {
        }
        /*
         * Approach 1: O(N)
         * 1. scann the array, if the the value is not in the right position, swap the value to correct postion
         * 2. else preceed to next postion
         * 
         * Approach 2 O(Nlog(N) + N)
         * 1. Create a sorted array
         * 2. swap the element by comparing to the sorted array posion and value
         * 3. scan the arry to find the correct postion and do the swap 
         *   (in the UnitTest project you can see the time consuming difference if the input array is big)
         * 
         */

        public int MinSwapsDirect(int[] arr)
        {

            int count = 0;
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] != i + 1)
                {
                    int temp = arr[i];
                    //Console.WriteLine("i:" + i + " arr[i]:" + arr[i] + " arr[arr[i]-1]:" + arr[arr[i] - 1]);
                    arr[i] = arr[arr[i] - 1];
                    arr[temp - 1] = temp;
                    count++;
                }
                else
                {
                    i++;
                }
            }
            return count;
        }


        //Time complesity O(nLog(n)+n)
        public int MinSwapsCompareToOrderedArray(int[] arr)
        {

            int count = 0;
            int N = arr.Length;
            int[] temp = new int[N];
            // created a consecutive ordered array O(n)
            for (int i = 0; i < N; i++)
            {
                temp[i] = i + 1;
            }

            //O(nLog(n))
            for (int i = 0; i < N; i++)
            {

                // check if the current element is at the place it supposed to be
                if (arr[i] != temp[i])
                {
                    count++;

                    // scan the arry and swap the current element with the index supposed to be
                    Swap(arr, i, IndexOf(arr, temp[i], i));
                }
            }
            return count;
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        // scann array and skip the already sorted part (i starts from current i + 1 to (length -1))
        private int IndexOf(int[] arr, int ele, int start)
        {
            for (int i = start + 1; i < arr.Length; i++)
            {
                if (arr[i] == ele)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
