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
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isValid(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        List<KeyValuePair<char, int>> kvpList = new List<KeyValuePair<char, int>>();

        foreach (char c in s)
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict.Add(c, 1);

        foreach (KeyValuePair<char, int> kvp in dict)
            kvpList.Add(kvp);

        kvpList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));



        int lastNumber = kvpList.First().Value, min, count = 0;

        if (kvpList[0].Value == 1 && s.Length > 1)
        {
            min = kvpList[1].Value;
            count++;
        }
        else
            min = lastNumber;

        foreach (KeyValuePair<char, int> kvp in kvpList)
        {
            if (kvp.Value > min + 1)
                return "NO";

            if (min < kvp.Value)
            {
                count++;
                if (count > 1)
                    return "NO";
            }

            lastNumber = kvp.Value;
        }

        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string s = Console.ReadLine();

        string result = Result.isValid(s);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
