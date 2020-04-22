using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;


class Client
{
    //滑动窗口: 最小覆盖子串
    string minWindow(string s, string t)
    {
        // 记录最短子串的开始位置和长度
        int start = 0, minLen=2147483647;
        int left = 0, right = 0;

        Dictionary<char, int> window = new Dictionary<char, int>();
        Dictionary<char, int> needs = new Dictionary<char, int>();
        foreach (char c in t) needs[c]++;

        int match = 0;

        while (right < s.Length)
        {
            char c1 = s[right];
            if (needs.ContainsKey(c1))
            {
                window[c1]++;
                if (window[c1] == needs[c1])
                    match++;
            }
            right++;

            while (match == needs.Count)
            {
                if (right - left < minLen)
                {
                    // 更新最小子串的位置和长度
                    start = left;
                    minLen = right - left;
                }
                char c2 = s[left];
                if (needs.ContainsKey(c2))
                {
                    window[c2]--;
                    if (window[c2] < needs[c2])
                        match--;
                }
                left++;
            }
        }
        return minLen == 2147483647 ? "" : s.Substring(start, minLen);
    }
    static void Main()
    {
        Console.Read();
    }
}

