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
     * Complete the 'maximumSum' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. LONG_INTEGER_ARRAY a
     *  2. LONG_INTEGER m
     */

    public static long maximumSum(List<long> a, long m)
    {

        UpperBoundSortedSet<long> results = new UpperBoundSortedSet<long>();
        long max = 0, sum = 0;
        foreach (long l in a)
        {
            sum = (sum + l) % m;

            max = Math.Max(max, sum);
            if (sum < results.Max)
            {
                long min = results.FindUpperBound(sum + 1);
                max = Math.Max(max, sum - min + m);
            }

            results.Add(sum);
        }
        return max;
    }

}

class UpperBoundSortedSet<T> : SortedSet<T>
{

    private ComparerDecorator<T> _comparerDecorator;

    private class ComparerDecorator<T> : IComparer<T>
    {

        private IComparer<T> _comparer;

        public T UpperBound { get; private set; }

        private bool _reset = true;

        public void Reset()
        {
            _reset = true;
        }

        public ComparerDecorator(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            int num = _comparer.Compare(x, y);
            if (_reset)
            {
                UpperBound = y;
            }
            if (num <= 0)
            {
                UpperBound = y;
                _reset = false;
            }
            return num;
        }
    }

    public UpperBoundSortedSet()
        : this(Comparer<T>.Default) { }

    public UpperBoundSortedSet(IComparer<T> comparer)
        : base(new ComparerDecorator<T>(comparer))
    {
        _comparerDecorator = (ComparerDecorator<T>)this.Comparer;
    }

    public T FindUpperBound(T key)
    {
        _comparerDecorator.Reset();
        this.Contains<T>(key);
        return _comparerDecorator.UpperBound;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            long m = Convert.ToInt64(firstMultipleInput[1]);

            List<long> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt64(aTemp)).ToList();

            long result = Result.maximumSum(a, m);

            Console.WriteLine(result);
        }

        Console.ReadKey();
    }
}
