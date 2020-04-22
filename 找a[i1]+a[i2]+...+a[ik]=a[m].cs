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
        //static void Main(string[] args)
        //{
        //    int[] arr = {5, 3, 2, 1, 9, 8, 7, 4, 6, 10};
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        int sum = arr[i];
        //        foreach (var item in Solve(arr, sum, 4)) //最大4个
        //        {
        //            Console.WriteLine(string.Join("+ ", item.Skip(1)));
        //        }
        //    }

        //    Console.Read();
        //}

        //static IEnumerable<IEnumerable<int>> Solve(int[] arr, int sum, int lim, IEnumerable<int> feed = null)
        //{
        //    if (feed == null) feed = new List<int>() {0};
        //    if (feed.Sum() == sum) yield return feed;
        //    if (feed.Count() > lim) yield break;
        //    foreach (int n in arr.Where(x => x + feed.Sum() <= sum && x >= feed.Last()))
        //    {
        //        foreach (var item in Solve(arr, sum, lim, feed.Concat(new int[] {n}))) yield return item;
        //    }
        //}
        //static int k = 4;
        //static List<int> result=new List<int>();
        //static List<int> temp=new List<int>();
        //static void Solve(int[] arr, int sum, int k)
        //{
        //    if (temp.Sum() == sum) result = temp;
        //    if (temp.Count > k) return;
        //    foreach (int n in arr.Where(x => x + temp.Sum() <= sum))
        //    {
        //        temp.Add(n);
        //        foreach (var item in temp)
        //        {
        //            Solve(arr,sum,k);
        //        }
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    int[] arr = { 5, 3, 2, 1, 9, 8, 7, 4, 6, 10 };
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        int sum = arr[i];
        //        Solve(arr,sum,k);
        //        foreach (var item in result)
        //        {
        //            Console.WriteLine(item+" ");
        //        }
        //    }
        //    Console.Read();
        //}



            //// k指定要几个K相加
            //void org(int[] iArray, int start, int m, int k)
            //{
            //    for (int i = 0; i < iArray.Length; i++)
            //    {
            //        //C是相加的次数
            //        int c = 0;
            //        sum = iArray[i];
            //        c++;

            //        str = new StringBuilder();
            //        str.Append(iArray[i]);
            //        indexStr.Add(i);

            //        for (int j = start; j < iArray.Length; j++)
            //        {
            //            if (i != j)
            //            {
            //                sum += iArray[j];
            //                c++;
            //                if (sum == iArray[m])
            //                {
            //                    str.Append("+" + iArray[j]);
            //                    indexStr.Add(j);
            //                    int size = index.Count;
            //                    index.Add(j);

            //                    if (c == k && index.Count() > size)
            //                        list.Add($"{str} = {iArray[m]}");
            //                }
            //                if (sum < iArray[m])
            //                {
            //                    str.Append("+" + iArray[j]);
            //                    indexStr.Add(j);
            //                }
            //                if (sum > iArray[m])
            //                {
            //                    sum -= iArray[j];
            //                    c--;
            //                }
            //            }
            //        }
            //    }
            //}

            //for (int m = 0; m < arr.Length; m++)
            //{
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        // 最后一个参数指定要几个K相加
            //        org(arr, i, m, 4);
            //    }
            //}
            static bool IsSumExist(int[] nums, int count)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    var num = nums[i];
                    var tmp = nums.ToList();
                    tmp.RemoveAt(i);
                    if (IsSumExist(tmp.ToArray(), num, count))
                        return true;
                }
                return false;
            }
            static bool IsSumExist(int[] nums, int sum, int count)
            {
                if (count > nums.Length)
                    return false;
                else if (count == 1 && nums.Length > 0)
                {
                    foreach (var num in nums)
                    {
                        if (num == sum)
                            return true;
                    }
                    return false;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    var num = nums[i];
                    var newSum = sum - num;
                    var tmp = nums.ToList();
                    tmp.RemoveAt(i);
                    if (IsSumExist(tmp.ToArray(), newSum, count - 1))
                        return true;
                }
                return false;
            }

            static void Main(string[] args)
            {
                int[] arr = {-1,3,5,2};
                Console.WriteLine(IsSumExist(arr, 2));
                Console.Read();

            }


        
    }
}


