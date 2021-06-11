using System;
using System.Collections.Generic;

namespace SF_CodeTestQ2
{
    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, int> dict;//用来增删查传过来的key，value
        private LinkedList<int> nums;//双向链表修改或删除容器里的数据
        private Dictionary<int, LinkedListNode<int>> cache; //因为linkedlist删除慢，所以新容器存linkedlistnode

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            dict = new Dictionary<int, int>();
            nums = new LinkedList<int>();
            cache = new Dictionary<int, LinkedListNode<int>>();
        }

        public int Get(int key)
        {
            //缓存hit
            if (dict.ContainsKey(key))
            {
                //nums.Remove(key);// 这里删除的时候linkedlist会先查找key，所以时间复杂度O(n),还得用字典存linkedlist的节点;
                nums.Remove(cache[key]);
                cache[key] = nums.AddLast(key);
                return dict[key];
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            //缓存击中,把击中的数据放到最后
            if (dict.ContainsKey(key))
            {
                nums.Remove(cache[key]);
                cache[key] = nums.AddLast(key);
                dict[key] = value;
            }
            else //cache miss
            {
                //如果达到最大容量,去掉最前面的
                if (nums.Count == _capacity)
                {
                    dict.Remove(nums.First.Value);
                    cache.Remove(nums.First.Value);
                    nums.RemoveFirst();
                    //nums.AddLast(key); //添加新进来的key到容器里
                    dict.Add(key, value);
                    cache.Add(key, nums.AddLast(key));
                }
                else //不是最大容量，直接添加
                {
                    dict.Add(key, value);
                    //nums.AddLast(key);
                    cache.Add(key, nums.AddLast(key));
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache LC = new LRUCache(2);
            string[] arr1 = { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" };
            int[][] arr2 = new int[][] { new int[]  { 2 }, new int[]  { 1, 1 }, new int[]  { 2, 2 }, new int[]  { 1 },
                new int[] { 3, 3 }, new int[] { 2 }, new int[] { 4, 4 }, new int[] { 1 }, new int[] { 3 }, new int[]  { 4 } };
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr1[i] == "put")
                {
                    LC.Put(arr2[i][0], arr2[i][1]);
                    Console.Write("null, ");
                }
                else if (arr1[i] == "get")
                {
                    int res = LC.Get(arr2[i][0]);
                    Console.Write($"{res}, ");
                }
                else
                    Console.Write("null, ");
            }
            Console.ReadKey();
        }
    }
}
