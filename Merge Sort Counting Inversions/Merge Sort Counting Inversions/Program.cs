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

class Result
{

    /*
     * Complete the 'countInversions' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    static long count;

    public static long countInversions(List<int> arr)
    {
        count = 0;

        List<int> arr2 = getCount(arr);

        return count;
    }

    static List<int> getCount(List<int> arr)
    {
        int lenght = arr.Count;

        if (lenght == 2)
        {
            if (arr[1] < arr[0])
            {
                count++;
                arr.Sort();
                return arr;
            }
            return arr;
        }
        else if (lenght == 1)
        {
            return arr;
        }

        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        int middle = lenght / 2;

        for (int i = 0; i < middle; i++)
        {
            list1.Add(arr[i]);
        }
        for (int i = middle; i < lenght; i++)
        {
            list2.Add(arr[i]);
        }

        list1 = getCount(list1);
        list2 = getCount(list2);

        List<int> res = new List<int>();
        bool iAdded;
        int index = 0;

        for (int i = 0; i < list1.Count; i++)
        {
            iAdded = false;
            for (int j = index; j < list2.Count; j++)
            {
                if (list1[i] <= list2[j])
                {
                    iAdded = true;
                    res.Add(list1[i]);
                    break;
                }
                else
                {
                    count += list1.Count - i;
                    res.Add(list2[j]);
                    index = j + 1;
                }
            }
            if (!iAdded)
                res.Add(list1[i]);
        }
        for (int i = index; i < list2.Count; i++)
        {
            res.Add(list2[i]);
        }
        return res;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            long result = Result.countInversions(arr);

            Console.WriteLine(result);
        }

        Console.Read();
    }
}