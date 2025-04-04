/* Алгоритм Флойда */

using System;

class Program
{
    static double[,] Matrix(int n)
    {
        double[,] m = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) m[i, j] = 0;
                else
                {
                    Console.Write($"Дуга между {i + 1} и {j + 1} (0 если нет): ");
                    m[i, j] = Convert.ToDouble(Console.ReadLine());
                    if (m[i, j] == 0) m[i, j] = double.PositiveInfinity;
                }
            }
        }
        return m;
    }
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        double[,] m = Matrix(n);
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = Math.Min(m[i, j], m[i, k] + m[k, j]);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (m[i, j] < 1000000) Console.Write($"{m[i, j]} ");
                else Console.Write("i ");
            }
            Console.WriteLine();
        }
    }
}