using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //数组哈希表：除留余数法取得索引，线性探测法存储数据
    class Program
    {
        const int TABLENUM = 10;
        const int DATANUM = 7;

        public static void PrintData(int[] data, int max)
        {
            Console.Write("\t");
            for (int i = 0; i < max; i++)
                Console.Write("[" + data[i] + "] ");
            Console.WriteLine();
        }
        public static void CreatTable(int num, int[] index)
        {
            int tmp = num % TABLENUM;
            while (true)
            {
                if (index[tmp] == -1)
                {
                    index[tmp] = num;
                    break;
                }
                else
                    tmp = (tmp + 1) % TABLENUM;
            }
        }

        static void Main(string[] args)
        {
            int i;
            int[] index = new int[TABLENUM];
            int[] data = new int[DATANUM];
            Random rand = new Random();
            Console.WriteLine("原始数组值：");
            for (i = 0; i < DATANUM; i++)
                data[i] = rand.Next(20) + 1;
            for (i = 0; i < TABLENUM; i++)
                index[i] = -1;
            PrintData(data, DATANUM);
            Console.WriteLine("哈希表的内容：");
            for (i = 0; i < DATANUM; i++)
            {
                CreatTable(data[i], index);
                Console.Write("  " + data[i] + " =>");
                PrintData(index, TABLENUM);
            }
            Console.WriteLine("完成的哈希表：");
            PrintData(index, TABLENUM);//打印输出最后完成的结果
            Console.ReadKey();
        }
    }
}


