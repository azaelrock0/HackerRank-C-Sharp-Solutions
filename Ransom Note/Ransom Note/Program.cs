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
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

    public static void checkMagazine(List<string> magazine, List<string> note)
    {
        note.Sort();
        magazine.Sort();

        List<string> words = note.Distinct().ToList();
        Dictionary<int, int> wordsCount = new Dictionary<int, int>();
        bool canReplicate = true;

        int i = 0, j = 0, n1 = 0, n2 = 0;

        foreach (string word in words)
        {
            while (i < note.Count && note[i] == word)
            {
                i++;
                n1++;
            }

            while (j < magazine.Count && magazine[j] != word)
            {
                j++;
            }

            while (j < magazine.Count && magazine[j] == word)
            {
                j++;
                n2++;
            }

            if (n1 > n2)
            {
                canReplicate = false;
                break;
            }

            n1 = 0;
            n2 = 0;
        }

        if (canReplicate)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        List<string> magazine = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<string> note = Console.ReadLine().TrimEnd().Split(' ').ToList();

        Result.checkMagazine(magazine, note);

        Console.ReadKey();
    }
}