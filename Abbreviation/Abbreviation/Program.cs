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
     * Complete the 'abbreviation' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING a
     *  2. STRING b
     */

    public static string abbreviation(string a, string b)
    {
        int[][] matrix = new int[b.Length + 1][];
        matrix[0] = new int[a.Length + 1];
        matrix[0][0] = 1;

        for (int i = 0; i < a.Length; i++)
            if (char.IsLower(a[i]))
                matrix[0][i + 1] = 1;

        for (int i = 0; i < b.Length; i++)
            matrix[i + 1] = new int[a.Length + 1];

        for (int i = 0; i < b.Length; i++)
            for (int j = 0; j < a.Length; j++)
                if (char.IsUpper(a[j]))
                {
                    if (a[j] == b[i])
                        matrix[i + 1][j + 1] = matrix[i][j];
                }
                else
                {
                    if (char.ToUpper(a[j]) == b[i] && matrix[i][j] == 1)
                        matrix[i + 1][j + 1] = matrix[i][j];
                    else
                        matrix[i + 1][j + 1] = matrix[i + 1][j];
                }

        if (matrix.Last().Last() == 1)
            return "YES";
        else
            return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = Result.abbreviation(a, b);

            Console.WriteLine(result);
        }

        Console.ReadKey();
    }
}
