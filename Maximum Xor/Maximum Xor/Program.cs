using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the maxXor function below.
    static int[] maxXor(int[] arr, int[] queries)
    {
        // solve here
        int[] maxXor = new int[queries.Length];
        int index = 0, xor, max;
        Trie root = new Trie(2);
        foreach (int a in arr)
        {
            InsertToTrie(root, a);
        }
        foreach (int q in queries)
        {
            maxXor[index] = MaxXor(root, q);
            index++;
        }
        return maxXor;

    }

    static void InsertToTrie(Trie root, int inserted)
    {
        Trie currentNode = root;
        for (int i = 31; i >= 0; i--)
        {
            int value = (inserted >> i) & 1;
            if (value == 0)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = new Trie(value);
                }
                currentNode = currentNode.left;
            }
            if (value == 1)
            {
                if (currentNode.right == null)
                {
                    currentNode.right = new Trie(value);
                }
                currentNode = currentNode.right;
            }
        }
    }

    static int MaxXor(Trie root, int q)
    {
        Trie currentNode = root;
        int max = 0;
        for (int i = 31; i >= 0; i--)
        {
            int value = (q >> i) & 1;
            if (value == 0)
            {
                if (currentNode.right == null)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }
            if (value == 1)
            {
                if (currentNode.left == null)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    currentNode = currentNode.left;
                }
            }
            if (currentNode.value == 1)
            {
                max += (int)Math.Pow(2, i);
            }
        }
        return q ^ max;
    }

    class Trie
    {
        public Trie? left { get; set; }
        public Trie? right { get; set; }
        public int value { get; set; }
        public Trie(int value)
        {
            this.value = value;
        }
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int[m];

        for (int i = 0; i < m; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[i] = queriesItem;
        }

        int[] result = maxXor(arr, queries);

        Console.WriteLine(string.Join("\n", result));

        Console.ReadKey();
    }
}
