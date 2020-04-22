using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class QueueNode
    {
        public int data;
        public QueueNode next;

        public QueueNode(int data)
        {
            this.data = data;
            next = null;
        }
    };
    class LinklistQueue
    {
        public QueueNode front;
        public QueueNode rear;

        public LinklistQueue() { front = null; rear = null; }

        public bool Enqueue(int value)
        {
            QueueNode node = new QueueNode(value);

            if (rear == null)
                front = node;
            else
                rear.next = node;
            rear = node;
            return true;
        }

        public int Dequeue()
        {
            int value;
            if (front != null)
            {
                if (front == rear) rear = null;
                value = front.data;
                front = front.next;
                return value;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinklistQueue queue = new LinklistQueue();
            int temp;
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(9);
            while (queue.front != null)
            {
                temp = queue.Dequeue();
                Console.WriteLine(temp);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}


