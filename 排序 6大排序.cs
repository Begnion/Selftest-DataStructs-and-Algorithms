using System;

namespace ConsoleApp1
{
    class Program
    {
        //一、插入类排序
        static void InsertSort(int[] a)                //1.直接插入O(n^2)
        {
            int n = a.Length;
            int temp;
            for (int i = 1; i < n; i++)
            {
                temp = a[i];
                int j = i - 1;
                while (j >= 0 && temp < a[j])
                {
                    a[j + 1] = a[j];
                    --j;
                }
                a[j + 1] = temp;
            }
        }
        static void ShellSort(int[] ary)               //2.希尔排序
        {
            int i, j;
            int increment = ary.Length;
            int key;
            while (increment > 1)                       //最后在增量为1并且是执行了情况下停止。
            {
                increment = increment / 3 + 1;          //根据希尔步长公式                                             
                for (i = increment; i < ary.Length; i++)//从[0]开始，对相距增量步长的元素集合进行修改。
                {
                    key = ary[i];
                    //以下和直接插入排序类似。
                    j = i - increment;
                    while (j >= 0)
                    {
                        if (key < ary[j])
                        {
                            int temp = ary[j];
                            ary[j] = key;
                            ary[j + increment] = temp;
                        }
                        j = j - increment;
                    }
                }
            }
        }
        //二、交换类排序
        static void BubbleSort(int[] a)                 //1.冒泡O(n^2)
        {
            int n = a.Length;
            int flag, temp;
            for (int i = n - 1; i >= 1; i--)
            {
                flag = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (a[j - 1] > a[j])
                    {
                        temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                        flag = 1;
                    }
                }
                if (flag == 0)
                    return;
            }
        }
        static void QuickSort(int[] a, int low, int high)//2.快速排序O(nlog2^n)
        {
            int temp;
            int i = low, j = high;
            if (low < high)
            {
                temp = a[low];
                while (i < j)
                {
                    while (i < j && a[j] >= temp) --j;
                    if (i < j)
                    {
                        a[i] = a[j];
                        ++i;
                    }
                    while (i < j && a[i] < temp) ++i;
                    if (i < j)
                    {
                        a[j] = a[i];
                        --j;
                    }
                }
                a[i] = temp;
                QuickSort(a, low, i - 1);
                QuickSort(a, i + 1, high);
            }
        }
        //三、选择类排序
        static void SelectSort(int[] a)                //1.简单选择O(n^2)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (a[k] > a[j])
                        k = j;
                }
                int temp = a[i];
                a[i] = a[k];
                a[k] = temp;
            }
        }
        //四、归并排序O(nlogn)
        static void MergeSort(int[] A, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(A, low, mid);
                MergeSort(A, mid + 1, high);
                int i = low, j = mid + 1;
                int[] temp = new int[20]; int index = 0;
                while (i <= mid && j <= high)
                {
                    if (A[i] <= A[j])
                        temp[index++] = A[i++];
                    else
                        temp[index++] = A[j++];
                }
                while (i <= mid) temp[index++] = A[i++];
                while (j <= high) temp[index++] = A[j++];
                for (int n = 0; n < index; n++)
                {
                    A[low + n] = temp[n];
                }
            }
        }
        
        static void Main(string[] args)
        {
            int[] arr1 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            InsertSort(arr1);
            foreach (var item in arr1)
                Console.Write("{0} ", item); Console.WriteLine();

            int[] arr2 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            BubbleSort(arr2);
            foreach (var item in arr2)
                Console.Write("{0} ", item); Console.WriteLine();

            int[] arr3 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            QuickSort(arr3, 0, arr3.Length - 1);
            foreach (var item in arr3)
                Console.Write("{0} ", item); Console.WriteLine();

            int[] arr4 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            SelectSort(arr4);
            foreach (var item in arr4)
                Console.Write("{0} ", item); Console.WriteLine();

            int[] arr5 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            MergeSort(arr5, 0, arr5.Length - 1);
            foreach (var item in arr5)
                Console.Write("{0} ", item); Console.WriteLine();

            int[] arr6 = { 46, 55, 13, 2, 88, 49, 73, 26, 37 };
            ShellSort(arr6);
            foreach (var item in arr6)
                Console.Write("{0} ", item); Console.WriteLine();
            Console.Read();
        }
    }
}
