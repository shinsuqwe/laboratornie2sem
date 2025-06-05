using System;
using System.Collections.Generic;

class Edge : IComparable<Edge>
{
    public int Weight { get; set; }
    public int V1 { get; set; }
    public int V2 { get; set; }
    public Edge(int a, int b, int c)
    {
        Weight = c;
        V1 = a;
        V2 = b;
    }
    public int CompareTo(Edge e)
    {
        if (e == null) return 1;
        return Weight.CompareTo(e.Weight);
    }
}
class Program
{
    static void Main()
    {
        int[,] matrix =
        {
            {0, 2, 0, 6, 0},
            {2, 0, 3, 8, 5},
            {0, 3, 0, 0, 7},
            {6, 8, 0, 0, 9},
            {0, 5, 7, 9, 0}
        };
        int n = matrix.GetLength(0); 
        List<Edge> list = new List<Edge>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++) 
            {
                if (i != j && matrix[i, j] != 0)
                {
                    Edge edge = new Edge(i, j, matrix[i, j]);
                    list.Add(edge);
                }
            }
        }
        list.Sort(); 
        List<Edge> MST = new List<Edge>();
        int[] mst = new int[n];
        for (int i = 0; i < n; i++) mst[i] = 0;
        int t = 1;
        for (int i = 0; i < list.Count; i++)
        {
            int u = list[i].V1;
            int v = list[i].V2;
            if (mst[u] == 0 && mst[v] == 0)
            {
                mst[u] = t;
                mst[v] = t;
                t++;
                MST.Add(list[i]);
            }
            else if (mst[u] != 0 && mst[v] != 0 && mst[u] == mst[v])
            {
                continue;
            }
            else if (mst[u] != 0 && mst[v] != 0)
            {
                int oldGroup = mst[u];
                int newGroup = mst[v];

                for (int k = 0; k < n; k++)
                {
                    if (mst[k] == oldGroup)
                        mst[k] = newGroup;
                }
                MST.Add(list[i]);
            }
            else if (mst[u] == 0)
            {
                mst[u] = mst[v];
                MST.Add(list[i]);
            }
            else if (mst[v] == 0)
            {
                mst[v] = mst[u];
                MST.Add(list[i]);
            }
            if (MST.Count == n - 1) break;
        }
        Console.WriteLine("Минимальное остовное дерево:");
        foreach (var edge in MST)
        {
            Console.WriteLine($"({edge.V1}, {edge.V2}) = {edge.Weight}");
        }
    }
}
