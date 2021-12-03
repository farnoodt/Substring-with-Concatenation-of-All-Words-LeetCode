using System;
using System.Collections.Generic;

namespace Substring_with_Concatenation_of_All_Words_LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "barfoothefoobarman";
            string[] words = new string[] { "foo", "bar" };
            Console.WriteLine(String.Join(",",FindSubstring(s,words)));
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            int WLen = words.Length;
            int Size = words[0].Length;
            int SLen = s.Length;

            IList<int> OP = new List<int>();
            Dictionary<string, int> Excpected = new Dictionary<string, int>();

            for (int i = 0; i < WLen; i++)
            {
                if (Excpected.ContainsKey(words[i]))
                    Excpected[words[i]]++;
                else
                    Excpected.Add(words[i], 1);
            }

            if (SLen < Size * WLen)
                return OP;

            Dictionary<string, int> visit = new Dictionary<string, int>();
            for (int i = 0; i < SLen - Size * WLen + 1; i++)
            {
                visit.Clear();
                string tmp = s.Substring(i, Size * WLen);
                int count = 0;
                while (tmp.Length > 0)
                {
                    string W = tmp.Substring(0, Size);
                    if (Excpected.ContainsKey(W) )
                    {
                        if (visit.ContainsKey(W))
                            visit[W]++;
                        else
                            visit.Add(W, 1);
                        tmp = tmp.Substring(Size);
                    }
                    else
                        break;

                    if (visit[W] > Excpected[W])
                    {
                        break;
                    }
                    count++;
                    if (count == WLen)
                        OP.Add(i);
                }
            }
            return OP;
        }
    }
}
