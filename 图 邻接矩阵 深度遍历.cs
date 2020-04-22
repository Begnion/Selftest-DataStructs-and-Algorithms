using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //邻接矩阵版DFS
        static void MatrixDFS(int p, int depth, ref bool[] vis,ref int[,] arr)
        {
            vis[p] = true;
            for (int v = 0; v < 5; v++)
            {
                if (vis[v] == false && arr[p, v] != 0)
                {
                    Console.WriteLine("已访问顶点{0}",v);
                    MatrixDFS(v, depth + 1, ref vis, ref arr);
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
                    MatrixDFS(u, 1,ref vis,ref arr);
            }

            Console.Read();
        }
    }
}
