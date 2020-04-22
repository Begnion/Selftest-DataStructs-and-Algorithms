using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //链表哈希表
    class Node
    {
        public int Val;
        public Node Next;
        public Node(int val)
        {
            this.Val = val;
            this.Next = null;
        }
    }

    class Program
    {
        const int TABLENUM = 7;
        const int MAXNUM = 13;
        static Node[] indextable = new Node[TABLENUM];

        public static void CreatTable(int val)
        {
            Node newnode = new Node(val);
            int hash;
            hash = val % 7;
            Node current = indextable[hash];
            if (current.Next == null) 
                indextable[hash].Next = newnode;
            else
            {
                while (current.Next != null) 
                    current = current.Next;
            }
            current.Next = newnode;
        }
        public static void PrintData(int val)
        {
            Node head;
            int i = 0;
            head = indextable[val].Next;
            Console.Write("   " + val + "：\t");
            while (head != null)
            {
                Console.Write("[" + head.Val + "]-");
                i++;
                if (i % 8 == 7)
                    Console.Write("\n\t");
                head = head.Next;
            }
            Console.WriteLine("\b ");
        }

        public static int Findnum(int num)
        {
            Node ptr;
            int i = 0, hash;
            hash = num % 7;
            ptr = indextable[hash].Next;
            while (ptr != null)
            {
                i++;
                if (ptr.Val == num)
                    return i;
                else
                    ptr = ptr.Next;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            int i, num;
            int[] index = new int[TABLENUM];
            int[] data = new int[MAXNUM];
            Random rand = new Random();
            for (i = 0; i < TABLENUM; i++)
                indextable[i] = new Node(-1);
            Console.Write("原始数据：\n\t");
            for (i = 0; i < MAXNUM; i++)
            {
                data[i] = rand.Next(30) + 1;
                Console.Write("[" + data[i] + "]");
                if (i % 8 == 7)
                    Console.Write("\n\t");
            }
            for (i = 0; i < MAXNUM; i++)
                CreatTable(data[i]);
            Console.WriteLine();
            Console.WriteLine("\n哈希表：");
            for (i = 0; i < TABLENUM; i++)
                PrintData(i);
            while (true)
            {
                Console.Write("请输入要查找的数据(1-30)，结束请输入-1：");
                num = int.Parse(Console.ReadLine());
                if (num == -1)
                    break;
                i = Findnum(num);
                if (i == 0)
                    Console.WriteLine("没有找到 " + num);
                else
                    Console.WriteLine("找到 " + num + "，共找了 " + i + " 次!");
            }
            Console.ReadKey();
        }
    }
}


