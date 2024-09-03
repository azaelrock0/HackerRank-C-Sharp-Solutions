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
     * Complete the 'roadsAndLibraries' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER c_lib
     *  3. INTEGER c_road
     *  4. 2D_INTEGER_ARRAY cities
     */

    public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
    {
        long longN = n;
        long longLib = c_lib;
        long longRoad = c_road;

        if (longLib < longRoad)
        {
            return longLib * longN;
        }
        Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();

        foreach (List<int> node in cities)
        {
            if (!graph.ContainsKey(node[0]))
            {
                graph.Add(node[0], new HashSet<int>());
            }
            graph[node[0]].Add(node[1]);

            if (!graph.ContainsKey(node[1]))
            {
                graph.Add(node[1], new HashSet<int>());
            }
            graph[node[1]].Add(node[0]);
        }

        Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        foreach (KeyValuePair<int, HashSet<int>> kvp in graph)
        {
            nodes.Add(kvp.Key, new Node(kvp.Key));
        }

        foreach (KeyValuePair<int, HashSet<int>> kvp in graph)
        {
            foreach (int edge in kvp.Value)
            {
                nodes[kvp.Key].edges.Add(nodes[edge]);
            }
        }

        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        int count;
        long total = 0;
        foreach (KeyValuePair<int, Node> kvp in nodes)
        {
            if (!visited.Contains(kvp.Key))
            {
                count = 0;
                queue.Enqueue(kvp.Key);
                visited.Add(queue.Peek());
                while (queue.Count > 0)
                {
                    count++;
                    foreach (Node edge in nodes[queue.Peek()].edges)
                    {
                        if (!visited.Contains(edge.value))
                        {
                            visited.Add(edge.value);
                            queue.Enqueue(edge.value);
                        }
                    }
                    queue.Dequeue();
                }
                total += longLib;
                if (longRoad * (count - 1) < 0)
                {

                }
                total += longRoad * (count - 1);
                if (total < 0)
                {

                }
            }
        }
        int currentCity = 0;
        while (currentCity < n)
        {
            currentCity++;
            if (!nodes.ContainsKey(currentCity))
            {
                total += longLib;
                if (total < 0)
                {

                }
            }
        }
        return total;
    }

}

public class Node
{
    public int value { get; set; }
    public List<Node> edges { get; set; }

    public Node(int value)
    {
        this.value = value;
        this.edges = new List<Node>();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int c_lib = Convert.ToInt32(firstMultipleInput[2]);

            int c_road = Convert.ToInt32(firstMultipleInput[3]);

            List<List<int>> cities = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                cities.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(citiesTemp => Convert.ToInt32(citiesTemp)).ToList());
            }

            long result = Result.roadsAndLibraries(n, c_lib, c_road, cities);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
