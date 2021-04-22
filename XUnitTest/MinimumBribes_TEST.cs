using System;
using System.Collections.Generic;
using CodingChallenge;
using Xunit;

namespace XUnitTest
{
    public class MinimumBribes_TEST
    {
        [Theory, MemberData(nameof(SplitData))]
        public void TestNestedLoopMinBribes(string input, string expected)
        {
            MinimumBribes mb = new MinimumBribes();
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int count = mb.CalculateMinBribes(arr);
            string output = count == -1 ? "Too chaotic" : count.ToString();
            Assert.Equal(output, expected);
        }

        [Theory, MemberData(nameof(SplitData))]
        public void TestOptimizedLoopMinBribes(string input, string expected)
        {
            MinimumBribes mb = new MinimumBribes();
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int count = mb.OptimizeMinimumBribes(arr);
            string output = count == -1 ? "Too chaotic" : count.ToString();
            Assert.Equal(output, expected);
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                    new object[] { "2 1 5 3 4", "3"},
                    new object[] { "2 5 1 3 4", "Too chaotic" },
                    new object[] { "5 1 2 3 7 8 6 4", "Too chaotic" },
                    new object[] { "1 2 5 3 7 8 6 4", "7" },
                };
            }
        }
    }
}
