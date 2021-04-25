using System;
using System.Collections.Generic;
using Xunit;
using CodingChallenge;

namespace XUnitTest
{
    public class BalancedBrackets_TEST
    {
        [Theory, MemberData(nameof(SplitData))]
        public void Balanced_TEST(string input, bool expected)
        { 
            BalancedBrackets bb = new BalancedBrackets();
            bool result = bb.Balanced(input);
            Assert.Equal(result, expected);
        }

        public static IEnumerable<object[]> SplitData
        {
            get
            {
                // Or this could read from a file. :)
                return new[] {



                    new object[] { "{[()]}", true},
                    new object[] { "{[(])}", false },
                    new object[] { "{{[[(())]]}}", true },
                    new object[] { "{{([])}}", true },
                    new object[] { "{{)[](}}", false },
                    new object[] { "{(([])[])[]}", true },
                    new object[] { "{(([])[])[]]}", false },
                    new object[] { "{(([])[])[]}[]", true}

                };
            }
        }
    }

    
}
