using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

class Client
{
    //动态规划设计：最长递增子序列
    public static int lengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
        }
        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        int res = 0;
        for (int i = 0; i < dp.Length; i++) {
            res = Math.Max(res, dp[i]);
        }
        return res;     //最长上升子序列的长度
    }
    static void Main()
    {
        int[] a = { 10,9,2,5,3,7,101,18};
        Console.WriteLine(lengthOfLIS(a));
        Console.Read();
    }
}

