using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //邻接矩阵类
    class Adjacency
    {
        public static int INFINITE = 99999;
        public int[,] Graph_Matrix;
        public Adjacency(int[,] Weight_Path, int number)
        {
            int i, j;
            int Start_Point, End_Point;
            Graph_Matrix=new int[number,number];
            for (i = 0; i < number; i++)
            {
                for ( j = 0; j < number; j++)
                {
                    if (i != j)
                        Graph_Matrix[i, j] = INFINITE;
                    else
                        Graph_Matrix[i, j] = 0;
                }
            }

            for (i = 0; i < Weight_Path.GetLength(0); i++)
            {
                Start_Point = Weight_Path[i, 0];
                End_Point = Weight_Path[i, 1];
                Graph_Matrix[Start_Point, End_Point] = Weight_Path[i, 2];
            }
        }
    }
    //Dijkstra
    class Dijkstra:Adjacency
    {
        private int[] cost;
        private int[] selected;

        public Dijkstra(int[,] Weight_Path, int number) : base(Weight_Path, number)
        {
            cost=new int[number];
            selected=new int[number];
            for (int i = 0; i < number; i++)
            {
                selected[i] = 0;
            }
        }
    }

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
