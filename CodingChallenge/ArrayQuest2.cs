﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class ArrayQuest2
    {
        public ArrayQuest2() {}

        public void SetZeroes(int[][] matrix)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;
            var rowList = new HashSet<int>();
            var colList = new HashSet<int>();
            for (int i = 0; i < row; i++)
            {
                // if(rowList.Contains(i))
                // {
                //     continue;
                // }
                for (int j = 0; j < col; j++)
                {
                    // if(colList.Contains(j))
                    // {
                    //     continue;
                    // }
                    if (matrix[i][j] == 0)
                    {
                        rowList.Add(i);
                        colList.Add(j);
                    }
                }
            }

            foreach (var r in rowList)
            {
                for (int i = 0; i < col; i++)
                {
                    matrix[r][i] = 0;
                }
            }

            foreach (var c in colList)
            {
                for (int i = 0; i < row; i++)
                {
                    matrix[i][c] = 0;
                }
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null) return null;

            var map = new Dictionary<string, IList<string>>();

            foreach (string s in strs)
            {
                var temp = s.ToCharArray();
                Array.Sort(temp);

                var a = new string(temp);
                //Console.WriteLine("s: " + s + " a:" + a);
                if (!map.ContainsKey(a))
                {
                    //map.Add(a, new List<string>());
                    map[a] = new List<string>();
                }
                map[a].Add(s);
            }

            return map.Values.ToList();
        }
    }
}
