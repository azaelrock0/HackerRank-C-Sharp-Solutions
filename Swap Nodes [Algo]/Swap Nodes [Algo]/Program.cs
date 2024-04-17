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
     * Complete the 'swapNodes' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY indexes
     *  2. INTEGER_ARRAY queries
     */

    public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
    {
        Tree tree = new Tree();
        tree.fillTree(indexes);
        List<List<int>> res = new List<List<int>>();
        foreach (int k in queries)
        {
            res.Add(tree.swap(k));
        }

        return res;
    }

}

class Tree
{
    public int value;
    public int level;
    public Tree left;
    public Tree right;

    public void fillTree(List<List<int>> indexes)
    {
        value = 1;
        level = 1;
        List<Tree> trees = new List<Tree>();
        left = new Tree();
        right = new Tree();
        left.value = indexes[0][0];
        left.level = 2;
        right.value = indexes[0][1];
        right.level = 2;

        if (left.value != -1)
            trees.Add(left);
        if (right.value != -1)
            trees.Add(right);

        int currentLevel = 3;
        int i = 1;
        while (i < indexes.Count)
        {
            foreach (Tree t in trees)
            {
                t.left = new Tree();
                t.right = new Tree();
                t.left.value = indexes[i][0];
                t.left.level = currentLevel;
                t.right.value = indexes[i][1];
                t.right.level = currentLevel;
                i++;
            }
            currentLevel++;
            trees = fillList(trees);
        }
    }

    public List<Tree> fillList(List<Tree> trees)
    {
        List<Tree> temp = new List<Tree>();
        foreach (Tree t in trees)
        {
            if (t.left.value != -1)
                temp.Add(t.left);
            if (t.right.value != -1)
                temp.Add(t.right);
        }
        return temp;
    }

    public List<int> swap(int k)
    {
        List<int> result = new List<int>();
        result = inOrder(this, k, result);
        return result;
    }

    public List<int> inOrder(Tree t, int k, List<int> result)
    {
        if (t.level % k == 0)
        {
            Tree temp = t.left;
            t.left = t.right;
            t.right = temp;
        }
        if (t.left.value != -1)
            result = inOrder(t.left, k, result);
        result.Add(t.value);
        if (t.right.value != -1)
            result = inOrder(t.right, k, result);
        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> indexes = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            indexes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<List<int>> result = Result.swapNodes(indexes, queries);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
