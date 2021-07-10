using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class LinkedListQuest2
    {
        public LinkedListQuest2()
        {
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
                Console.WriteLine("s: " + s + " a:" + a);
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
