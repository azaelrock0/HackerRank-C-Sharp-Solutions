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

    // Complete the minTime function below.
    static long minTime(long[] machines, long goal)
    {
        Array.Sort(machines);
        long min = 1, max = machines.Last() * goal, mid;

        while (min < max)
        {
            long count = 0;
            mid = (min + max) / 2;
            foreach (long l in machines)
                count += mid / l;
            if (count >= goal)
            {
                max = mid;
            }
            if (count < goal)
                min = mid + 1;
        }

        return min;
    }

    static void Main(string[] args)
    {
        string[] nGoal = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nGoal[0]);

        long goal = Convert.ToInt64(nGoal[1]);

        long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
        ;
        long ans = minTime(machines, goal);

        Console.WriteLine(ans);

        Console.ReadKey();
    }
}
