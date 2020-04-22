using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        bool Find(int[] arr)
        {
            Array.Sort(arr);
            int i, j, k;
            for (k = arr.Length-1; k >= 2; k--)
            {
                for (i = 0, j = arr.Length - 1; i <= j;)
                {
                    if (arr[k] > arr[i] + arr[j]) i++;
                    else if (arr[k] < arr[i] + arr[j]) j--;
                    else return true;
                }//O(n^2)
            }
            return false;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
