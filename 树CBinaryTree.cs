using System;
using System.Collections.Generic;

namespace PersonalLib.CClasses
{
    public enum InsertMode
    {
        Sort,
        Balanced
    }
    public class CBinaryTree<T>
        where T :IComparable
    {
        #region Peoperties
        public CTreeNode<T> Root { get; set; }
        public int Count { get => GetCount(); }
        public int Height { get => GetHeight(); }
        public bool IsFull { get => Full(); }
        #endregion
        #region Constructor
        public CBinaryTree()
        {
            Root = null;
        } 
        public CBinaryTree(T value)
        {
            Root = new CTreeNode<T>(value);
        }
        public CBinaryTree(CTreeNode<T> treeNode)
        {
            Root = treeNode;
        }
        #endregion
        #region Public methods
        public void Insert(T value,InsertMode mode)
        {
            if (Root == null)
                Root = new CTreeNode<T>(value);
            else
                Root.InsertNode(value, mode);
        }
        public List<T> Leaves_Inorder()
        {
            if (Root == null)
                return new List<T>();
            else
                return Root.Inorder();
        }
        public List<T> Leaves_Inorder_NonRec()
        {
            if (Root == null)
                return new List<T>();
            else
                return Root.Inorder_NonRec();
        }
        public List<T> Leaves_Preorder()
        {
            if (Root == null)
                return new List<T>();
            else
                return Root.Preorder();
        }
        public List<T> Leaves_Postorder()
        {
            if (Root == null)
                return new List<T>();
            else
                return Root.Postorder();
        }
        public List<T> Leaves_Level()
        {
            if (Root == null)
                return new List<T>();
            else
                return Root.Level();
        }
        public void Clear()
        {
            Root = null;
        }
        public void Invert()
        {
            if (Root == null)
                return;
            else
                Root.Invert();
        }
        #endregion
        #region Private methods
        int GetCount()
        {
            if (Root == null)
                return 0;
            else
                return Root.Count;
        }
        int GetHeight()
        {
            if (Root == null)
                return 0;
            else
                return Root.Height;
        }
        bool Full()
        {
            if (Root == null)
                return false;
            else
                return Root.IsFull;
        }
        #endregion
    }
    public class CTreeNode<T>
        where T :IComparable
    {
        #region Properties
        public T Value { get; }
        public CTreeNode<T> LeftNode { get; private set; }
        public CTreeNode<T> RightNode { get; private set; }
        public int Count { get => GetCount(); }
        public int Height { get => GetHeight();}
        public bool IsFull { get => Full(); }
        #endregion
        #region Constructor
        public CTreeNode()
        {
            Value = default(T);
            LeftNode = null;
            RightNode = null;
        }
        public CTreeNode(T value)
        {
            Value = value;
            LeftNode = null;
            RightNode = null;
        }
        public CTreeNode(CTreeNode<T> treeNode)
        {
            Value = treeNode.Value;
            LeftNode = treeNode.LeftNode;
            RightNode = treeNode.RightNode;
        }
        #endregion
        #region Public methods
        public void InsertNode(T value,InsertMode mode)
        {
            switch (mode)
            {
                case InsertMode.Sort:
                    Insert_Sort(value);
                    break;
                case InsertMode.Balanced:
                    Insert_Balanced(value);
                    break;
            }
        }
        public List<T> Inorder()
        {
            List<T> nodes = new List<T>();
            if (LeftNode != null)
                nodes.AddRange(LeftNode.Inorder());
            nodes.Add(Value);
            if (RightNode != null)
                nodes.AddRange(RightNode.Inorder());
            return nodes;
        }
        public List<T> Inorder_NonRec()
        {
            Stack<CTreeNode<T>> stack = new Stack<CTreeNode<T>>();
            List<T> nodes = new List<T>();
            var tmp = this;
            while (tmp != null || stack.Count > 0)
            {
                while (tmp != null)
                {
                    stack.Push(tmp);
                    tmp = tmp.LeftNode;
                }
                if (stack.Count > 0)
                {
                    tmp = stack.Pop();
                    nodes.Add(tmp.Value);
                    tmp = tmp.RightNode;
                }
            }
            return nodes;
        }
        public List<T> Preorder()
        {
            List<T> nodes = new List<T>();
            nodes.Add(Value);
            if (LeftNode != null)
                nodes.AddRange(LeftNode.Preorder());
            if (RightNode != null)
                nodes.AddRange(RightNode.Preorder());
            return nodes;
        }
        public List<T> Postorder()
        {
            List<T> nodes = new List<T>();
            if (LeftNode != null)
                nodes.AddRange(LeftNode.Postorder());
            if (RightNode != null)
                nodes.AddRange(RightNode.Postorder());
            nodes.Add(Value);
            return nodes;
        }
        public List<T> Level()
        {
            List<T> nodes = new List<T>();
            Queue<CTreeNode<T>> treeNodes = new Queue<CTreeNode<T>>();
            treeNodes.Enqueue(this);
            while (treeNodes.Count > 0)
            {
                var currentNode = treeNodes.Dequeue();
                nodes.Add(currentNode.Value);
                if (currentNode.LeftNode != null)
                    treeNodes.Enqueue(currentNode.LeftNode);
                if (currentNode.RightNode != null)
                    treeNodes.Enqueue(currentNode.RightNode);
            }
            return nodes;
        }
        public void Invert()
        {
            //if (LeftNode == null && RightNode == null)
            //    return;
            //if (LeftNode == null && RightNode != null)
            //{
            //    LeftNode = new CTreeNode<T>(RightNode);
            //    RightNode = null;
            //    LeftNode.Invert();
            //}
            //else if (RightNode == null && LeftNode != null)
            //{
            //    RightNode = new CTreeNode<T>(LeftNode);
            //    LeftNode = null;
            //    RightNode.Invert();
            //}
            //else
            //{
            //    CTreeNode<T> tmp = new CTreeNode<T>(RightNode);
            //    RightNode = new CTreeNode<T>(LeftNode);
            //    LeftNode = new CTreeNode<T>(tmp);
            //    LeftNode.Invert();
            //    RightNode.Invert();
            //}
            if (LeftNode == null && RightNode == null)
                return;
            CTreeNode<T> tmp = RightNode;
            RightNode = LeftNode;
            LeftNode = tmp;
            if (LeftNode != null)
                LeftNode.Invert();
            if (RightNode != null)
                RightNode.Invert();
        }
        #endregion
        #region Private methods
        int GetCount()
        {
            int count = 1;
            if (LeftNode != null)
                count += LeftNode.Count;
            if (RightNode != null)
                count += RightNode.Count;
            return count;
        }
        int GetHeight()
        {
            int height = 1;
            int hl = 0, hr = 0;
            if (LeftNode != null)
                hl = LeftNode.Height;
            if (RightNode != null)
                hr = RightNode.Height;
            height += Math.Max(hl, hr);
            return height;
        }
        bool Full()
        {
            if (LeftNode == null && RightNode == null)
                return true;
            if (LeftNode == null || RightNode == null)
                return false;
            return LeftNode.IsFull && RightNode.IsFull;
        }
        void Insert_Sort(T value)
        {

            if (value.CompareTo(Value) <= 0)
            {
                if (LeftNode == null)
                    LeftNode = new CTreeNode<T>(value);
                else
                    LeftNode.Insert_Sort(value);
            }
            else
            {
                if (RightNode == null)
                    RightNode = new CTreeNode<T>(value);
                else
                    RightNode.Insert_Sort(value);
            }
        }
        void Insert_Balanced(T value)
        {
            if (LeftNode == null && RightNode != null)
                LeftNode = new CTreeNode<T>(value);
            else if (RightNode == null && LeftNode != null)
                RightNode = new CTreeNode<T>(value);
            else if (LeftNode == null && RightNode == null)
                LeftNode = new CTreeNode<T>(value);
            else if (LeftNode.Height > RightNode.Height)
            {
                if (!LeftNode.IsFull)
                    LeftNode.Insert_Balanced(value);
                else
                    RightNode.Insert_Balanced(value);
            }
            else if(LeftNode.Height==RightNode.Height)
            {
                if (!RightNode.IsFull)
                    RightNode.Insert_Balanced(value);
                else
                    LeftNode.Insert_Balanced(value);
            }
            else if (LeftNode.Height <= RightNode.Height)
                LeftNode.Insert_Balanced(value);
        }
        #endregion
    }
}
