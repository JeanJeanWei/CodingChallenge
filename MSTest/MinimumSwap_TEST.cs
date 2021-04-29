using System;
using System.Collections.Generic;
using System.IO;
using CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class MinimumSwap_TEST
    {
        static string txtPath = Path.Combine(Environment.CurrentDirectory, "MinSwapTestData1.txt");

        [Timeout(500)]
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_DirectPosition(string input, string expected)
        {
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            MinimumSwaps ms = new MinimumSwaps();
            int result = ms.MinSwapsDirect(arr);
            //0.015 seconds for array size 100000
            Assert.AreEqual(result.ToString(), expected);
        }


        [Timeout(8000)] // timeout is greater than the direct position method
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_CompareToSortedArray(string input, string expected)
        {
            int[] arr = Array.ConvertAll(input.Split(' '), temp => Convert.ToInt32(temp));
            MinimumSwaps ms = new MinimumSwaps();
            int result = ms.MinSwapsCompareToOrderedArray(arr);
            // 7 seconds for for array size 100000
            Assert.AreEqual(result.ToString(), expected);
        }

        public static IEnumerable<object[]> Data
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
