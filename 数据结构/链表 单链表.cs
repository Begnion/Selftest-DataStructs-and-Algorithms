using System;

namespace ConsoleApp1
{
    class Node
    {
        public int data;
        public int np;
        public Node next;

        public Node(int data, int np)
        {
            this.np = np;
            this.data = data;
            this.next = null;
        }
    }

    class Linkedlist
    {
        private Node first;
        private Node last;

        public bool isEmpty()
        {
            return first == null;
        }

        public void Print()
        {
            Node current = first;
            while (current != null)
            {
                Console.WriteLine("{},{}",current.data,current.np);
                current = current.next;
            }
        }

        public void Insert(int data, int np)
        {
            Node newNode=new Node(data,np);
            if (this.isEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }
        }

        public void Delete(Node delNode)
        {
            Node newNode;
            Node temp;
            if (first.data == delNode.data)
                first = first.next;
            else if (last.data==delNode.data)
            {
                newNode = first;
                while (newNode.next!=last)
                {
                    newNode = newNode.next;
                }
                newNode.next = last.next;
                last = newNode;
            }
            else
            {
                newNode = first;
                temp = first;
                while (newNode.data!=delNode.data)
                {
                    temp = newNode;
                    newNode = newNode.next;
                }

                temp.next = delNode.next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
