using System;
using System.Collections.Generic;
using Xunit;
using CodingChallenge;

namespace XUnitTest
{
    public class TwoSum_TEST
    {

        [Theory, MemberData(nameof(SplitData))]
        public void TwoSumReturnPositions_TEST(string input, int target, string expected)
        {
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            int[] exp = Array.ConvertAll(expected.Split(' '), temp => Convert.ToInt32(temp));
            TwoSum ts = new TwoSum();
            int[] output = ts.TwoSumReturnPositions(arr, target);
            Assert.True(Array.Exists(output, x=> x == exp[0]));
            Assert.True(Array.Exists(output, x=> x == exp[1]));
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                    new object[] { "2 1 5 3 4", 6, "1 2"},
                    new object[] { "1 2 5 3 7 8 6 4", 3,  "0 1" },
                    new object[] { "3 2 4", 6,  "2 1" },
                    new object[] { "2 7 11 15", 9,  "1 0" },
                };
            }
        }
    }
}
