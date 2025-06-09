using System;
using System.Collections.Generic;
class Program
{
    static bool BFS(int[,] residualGraph, int source, int sink, int[] parent, int n)
    {
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);
        visited[source] = true;
        while (queue.Count != 0)
        {
            int u = queue.Dequeue();
            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && residualGraph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    visited[v] = true;
                    parent[v] = u;
                    if (v == sink) return true;
                }
            }
        }
        return false;
    }
    static void Main()
    {
        int n = 6;
        int[,] matrix = new int[,] {
            {0, 16, 13, 0, 0, 0},
            {0, 0, 10, 12, 0, 0},
            {0, 4, 0, 0, 14, 0},
            {0, 0, 9, 0, 0, 20},
            {0, 0, 0, 7, 0, 4},
            {0, 0, 0, 0, 0, 0}
        };
        int source = 0; 
        int sink = 5;   
        int maxflow = 0;
        int[] parent = new int[n];
        int[,] resg = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                resg[i, j] = matrix[i, j];
            }
        }
        while (BFS(resg, source, sink, parent, n))
        {
            int flow = int.MaxValue;
            for (int i = sink; i != source; i = parent[i])
            {
                int j = parent[i];
                flow = Math.Min(flow, resg[j, i]);
            }
            for (int i = sink; i != source; i = parent[i])
            {
                int j = parent[i];
                resg[j, i] -= flow;
                resg[i, j] += flow;
            }
            maxflow += flow;
        }
        Console.WriteLine($"Максимальный поток равен {maxflow}");
    }
}
