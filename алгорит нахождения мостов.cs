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
            {0, 0, 0, 0, 3},
            {0, 0, 2, 0, 0},
            {0, 2, 0, 4, 0},
            {0, 0, 4, 0, 5},
            {3, 0, 0, 5, 0}
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
            int min = 1000000;

            for (int i = 0; i < line.Count; i++)
            {
                for (int j = 0; j < column.Count; j++)
                {
                    if ((m[line[i], column[j]] != 0) && (m[line[i], column[j]] < min))
                    {
                        min = m[line[i], column[j]];
                        inda = line[i];
                        indb = column[j];
                    }
                }
            }
            line.Add(indb);
            column.Remove(indb);
            MST.Add(new Edge(inda, indb, min));
        }
        List<Edge> bridge = new List<Edge>();
        for (int p = 0; p < n - 1; p++)
        {
            int[,] mat = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if ((i == MST[p].V1 && j == MST[p].V2) || (i == MST[p].V2 && j == MST[p].V1))
                    {
                        mat[i, j] = 0;
                    }
                    else
                    {
                        mat[i, j] = m[i, j];
                    }
                    mat[j, i] = mat[i, j]; 
                }
            }
            List<int> points = new List<int>();
            for (int i = 0; i < n; i++)
            {
                points.Add(i);
            }
            List<List<int>> components = new List<List<int>>();
            while (points.Count > 0)
            {
                List<int> currentComponent = new List<int>();
                currentComponent.Add(points[0]);
                points.RemoveAt(0);
                int ind = 0;
                while (ind < currentComponent.Count)
                {
                    int currentVertex = currentComponent[ind];
                    for (int j = 0; j < n; j++)
                    {
                        if (mat[currentVertex, j] != 0 && points.Contains(j))
                        {
                            currentComponent.Add(j);
                            points.Remove(j);
                        }
                    }
                    ind++;
                }
                components.Add(currentComponent);
            }
            if (components.Count > 1)
            {
                bridge.Add(MST[p]);
            }
        }
        if (bridge.Count == 0)
        {
            Console.WriteLine("Нет мостов");
        }
        else
        {
            Console.WriteLine("Мосты:");
            foreach (var edge in bridge)
            {
                Console.WriteLine($"({edge.V1}, {edge.V2})");
            }
        }
    }
}
