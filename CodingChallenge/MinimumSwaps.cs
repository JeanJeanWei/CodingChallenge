using System;
namespace CodingChallenge
{
    public class MinimumSwaps
    {
        public MinimumSwaps()
        {
        }

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
        // search through array skiped the already sorted part
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
