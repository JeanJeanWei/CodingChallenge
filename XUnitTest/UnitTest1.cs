using System;
using Xunit;

using CodingChallenge;
namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            int[] t1 = new int[] { 1, 2, 3, 4, 5 };
            long expected = 9;
            LargestRectangle l = new LargestRectangle();
            long output = l.largestRectangle(t1);
            Assert.Equal(output, expected);
            
        }
    }
}
