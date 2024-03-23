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
     * Complete the 'getMaximumMEX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int getMaximumMEX(List<int> arr)
    {
        int n;
        bool exists;
        bool numberExists = false;

        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = i; j < arr[i]; j++)
            {
                if (arr[j] == i)
                {
                    numberExists = true;
                }
                if (numberExists == false)
                {
                    arr[i] = j;
                    break;
                }
            }
            numberExists = false;
        }

        /*for(int i = 1; i < arr.Count; i++){
            /*for(int j = 0; j < arr.Count; j++){
                if(arr[j] > arr[i]){
                    bigger = true;
                }
            }
            if(arr[i-1] < arr[i]){
                arr[i] = arr[i-1] + 1;
            }
        }*/

        for (int i = 0; i <= arr.Count; i++)
        {
            exists = false;
            for (int j = 0; j < arr.Count; j++)
            {
                if (i == arr[j])
                {
                    exists = true;
                    break;
                }
            }
            if (exists == false)
                return i;
        }
        return 0;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < arrCount; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int result = Result.getMaximumMEX(arr);

        Console.WriteLine(result);
        Console.ReadKey();
    }
}