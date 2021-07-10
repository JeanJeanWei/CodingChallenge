using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class ListAndArray_Test
    {
        [DataTestMethod]
        [DynamicData(nameof(Data), DynamicDataSourceType.Property)]
        public void UniqueLists_Test(string list, int expected)
        {
            int[] arr1 = Array.ConvertAll(list.Split(','), temp => Convert.ToInt32(temp));
            var l = arr1.ToList();
            var ls = new ArrayQuest();
            var unique = ls.UniqueList(l);
            Assert.AreEqual(unique.Count, expected);
        }

        public static IEnumerable<object[]> Data
        {
            get
            {
                return new[]
                {
                    new object[] { "1,2,3,4,5,6,7,7,6,5,0", 8},

                };
            }
        }
    }
}

