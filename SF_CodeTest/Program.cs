using System;
using System.Collections.Generic;

namespace SF_CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 2, 7, 11, 15, 2 }, res = new int[2];
            if (num.Length < 2 || num.Length > 100000) Console.WriteLine("length of num beyond the range");
            int target = 4;
            //方法一双循环
            //for (int i = 0; i < num.Length; i++)
            //{
            //    for (int j = i + 1; j < num.Length; j++)
            //    {
            //        if (num[i] + num[j] == target)
            //        {
            //            res[0] = i;
            //            res[1] = j;
            //        }
            //    }
            //}

            //方法二，字典
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (dic.ContainsKey(target - num[i]))
                {
                    res[0] = dic[target - num[i]];
                    res[1] = i;
                }
                else
                    dic.Add(num[i], i);
            }

            Console.WriteLine("The result is {0} and {1}", res[0], res[1]);
        }
    }
}
