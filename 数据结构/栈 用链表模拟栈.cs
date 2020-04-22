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
            stack = new T[size];
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




    //2.链表栈
    class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }
    class StackByLink<T>
    {
        public Node<T> front;
        public Node<T> rear;
        public bool IsEmpty()
        {
            return front == null;
        }
        public void OutputAllStack()
        {
            Node<T> current = front;
            while (current != null)
            {
                Console.Write("[" + current.data + "]");
                current = current.next;
            }
            Console.WriteLine();
        }
        public void Insert(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
        }
        public void Pop()
        {
            Node<T> newNode;
            if (IsEmpty())
            {
                Console.WriteLine("当前为空堆栈");
                return;
            }
            newNode = front;
            while (newNode.next != rear)
                newNode = newNode.next;
            newNode.next = rear.next;
            rear = newNode;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StackByArray<int> stack = new StackByArray<int>(10);
            stack.Push(1);
            stack.Push(3);
            stack.Push(7);
            stack.Push(8);
            stack.Push(4);
            stack.Push(5);
            while (!stack.isEmpty())
                Console.WriteLine("堆栈弹出的顺序为:" + stack.Pop());

            //StackByLink<int> stackL=new StackByLink<int>();
            //stackL.Insert(3);
            //stackL.Insert(2);
            //stackL.Insert(6);
            //stackL.Insert(7);
            //stackL.Insert(9);
            //Console.WriteLine("数据加入后堆栈中的内容:");
            //stackL.OutputAllStack();

            Console.ReadKey();
        }
    }
}


