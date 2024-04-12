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
     * Complete the 'commonChild' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static int commonChild(string s1, string s2)
    {
        int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

        for (int i = 0; i < s1.Length + 1; i++)
        {
            matrix[0, i] = 0;
            matrix[i, 0] = 0;
        }

        for (int i = 1; i < s1.Length + 1; i++)
        {
            for (int j = 1; j < s2.Length + 1; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    matrix[i, j] = matrix[i - 1, j - 1] + 1;
                else if (matrix[i - 1, j] > matrix[i, j - 1])
                    matrix[i, j] = matrix[i - 1, j];
                else
                    matrix[i, j] = matrix[i, j - 1];
            }
        }

        return matrix[s1.Length, s2.Length];
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.commonChild(s1, s2);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
