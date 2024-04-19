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

    // Complete the triplets function below.
    static long triplets(int[] a, int[] b, int[] c)
    {
        a = a.Distinct().ToArray();
        c = c.Distinct().ToArray();
        b = b.Distinct().ToArray();

        Array.Sort(a);
        Array.Sort(b);
        Array.Sort(c);

        long count = 0, aCount = 0, cCount = 0;

        for (int i = 0; i < b.Count(); i++)
        {
            for (int j = (int)aCount; j < a.Count(); j++)
            {
                if (a[j] <= b[i])
                    aCount++;
                else
                    break;
            }
            for (int j = (int)cCount; j < c.Count(); j++)
            {
                if (c[j] <= b[i])
                    cCount++;
                else
                    break;
            }

            count += aCount * cCount;
        }

        return count;
    }

    static void Main(string[] args)
    {
        string[] lenaLenbLenc = Console.ReadLine().Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        Console.WriteLine(ans);

        Console.ReadKey();
    }
}
