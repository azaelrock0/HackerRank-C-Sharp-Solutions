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
     * Complete the 'balancedForest' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY c
     *  2. 2D_INTEGER_ARRAY edges
     */

    public static long balancedForest(List<int> c, List<List<int>> edges)
    {
        Dictionary<int, Node> tree = new Dictionary<int, Node>();


        foreach (List<int> edge in edges)
        {
            edge.Sort();
        }

        for (int i = 1; i <= c.Count; i++)
        {
            tree.Add(i, new Node(i, c[i - 1]));
        }
        foreach (List<int> edge in edges)
        {
            tree[edge[0]].edges.Add(edge[1], tree[edge[1]]);
            tree[edge[1]].edges.Add(edge[0], tree[edge[0]]);
        }

        Node root = tree[1], deeper1;
        long minNodeValue = long.MaxValue;
        bool possible = false;

        GetTotalCount(root, 0);
        List<int> orderedEdges = OrderEdges(tree);

        for (int i = 0; i < orderedEdges.Count - 1; i++)
        {
            deeper1 = tree[orderedEdges[i]];
            long restRoot = root.value - (deeper1.value * 2);

            if (root.subtrees[deeper1.value] > 1 && restRoot <= deeper1.value)
            {
                minNodeValue = Math.Min(minNodeValue, deeper1.value - restRoot);
                possible = true;
            }

            bool removeLater = false;
            if (!deeper1.subtrees.ContainsKey(restRoot))
            {
                deeper1.subtrees.Add(restRoot, 0);
                removeLater = true;
            }

            if (restRoot <= deeper1.value &&
                root.subtrees.ContainsKey(restRoot) && root.subtrees[restRoot] > deeper1.subtrees[restRoot])
            {
                minNodeValue = Math.Min(minNodeValue, deeper1.value - restRoot);
                possible = true;
            }
            if (minNodeValue == 0)
                return 0;
            if (removeLater)
            {
                deeper1.subtrees.Remove(restRoot);
            }

            restRoot = root.value - deeper1.value;
            foreach (KeyValuePair<long, int> kvp in deeper1.subtrees)
            {
                if (deeper1.value == 47 && kvp.Key == 30)
                {

                }
                if (restRoot == deeper1.value - kvp.Key && restRoot >= kvp.Key)
                {
                    minNodeValue = Math.Min(minNodeValue, restRoot - kvp.Key);
                    possible = true;
                }
                if(restRoot == kvp.Key && restRoot >= deeper1.value - kvp.Key)
                {
                    minNodeValue = Math.Min(minNodeValue, restRoot-(deeper1.value-kvp.Key));
                    possible = true;
                }
            }
        }

        if (possible)
            return minNodeValue;

        return -1;
    }

    static SortedDictionary<long, int> GetTotalCount(Node root, int depth)
    {
        int toRemove = -1;
        SortedDictionary<long, int> tempDict = new SortedDictionary<long, int>();
        root.depth = depth;

        foreach (Node edge in root.edges.Values)
        {
            if (edge.depth == -1)
            {
                tempDict = GetTotalCount(edge, depth + 1);
                foreach (KeyValuePair<long, int> kvp in tempDict)
                {
                    if(kvp.Key == 162056417684)
                    {

                    }
                    if (root.subtrees.ContainsKey(kvp.Key))
                        root.subtrees[kvp.Key]++;
                    else
                        root.subtrees.Add(kvp.Key, tempDict[kvp.Key]);
                }
                root.value += tempDict.Last().Key;
            }
            else
                toRemove = edge.id;
        }
        root.subtrees.Add(root.value, 1);
        if (toRemove > -1)
            root.edges.Remove(toRemove);
        return root.subtrees;
    }

    static List<int> OrderEdges(Dictionary<int, Node> tree)
    {
        List<int> orderedEdges = new List<int>();
        Queue<int> queue = new Queue<int>();
        Node currentNode;
        queue.Enqueue(tree.First().Key);
        while (queue.Count > 0)
        {
            currentNode = tree[queue.Peek()];
            foreach (Node edge in currentNode.edges.Values)
            {
                orderedEdges.Add(edge.id);
                queue.Enqueue(edge.id);
            }
            queue.Dequeue();
        }
        return orderedEdges;
    }
}
public class Node
{
    public int id { get; set; }
    public int depth { get; set; }
    public long value { get; set; }
    public Dictionary<int, Node> edges;
    public SortedDictionary<long, int> subtrees;

    public Node(int id, int value)
    {
        this.id = id;
        this.value = value;
        this.depth = -1;
        edges = new Dictionary<int, Node>();
        subtrees = new SortedDictionary<long, int>();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < n - 1; i++)
            {
                edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
            }

            long result = Result.balancedForest(c, edges);

            Console.WriteLine(result);
        
        
        }

        Console.ReadKey();
    }
}
