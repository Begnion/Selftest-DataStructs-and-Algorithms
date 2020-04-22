using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //栈的应用，汉诺塔问题
    class Program
    {
        public static void Hanoi(int n, int p1, int p2, int p3)
        {
            if (n == 1)
                Console.WriteLine("圆盘从 " + p1 + " 移到 " + p3);
            else
            {
                Hanoi(n - 1, p1, p3, p2);
                Console.WriteLine("圆盘从 " + p1 + " 移到 " + p3);
                Hanoi(n - 1, p2, p1, p3);
            }
        }

        static void Main(string[] args)
        {
            int j;
            string str;
            Console.Write("请输入圆盘数量： ");
            str = Console.ReadLine();
            j = int.Parse(str);
            Hanoi(j, 1, 2, 3);
            Console.ReadKey();
        }
    }
}


