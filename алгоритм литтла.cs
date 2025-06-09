using System;
using System.Collections.Generic;
class Arc
{
    public int V1 { get; set; }
    public int V2 { get; set; }
    public double Weight { get; set; }
    public Arc(int a, int b, double c)
    {
        V1 = a;
        V2 = b;
        Weight = c;
    }
}
class Program
{
    static void Main()
    {
        int n = 5;
        double[,] matrix = new double[,] {
            { double.PositiveInfinity, 31,     15,     19,     8,     55   },
            { 19,     double.PositiveInfinity, 22,    31,    7,     35   },
            { 25,     43,    double.PositiveInfinity, 53,     57,    16  },
            { 5,      50,    49,     double.PositiveInfinity, 39,    9   },
            { 24,     24,    33,     5,     double.PositiveInfinity, 14  },
            { 34,     26,     6,     3,     36,    double.PositiveInfinity }
        };
        double[,] m = new double[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 && j == 0)
                {
                    m[i, j] = double.PositiveInfinity;
                }
                else if (i == 0)
                {
                    m[i, j] = j;
                }
                else if (j == 0)
                {
                    m[i, j] = i;
                }
                else
                {
                    m[i, j] = matrix[i - 1, j - 1];
                }
            }
        }
        List<Arc> coef = new List<Arc>();
        List<Arc> way = new List<Arc>();
        double reduction = 0;
        while (m.GetLength(0) > 2)
        {
            for (int i = 1; i < m.GetLength(0); i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 1; j < m.GetLength(0); j++)
                {
                    min = Math.Min(min, m[i, j]);
                }
                if (min != double.PositiveInfinity)
                {
                    reduction += min;
                    for (int j = 1; j < m.GetLength(0); j++)
                    {
                        if (m[i, j] != double.PositiveInfinity)
                            m[i, j] -= min;
                    }
                }
            }
            for (int j = 1; j < m.GetLength(0); j++)
            {
                double min = double.PositiveInfinity;
                for (int i = 1; i < m.GetLength(0); i++)
                {
                    min = Math.Min(min, m[i, j]);
                }
                if (min != double.PositiveInfinity)
                {
                    reduction += min;
                    for (int i = 1; i < m.GetLength(0); i++)
                    {
                        if (m[i, j] != double.PositiveInfinity)
                            m[i, j] -= min;
                    }
                }
            }
            coef.Clear();
            for (int i = 1; i < m.GetLength(0); i++)
            {
                for (int j = 1; j < m.GetLength(0); j++)
                {
                    if (m[i, j] == 0)
                    {
                        double min1 = double.PositiveInfinity;
                        double min2 = double.PositiveInfinity;
                        for (int k = 1; k < m.GetLength(0); k++)
                        {
                            if (k == j) continue;
                            min1 = Math.Min(min1, m[i, k]);
                        }
                        for (int k = 1; k < m.GetLength(0); k++)
                        {
                            if (k == i) continue;
                            min2 = Math.Min(min2, m[k, j]);
                        }
                        coef.Add(new Arc(i, j, min1 + min2));
                    }
                }
            }
            if (coef.Count == 0) break;

            Arc max = coef[0];
            foreach (Arc arc in coef)
            {
                if (arc.Weight > max.Weight) max = arc;
            }
            m[max.V2, max.V1] = double.PositiveInfinity;
            double[,] mat = new double[m.GetLength(0) - 1, m.GetLength(0) - 1];
            int i1 = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                if (i == max.V1) continue;
                int j1 = 0;
                for (int j = 0; j < m.GetLength(0); j++)
                {
                    if (j == max.V2) continue;
                    mat[i1, j1] = m[i, j];
                    j1++;
                }
                i1++;
            }
            way.Add(new Arc(
                Convert.ToInt32(m[max.V1, 0]),
                Convert.ToInt32(m[0, max.V2]),
                matrix[
                    Convert.ToInt32(m[max.V1, 0]) - 1,
                    Convert.ToInt32(m[0, max.V2]) - 1
                ]
            ));
            m = new double[mat.GetLength(0), mat.GetLength(0)];
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    m[i, j] = mat[i, j];
                }
            }
            coef.Clear();
        }
        way.Add(new Arc(
            Convert.ToInt32(m[1, 0]),
            Convert.ToInt32(m[0, 1]),
            matrix[Convert.ToInt32(m[1, 0]) - 1, Convert.ToInt32(m[0, 1]) - 1]
        ));
        Console.WriteLine("Оптимальный путь:");
        foreach (var arc in way)
        {
            Console.WriteLine($"({arc.V1}, {arc.V2}) = {arc.Weight}");
        }

        Console.WriteLine($"\nОбщая стоимость пути = {reduction}");
    }
}
