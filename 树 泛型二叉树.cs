using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructor
{
    public class Node<T>
        where T:IComparable
    {
        T data;
        Node<T> lChild;
        Node<T> rChild;
        public Node()
        {

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
        /// <summary>
        /// 表示当前节点存放的数据。
        /// </summary>
        public T Data { get { return data; } set { data = value; } }
        public Node<T> LChild { get { return lChild; } set { lChild = value; } }
        public Node<T> RChild { get { return rChild; } set { rChild = value; } }
        public void PreOrder(Node<T> root)
        {
            if (root == null) { return; }
            Console.WriteLine("{0}", root.Data);
            PreOrder(root.LChild);
            PreOrder(root.RChild);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void InOrder(Node<T> root)
        {
            if (root == null) { return; }
            InOrder(root.LChild);
            Console.WriteLine("{0}", root.Data);
            InOrder(root.RChild);
        }
        public void PostOrder(Node<T> root)
        {
            if (root == null) { return; }
            PostOrder(root.LChild);
            PostOrder(root.RChild);
            Console.WriteLine("{0}", root.Data);
        }
        public void Insert(T newItem)
        {
            if (data == null)
                data = newItem;          
            else {
                int res = data.CompareTo(newItem);
                if (res < 0)
                {
                    if (this.LChild == null)
                        this.LChild = new Node<T>() { Data = newItem };
                    else
                        LChild.Insert(newItem);                    
                }
                else
                {
                    if (this.RChild == null)
                        this.RChild = new Node<T>() { Data = newItem };
                    else
                        RChild.Insert(newItem);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var tree = new Node<int>() { Data = 0 };
        }
    }
}
