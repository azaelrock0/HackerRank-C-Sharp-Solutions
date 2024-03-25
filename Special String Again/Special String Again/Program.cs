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

    // Complete the substrCount function below.
    static long substrCount(int n, string s)
    {
        long count = 0;
        int index = 1;
        count += n;
        while (index < n)
        {
            bool repeated = false;
            long length = 1;
            while (index < n)
            {
                if (s[index] == s[index - 1])
                {
                    repeated = true;
                    length++;
                }
                else
                    break;
                index++;
            }
            if (repeated)
                count += length * (length + 1) / 2 - length;

            int left = index - 1;
            int right = index + 1;
            char c = s[left];
            while (right < n && left >= 0)
            {
                if (s[left] == c && s[right] == c)
                    count++;
                else
                    break;
                right++;
                left--;
            }
            index++;
        }
        return count;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
