using System;
namespace CodingChallenge
{
    public class RightRotation
    {
        public RightRotation()
        {
        }

        public void Rotate(int[] nums, int k)
        {

            int n = nums.Length;
            //int d = k%n; 
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                int pos = (i + k) % n;
                result[pos] = nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                nums[i] = result[i];
            }
        }

        public void RotateUseReverse(int[] nums, int k)
        {

            int n = nums.Length;
            
            k %= n;

            Reverse(nums, 0, n - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, n - 1);
        }

        private void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }
    }
}
