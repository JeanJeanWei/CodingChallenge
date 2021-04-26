using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using CodingChallenge;

namespace XUnitTest
{
    public class MinimumSwaps_TEST
    {

        static string txtPath = Path.Combine(Environment.CurrentDirectory, "MinSwapTest1.txt");

        [Theory, MemberData(nameof(SplitData))]
        public void MinimumSwapsDirect_TEST(string input, string expected)
        {
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            MinimumSwaps ms = new MinimumSwaps();
            int result = ms.MinSwapsDirect(arr);

            Assert.Equal(result.ToString(), expected);
        }

        [Theory, MemberData(nameof(SplitData))]
        public void MinimumSwapsCompare_TEST(string input, string expected)
        {
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            MinimumSwaps ms = new MinimumSwaps();
            int result = ms.MinSwapsCompareToOrderedArray(arr);
            // 7 second for large number 
            Assert.Equal(result.ToString(), expected);
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                string[] testfile1 = File.ReadAllLines(txtPath);
                return new[]
                {
                    new object[] { testfile1[1], testfile1[0]},
                    new object[] { "4 3 1 2", "3"},
                    new object[] { "2 3 4 1 5", "3" },
                    new object[] { "1 3 5 2 4 6 7", "3" }

                };
            }
        }
    }
}
