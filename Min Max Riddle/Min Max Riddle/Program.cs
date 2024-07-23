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

    // Complete the riddle function below.
    static long[] riddle(long[] arr)
    {
        SortedDictionary<int, long> dictResults = new SortedDictionary<int, long>();
        long[] results = new long[arr.Length];
        int left, right;
        for (int i = 0; i < results.Length; i++)
        {
            results[i] = 0;
        }
        for (int i = 0; i < arr.Length; i++)
        {
            left = i - 1;
            right = i + 1;
            while (left >= 0)
            {
                if (arr[left] < arr[i])
                    break;
                left--;
            }
            while (right < arr.Length)
            {
                if (arr[right] < arr[i])
                    break;
                right++;
            }
            int windowSize = right - left - 1;
            if (arr[i] > results[windowSize - 1])
            {
                results[windowSize - 1] = arr[i];
            }
        }
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (results[i] < results[i + 1])
            {
                results[i] = results[i + 1];
            }
        }
        return results;
    }



    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp))
        ;
        long[] res = riddle(arr);

        Console.WriteLine(string.Join(" ", res));

        Console.ReadKey();
    }
}