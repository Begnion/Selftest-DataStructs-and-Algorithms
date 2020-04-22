using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*1. 两数之和
    给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

    你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

    示例:

    给定 nums = [2, 7, 11, 15], target = 9

    因为 nums[0] + nums[1] = 2 + 7 = 9
    所以返回 [0, 1]             */

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

        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (Findnum(complement)!=0 && Findnum(complement)!= i)
                {
                    return new int[] { i, Findnum(complement) };
                }
            }
            return new int[] { 0, 0 };
        }

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
            int[] data = new int[] {2, 7, 11, 15};


            for (i = 0; i < TABLENUM; i++)
                indextable[i] = new Node(-1);
            for (i = 0; i < 4; i++)
                CreatTable(data[i]);
            var a = TwoSum(data, 9);
            Console.WriteLine("[{0},{1}]",a[0],a[1]);
            
            for (i = 0; i < 4; i++)
                CreatTable(data[i]);
            Console.WriteLine();
            Console.WriteLine("\n哈希表：");
            for (i = 0; i < TABLENUM; i++)
                PrintData(i);

            Console.ReadKey();
        }
    }
}
