using System;
using System.Collections.Generic;
using System.IO;
using CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class JesseAndCookies_TEST
    {

        static string txtPath = Path.Combine(Environment.CurrentDirectory, "CookiesData1.txt");

        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void TestMethod_DirectCookies(string list, string target, string expected)
        {

            int[] arr1 = Array.ConvertAll(list.Split(' '), temp => Convert.ToInt32(temp));
            int k = Convert.ToInt32(target);
            JesseAndCookies jc = new JesseAndCookies();
            int result = jc.Cookies(k, arr1);
            Assert.AreEqual(expected, result.ToString());
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                string[] testfile1 = File.ReadAllLines(txtPath);
                return new[]
                {

                    new object[] { "1 2 3 9 10 12", "7", "2" },
                    new object[] { "1 1 1", "10", "-1"},
                    new object[] { "13 47 74 12 89 74 18 38", "90", "5" },
                    new object[] { "6214 8543 9266 1150 7498 7209 9398 1529 1032 7384 6784 34 1449 7598 8795 756 7803 4112 298 4967 1261 1724 4272 1100 9373",
                                    "3581", "7"},
                    new object[] { testfile1[2], testfile1[1], testfile1[0]},

                };
            }
        }
    }
}
