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
        else if (Weight > e.Weight) return 1;
        else if (Weight == e.Weight) return 0;
        else return -1;
    }
}
class Program
{
    static void Main()
    {
        int[,] m =
        {
            {0, 2, 0, 6, 0},
            {2, 0, 3, 8, 5},
            {0, 3, 0, 0, 7},
            {6, 8, 0, 0, 9},
            {0, 5, 7, 9, 0}
        };
        int n = m.GetLength(0); 
        List<int> column = new List<int>();
        for (int i = 1; i < n; i++)
        {
            column.Add(i);
        }
        List<int> line = new List<int>();
        List<Edge> MST = new List<Edge>();
        line.Add(0); 
        while (MST.Count != n - 1)
        {
            int inda = -1;
            int indb = -1;
            int min = int.MaxValue;
            for (int i = 0; i < line.Count; i++)
            {
                for (int j = 0; j < column.Count; j++)
                {
                    int u = line[i];
                    int v = column[j];

                    if (m[u, v] != 0 && m[u, v] < min)
                    {
                        min = m[u, v];
                        inda = u;
                        indb = v;
                    }
                }
            }
            if (indb != -1)
            {
                line.Add(indb);
                column.Remove(indb);
                MST.Add(new Edge(inda, indb, min));
            }
        }
        Console.WriteLine("Минимальное остовное дерево:");
        foreach (var edge in MST)
        {
            Console.WriteLine($"({edge.V1}, {edge.V2}) = {edge.Weight}");
        }
    }
}
