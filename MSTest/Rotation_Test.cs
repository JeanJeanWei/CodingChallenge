using System;
using System.Collections.Generic;
using CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class Rotation_Test
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_R(string list, int k, string expected)
        {
            int[] arr1 = Array.ConvertAll(list.Split(','), temp => Convert.ToInt32(temp));
            int[] result = Array.ConvertAll(expected.Split(','), temp => Convert.ToInt32(temp));
            RightRotation rr = new RightRotation();
            rr.RotateUseReverse(arr1, k);
            
            for (int i = 0; i< arr1.Length; i++)
            {
                Assert.AreEqual(result[i], arr1[i]);
            }
            
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                    new object[] { "1,2,3,4,5,6,7",3, "5,6,7,1,2,3,4"},

                };
            }
        }
    }
}
