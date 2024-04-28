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
     * Complete the 'minimumPasses' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. LONG_INTEGER m
     *  2. LONG_INTEGER w
     *  3. LONG_INTEGER p
     *  4. LONG_INTEGER n
     */

    public static long minimumPasses(long m, long w, long p, long n)
    {
        long passes = 0, candies = 0, multiply;
        if (isOverFlow(m, w))
            return 1;
        while (candies < n)
        {
            decimal production = m * w;
            if (production > 0)
            {
                decimal dMultiply = (Math.Min(p, n) - candies) / production;
                multiply = (long)Math.Ceiling(dMultiply);
            }
            else
                multiply = 1;

            candies += (long)production * multiply;
            passes += multiply;


            long save = getSave(m, w, n, candies);
            long invest = getInvest(ref m, ref w, p, n, ref candies);

            if (save < invest || save == 0)
            {
                passes += save;
                break;
            }



        }
        return passes;
    }

    public static bool isOverFlow(long m, long w)
    {
        if (m == 0 || w == 0)
            return false;

        long result = m * w;
        if (m == result / w)
            return false;
        else
            return true;
    }

    public static long getInvest(ref long m, ref long w, long p, long n, ref long candies)
    {
        if (candies > n)
            return 1;

        long canBuy = candies / p;
        long dif = m - w;
        candies -= canBuy * p;

        if (dif < 0)
            m += Math.Min(canBuy, Math.Abs(dif));
        else
            w += Math.Min(canBuy, dif);

        canBuy -= Math.Min(canBuy, Math.Abs(dif));

        long lower = canBuy / 2;
        long higher = canBuy - lower;
        if (m < w)
        {
            w += lower;
            m += higher;
        }
        else
        {
            m += lower;
            w += higher;
        }


        long production = m * w;
        if (production > 0)
        {
            decimal pending = n - candies;
            long passes = (long)Math.Ceiling(pending / production);
            return passes;
        }
        else
            return 0;

    }

    public static long getSave(long m, long w, long n, long candies)
    {
        decimal production = m * w;
        if (production > 0)
        {
            decimal pending = n - candies;
            long passes = Math.Max((long)Math.Ceiling(pending / production), 0);
            return passes;
        }
        else
            return 0;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        long m = Convert.ToInt64(firstMultipleInput[0]);

        long w = Convert.ToInt64(firstMultipleInput[1]);

        long p = Convert.ToInt64(firstMultipleInput[2]);

        long n = Convert.ToInt64(firstMultipleInput[3]);

        long result = Result.minimumPasses(m, w, p, n);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
