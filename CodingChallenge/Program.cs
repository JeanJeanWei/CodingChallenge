using System;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            LeftRotation leftRotation = new LeftRotation();
            int[] output = leftRotation.Looping(input, 4);
            for(int i=0; i<output.Length; i++)
            {

                Console.WriteLine(output[i]);
            }
        }


    }
}
