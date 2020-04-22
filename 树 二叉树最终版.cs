using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class Node<T> where T : IComparable
        {
            public T data { get; }
            public Node<T> lChild;
            public Node<T> rChild;

            public Node()
            {
                data = default(T);
                lChild = null;
                rChild = null;
            }
            public Node(T t)
            {
                data = t;
                lChild = null;
                rChild = null;
            }
            public Node(T t, Node<T> lt, Node<T> rt)
            {
                data = t;
                lChild = lt;
                rChild = rt;
            }
            public void Invert()
            {
                if (lChild == null && rChild == null)
                    return;
                Node<T> temp = rChild;
                rChild = lChild;
                lChild = temp;
                lChild?.Invert();
                rChild?.Invert();
            }
            public int GetCount()
            {
                int count = 1;
                if (lChild != null)
                    count += lChild.GetCount();
                if (rChild != null)
                    count += rChild.GetCount();
                return count;
            }
            public int GetHeight()
            {
                int height = 1;
                int leftH = 0, rightH = 0;
                if (lChild != null)
                    leftH = lChild.GetHeight();
                if (rChild != null)
                    rightH = rChild.GetHeight();
                height += Math.Max(leftH, rightH);
                return height;
            }
            public void PreOrder()
            {
                Console.WriteLine("{0}", data);
                lChild?.PreOrder();
                rChild?.PreOrder();
            }
            public void InOrder()
            {
                lChild?.InOrder();
                Console.WriteLine("{0}", data);
                rChild?.InOrder();
            }
            public void PostOrder()
            {
                lChild?.PostOrder();
                rChild?.PostOrder();
                Console.WriteLine("{0}", data);
            }

            public void AddNodeBST(T t)
            {
                if (t.CompareTo(data) <= 0)
                {
                    if (lChild == null)
                        lChild = new Node<T>(t);
                    else
                        lChild.AddNodeBST(t);
                }
                else
                {
                    if (rChild == null)
                        rChild = new Node<T>(t);
                    else
                        rChild.AddNodeBST(t);
                }
            }

            private void LeftRotation(ref Node<T> father)
            {
                Node<T> temp = father.rChild;
                father.rChild = temp.lChild;
                temp.lChild = father;
                father = temp;
            }

            private void RightRotation(ref Node<T> father)
            {
                Node<T> temp = father.lChild;
                father.lChild = temp.rChild;
                temp.rChild = father;
                father = temp;
            }

            private int GetBalanceFactor(Node<T> node)
            {
                return node.lChild.GetHeight() - node.rChild.GetHeight();
            }

            public void AddNodeAVL(T t)
            {
                Node<T> n = this;
                AddNodeAVL(ref n, t);
            }

            public void AddNodeAVL(ref Node<T> node, T t)
            {
                if (node == null)
                {
                    node = new Node<T>(t);
                    return;
                }

                if (t.CompareTo(node.data) < 0)                         //插入节点比当前节点小
                {
                    AddNodeAVL(ref node.lChild, t);                     //往左子树插入
                    if (node.lChild != null && node.rChild != null)
                    {
                        if (GetBalanceFactor(node) == 2)
                        {
                            if (GetBalanceFactor(node.lChild) == 1) //LL型
                                RightRotation(ref node);
                            else if (GetBalanceFactor(node.lChild) == -1) //LR型
                            {
                                LeftRotation(ref node.lChild);
                                RightRotation(ref node);
                            }
                        }
                    }
                }
                else                                                    //插入节点比当前节点大
                {   
                    AddNodeAVL(ref node.lChild, t);                     //往右子树插入
                    if (node.lChild != null && node.rChild != null)
                    {
                        if (GetBalanceFactor(node) == -2)
                        {
                            if (GetBalanceFactor(node.rChild) == -1) //RR型
                                LeftRotation(ref node);
                            else if (GetBalanceFactor(node.rChild) == 1) //RL型
                            {
                                RightRotation(ref node.rChild);
                                LeftRotation(ref node);
                            }
                        }
                    }
                }
            }

            public void AddNodeRedBlack(T t)
            {

            }
        }

        static void Main(string[] args)
        {
            Node<int> i = new Node<int>(7);
            i.AddNodeBST(9);
            i.AddNodeBST(7);
            i.AddNodeBST(3);
            i.AddNodeBST(2);
            i.AddNodeBST(5);
            i.AddNodeBST(6);
            i.AddNodeBST(2);
            i.AddNodeBST(1);
            i.AddNodeBST(4);

            //Node<int> i = null;
            //i.AddNodeAVL(9);
            //i.AddNodeAVL(2);
            //i.AddNodeAVL(1);
            //i.AddNodeAVL(5);
            //i.AddNodeAVL(6);
            //i.AddNodeAVL(8);
            //i.AddNodeAVL(4);
            i.InOrder();
            Console.ReadKey();
        }
    }
}


