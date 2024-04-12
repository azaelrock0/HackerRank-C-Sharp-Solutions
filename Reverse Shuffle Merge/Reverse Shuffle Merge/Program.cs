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
using System.Runtime.CompilerServices;

class Result
{

    /*
     * Complete the 'reverseShuffleMerge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string reverseShuffleMerge(string s)
    {
        SortedDictionary<char, int> unused = new SortedDictionary<char, int>();
        SortedDictionary<char, int> used = new SortedDictionary<char, int>();
        SortedDictionary<char, int> required = new SortedDictionary<char, int>();

        foreach (char c in s)
            if (unused.ContainsKey(c))
                unused[c]++;
            else
                unused.Add(c, 1);

        foreach (KeyValuePair<char, int> kvp in unused)
            used.Add(kvp.Key, 0);

        foreach (KeyValuePair<char, int> kvp in unused)
            required.Add(kvp.Key, kvp.Value / 2);

        char[] reverseArray = s.ToCharArray();
        Array.Reverse(reverseArray);
        string reverse = new string(reverseArray);

        List<char> res = new List<char>();

        foreach (char c in reverse)
        {
            unused[c]--;
            if (used[c] < required[c])
            {
                res.Add(c);
                used[c]++;
                while (res.Count > 1 && res[res.Count - 1] < res[res.Count - 2])
                {
                    char temp = res[res.Count - 2];
                    if (unused[temp] + used[temp] - 1 >= required[temp])
                    {
                        res.RemoveAt(res.Count - 2);
                        used[temp]--;
                    }
                    else
                        break;
                }
            }
        }

        string resString = new string(res.ToArray());
        return resString;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = Result.reverseShuffleMerge(s);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
