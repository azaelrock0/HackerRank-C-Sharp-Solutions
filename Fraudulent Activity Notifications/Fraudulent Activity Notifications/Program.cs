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
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     */

    public static int activityNotifications(List<int> expenditure, int d)
    {
        SortedDictionary<int, int> dNumbers = new SortedDictionary<int, int>();
        int count = 0;
        for (int i = 0; i < d; i++)
        {
            if (dNumbers.ContainsKey(expenditure[i]))
                dNumbers[expenditure[i]]++;
            else
                dNumbers.Add(expenditure[i], 1);

        }

        for (int i = d; i < expenditure.Count; i++)
        {
            float media = Median(dNumbers, d);
            if (expenditure[i] >= Median(dNumbers, d) * 2)
                count++;

            if (dNumbers[expenditure[i - d]] > 1)
                dNumbers[expenditure[i - d]]--;
            else
                dNumbers.Remove(expenditure[i - d]);

            if (dNumbers.ContainsKey(expenditure[i]))
                dNumbers[expenditure[i]]++;
            else
                dNumbers.Add(expenditure[i], 1);

        }

        return count;
    }

    public static float Median(SortedDictionary<int, int> dNumbers, int d)
    {
        int sum = 0;
        KeyValuePair<int, int> lastKvp = new KeyValuePair<int, int>();
        if (d % 2 == 0)
        {
            d /= 2;
            if (dNumbers.First().Value > d)
            {
                return dNumbers.First().Key;
            }
            foreach (KeyValuePair<int, int> kvp in dNumbers)
            {
                sum += kvp.Value;
                if (sum > d)
                {
                    if (sum - kvp.Value == d)
                        return (float)(kvp.Key + lastKvp.Key) / 2;
                    else
                        return kvp.Key;
                }
                lastKvp = kvp;
            }
        }
        else
        {
            d /= 2;
            d++;
            if (dNumbers.First().Value >= d)
            {
                return dNumbers.First().Key;
            }
            foreach (KeyValuePair<int, int> kvp in dNumbers)
            {
                sum += kvp.Value;
                if (sum >= d)
                {
                    return kvp.Key;
                }
            }
        }

        return 0;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}