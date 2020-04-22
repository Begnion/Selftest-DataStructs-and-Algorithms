using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;


class Client
{
    //回溯算法生成合法括号组合
    static List<string> GenerateList(int n)
    {
        if (n == 0) return null;
        List<string> res = new List<string>();
        StringBuilder track = new StringBuilder();
        Backtrack(n, n, track, res);
        return res;
    }

    static void Backtrack(int left, int right, StringBuilder track, List<string> res)
    {
        if (left > right) return;
        if (left < 0 || right < 0) return;
        if (left == 0 && right == 0)
        {
            res.Add(track.ToString());
            return;
        }
        track.Append('(');
        Backtrack(left-1,right,track,res);
        track.Remove(track.Length - 1, 1);

        track.Append(')');
        Backtrack(left,right-1,track,res);
        track.Remove(track.Length - 1, 1);
    }
    static void Main()
    {
        var t=GenerateList(3);
        foreach (var v in t)
        {
            Console.WriteLine(v);
        }
        Console.Read();
    }
}

