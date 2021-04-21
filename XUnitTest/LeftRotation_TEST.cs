using System;
using System.Collections.Generic;
using CodingChallenge;
using Xunit;
using Xunit.Extensions;

namespace XUnitTest
{
    public class LeftRotation_TEST
    {
        [Theory, MemberData(nameof(SplitData))]
        public void Recursive_TEST(string input, int d, string expected)
        {
            LeftRotation leftRotation = new LeftRotation();
            
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int[] output = leftRotation.Recursive(arr, d);

            string result = "";
            for (int i = 0; i < output.Length; i++)
            {
                result = result + output[i] + " ";
            }
            Assert.Equal(result.TrimEnd(), expected); 
        }

        [Theory, MemberData(nameof(SplitData))]
        public void Looping_TEST(string input, int d, string expected)
        {
            LeftRotation leftRotation = new LeftRotation();

            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int[] output = leftRotation.Looping(arr, d);

            string result = "";
            for (int i = 0; i < output.Length; i++)
            {
                result = result + output[i] + " ";
            }
            Assert.Equal(result.TrimEnd(), expected);
        }

        [Theory, MemberData(nameof(SplitData))]
        public void DirectPosition_TEST(string input, int d, string expected)
        {
            LeftRotation leftRotation = new LeftRotation();

            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int[] output = leftRotation.CalculateDirectPosition(arr, d);

            string result = "";
            for (int i = 0; i < output.Length; i++)
            {
                result = result + output[i] + " ";
            }
            Assert.Equal(result.TrimEnd(), expected);
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                new object[] { "1 2 3 4 5", 4, "5 1 2 3 4" },
                new object[] { "41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51", 10, "77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77" },
                
                };
            }
        }
    }
}
