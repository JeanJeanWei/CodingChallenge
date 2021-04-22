using System;
using System.Collections.Generic;

namespace XUnitTest
{
    public class TwoSum_TEST
    {
        public TwoSum_TEST()
        {
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
