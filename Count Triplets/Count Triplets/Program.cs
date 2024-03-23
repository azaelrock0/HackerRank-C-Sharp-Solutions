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
using System.Numerics;

class Solution
{

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {
        if (arr.Distinct().ToList().Count() == 1 && r == 1)
        {
            long n = arr.Count;
            return n * (n - 1) * (n - 2) / 6;
        }

        long count = 0;
        Dictionary<long, long> dict1 = new Dictionary<long, long>();
        Dictionary<long, long> dict2 = new Dictionary<long, long>();

        for (int i = 0; i < arr.Count; i++)
        {
            if (!dict1.ContainsKey(arr[i]))
            {
                dict1.Add(arr[i], 0);
            }
            if (!dict1.ContainsKey(arr[i] * r))
            {
                dict1.Add(arr[i] * r, 0);
            }
            if (!dict2.ContainsKey(arr[i]))
            {
                dict2.Add(arr[i], 0);
            }
            if (!dict2.ContainsKey(arr[i] * r))
            {
                dict2.Add(arr[i] * r, 0);
            }

            if (dict2[arr[i]] > 0)
            {
                count += dict2[arr[i]];
            }
            if (dict1[arr[i]] > 0)
            {
                dict2[arr[i] * r] += dict1[arr[i]];
            }
            dict1[arr[i] * r]++;

        }

        return count;
    }

    /*static long countTriplets(List<long> arr, long r)
    {
        if (arr.Distinct().ToList().Count() == 1 && r == 1)
        {
            long n = arr.Count;
            return n * (n - 1) * (n - 2) / 6;
        }

        arr.Sort();


        long count = 0;
        List<KeyValuePair<long, long>> arr2D = new List<KeyValuePair<long, long>>();
        Dictionary<long, long> dict = new Dictionary<long, long>();

        dict.Add(arr[0], 1);

        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] % r != 0)
            {
                continue;
            }
                if (arr[i] == arr[i - 1])
            {
                dict[arr[i]]++;
            }
            else
            {
                dict.Add(arr[i], 1);
            }
        }

        foreach (KeyValuePair<long, long> kvp in dict)
        {
            arr2D.Add(kvp);
        }

        int iLimit = arr2D.Count - 2, jLimit = arr2D.Count - 1, kLimit = arr2D.Count;

        for (int i = 0; i < iLimit; i++)
        {
            long rTimesI = arr2D[i].Key * r;
            if (arr2D[jLimit - 1].Key >= rTimesI)
                for (int j = i + 1; j < jLimit; j++)
                {
                    while(arr2D[j].Key < rTimesI)
                        j++;
                    if (arr2D[j].Key > rTimesI)
                        break;

                    long rTimesJ = arr2D[j].Key * r;
                    if(arr2D[kLimit - 1].Key >= rTimesJ)
                        for (int k = j + 1; k < kLimit; k++)
                        {
                            while (arr2D[k].Key < rTimesJ)
                                k++;
                            if (arr2D[k].Key > rTimesJ)
                                break;
                            else if (arr2D[j].Key == rTimesI && arr2D[k].Key == rTimesJ)
                                count += arr2D[i].Value * arr2D[j].Value * arr2D[k].Value;
                        }
                }
        }
        return count;
    }*/

    static void Main(string[] args)
    {

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        Console.WriteLine(ans);

        Console.ReadKey();
    }
}