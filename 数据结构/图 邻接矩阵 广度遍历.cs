using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //邻接矩阵版BFS
        static void MatrixBFS(int p, int depth, ref bool[] vis,ref int[,] arr)
        {
            Queue<int> q=new Queue<int>();
            q.Enqueue(p);
            vis[p] = true;
            while (q.Count != 0)
            {
                int f = q.Dequeue();
                for (int v = 0; v < 5; v++)
                {
                    if (vis[v] == false && arr[f, v] != 0)
                    {
                        q.Enqueue(v);
                        vis[v] = true;
                        Console.WriteLine("结点{0}已访问",v);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n = 5;  //五个顶点
            int[,] data =
            {
                {0, 1}, {1, 0}, {0, 4}, {4, 0}, {1, 2}, {2, 1}, {1, 3}, {3, 1}, {2, 3}, {3, 2}, {2, 4}, {4, 2}, {3, 4},
                {4, 3}
            };
            //邻接矩阵
            int[,] arr = new int[5, 5];
            bool[] vis = new bool[5];
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        int tempi = data[i, 0];
                        int tempj = data[i, 1];
                        arr[tempi, tempj] = 1;
                    }
                }
            }

            for (int u = 0; u < n; u++)
            {
                if (vis[u] == false)
                    MatrixBFS(u, 1,ref vis,ref arr);
            }

            Console.Read();
        }
    }
}
