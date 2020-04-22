using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Compare(int[] a, int[] b)
        {
            int l1 = a.Length, l2 = b.Length;
            bool[] flag1 = new bool[l1];
            bool[] flag2 = new bool[l2];
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (flag2[j] == true) continue;
                    if (a[i] == b[j])
                    {
                        flag1[i] = true;
                        flag2[j] = true;
                    }
                }
            }
            for (int i = 0; i < l1; i++)
            {
                if (flag1[i] == false)
                    Console.Write("{0} ", a[i]);
            }
            for (int i = 0; i < l2; i++)
            {
                if (flag2[i] == false)
                    Console.Write("{0} ", b[i]);
            }
        }
        static int Compare(int[] a, int[] b, out int[] res)
        {
            
            var tmpa = a.Except(b).ToArray();
            var tmpb = b.Except(a).ToArray();
            res = new int[tmpa.Length + tmpb.Length];
            tmpa.CopyTo(res, 0);
            tmpb.CopyTo(res, tmpa.Length);
            return res.Length;
        }
        static void Main(string[] args)
        {
            int[] t1 = { 1, 2, 3, 4, 5 };
            int[] t2 = { 4, 5, 6, 7, 8 };
            PerformanceTimer timer = new PerformanceTimer();
            timer.Start();
            Compare(t1, t2);
            timer.Stop();
            Console.Write("{0}", timer.Duration);

            PerformanceTimer timer2 = new PerformanceTimer();
            timer2.Start();
            var count = Compare(t1, t2, out int[] res);
            if(count>0)
                foreach (var n in res)
                    Console.Write(n+" ");
            timer2.Stop();
            Console.Write("{0}", timer2.Duration);

            Console.Read();
        }
    }
}
