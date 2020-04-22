using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //1.数组栈
    class StackByArray<T>
    {
        private T[] stack;
        private int top;

        public StackByArray(int size)
        {
            stack = new T[size]; //建立数组
            top = -1;
        }

        public bool Push(T data)
        {
            if (top >= stack.Length)
            {
                Console.WriteLine("堆栈已满，无法再加入");
                return false;
            }
            stack[++top] = data;
            return true;
        }

        public bool isEmpty()
        {
            return top == -1;
        }

        public T Pop()
        {
            return stack[top--];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int value;
            StackByArray<int> stack = new StackByArray<int>(10);
            Console.WriteLine("请按序输入10个数据：");
            for (int i = 0; i < 10; i++)
            {
                value = int.Parse(Console.ReadLine());
                stack.Push(value);
            }
            Console.WriteLine();
            while (!stack.isEmpty())
                Console.WriteLine("堆栈弹出的顺序为:" + stack.Pop());
            Console.ReadKey();
        }
    }
}


