using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

//栈：判断多种括号是否合法
class Client
{
    static char Leftof(char a)
    {
        if (a == ')') return '(';
        if (a == ']') return '[';
        return '{';
    }
    static bool IsValid(string str)
    {
        Stack<char> left=new Stack<char>();
        foreach (var c in str)
        {
            if(c=='('||c=='['||c=='{')
                left.Push(c);
            else
            {
                if (left.Count != 0 && Leftof(c) == left.Peek())
                    left.Pop();
                else
                {
                    return false;
                }
            }
        }
        return left.Count == 0;
    }
    static void Main()
    {
        string s = "[()]{([])}";
        Console.WriteLine(IsValid(s));
        Console.Read();
    }
}

