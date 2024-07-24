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
using System.Runtime.ExceptionServices;

class Result
{

    /*
     * Complete the 'minimumMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING_ARRAY grid
     *  2. INTEGER startX
     *  3. INTEGER startY
     *  4. INTEGER goalX
     *  5. INTEGER goalY
     */

    public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        int temp = startX;
        startX = startY;
        startY = temp;
        temp = goalX;
        goalX = goalY;
        goalY = temp;
        char[,] color = new char[grid[1].Length, grid.Count];
        int x, y;
        for (y = 0; y < color.GetLength(1); y++)
        {
            for (x = 0; x < color.GetLength(0); x++)
            {
                if (grid[y][x] == 'X')
                    color[x, y] = 'X';
                else
                    color[x, y] = 'W';
            }
        }
        color[startX, startY] = 'R';
        int[,][] P = new int[color.GetLength(0), color.GetLength(1)][];
        List<int[]> queue = new List<int[]>();
        queue.Add(new int[2] { startX, startY });
        int[] node;
        while (true)
        {
            node = new int[2] { queue.First()[0], queue.First()[1] };
            x = node[0] + 1;
            y = node[1];
            while (x < color.GetLength(0) && color[x, y] != 'X')
            {
                if (color[x, y] == 'W')
                {
                    P[x, y] = new int[2] { node[0], node[1] };
                    if (x == goalX && y == goalY)
                        goto exit;
                    color[x, y] = 'R';
                    queue.Add(new int[2] { x, y });
                }
                x++;
            }

            x = node[0];
            y = node[1] + 1;
            while (y < color.GetLength(1) && color[x, y] != 'X')
            {
                if (color[x, y] == 'W')
                {
                    P[x, y] = new int[2] { node[0], node[1] };
                    if (x == goalX && y == goalY)
                        goto exit;
                    color[x, y] = 'R';
                    queue.Add(new int[2] { x, y });
                }
                y++;
            }

            x = node[0] - 1;
            y = node[1];
            while (x >= 0 && color[x, y] != 'X')
            {
                if (color[x, y] == 'W')
                {
                    P[x, y] = new int[2] { node[0], node[1] };
                    if (x == goalX && y == goalY)
                        goto exit;
                    color[x, y] = 'R';
                    queue.Add(new int[2] { x, y });
                }
                x--;
            }
            x = node[0];
            y = node[1] - 1;
            while (y >= 0 && color[x, y] != 'X')
            {
                if (color[x, y] == 'W')
                {
                    P[x, y] = new int[2] { node[0], node[1] };
                    if (x == goalX && y == goalY)
                        goto exit;
                    color[x, y] = 'R';
                    queue.Add(new int[2] { x, y });
                }
                y--;
            }
            queue.RemoveAt(0);
        }
    exit:
        int count = 0;
        x = goalX;
        y = goalY;
        while (x != startX || y != startY)
        {
            node = P[x, y];
            x = node[0];
            y = node[1];
            count++;
        }
        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int startX = Convert.ToInt32(firstMultipleInput[0]);

        int startY = Convert.ToInt32(firstMultipleInput[1]);

        int goalX = Convert.ToInt32(firstMultipleInput[2]);

        int goalY = Convert.ToInt32(firstMultipleInput[3]);

        int result = Result.minimumMoves(grid, startX, startY, goalX, goalY);

        Console.WriteLine(result);

        Console.ReadKey();
    }
}
