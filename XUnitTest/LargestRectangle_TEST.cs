using System;
using Xunit;

using CodingChallenge;
using System.Collections.Generic;

namespace XUnitTest
{
    public class LargestRectangle_TEST
    {
        [Theory, MemberData(nameof(SplitData))]
        public void TestLargestRactangles(string input, long expected)
        {

            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            LargestRectangle l = new LargestRectangle();
            long output = l.largestRectangle(arr);
            Assert.Equal(output, expected);
            
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                new object[] { "1 2 3 4 5", 9 },
                new object[] { "1 3 5 9 11", 18},
                new object[] { "11 11 10 10 10", 50},
                };
            }
        }
    }
}
