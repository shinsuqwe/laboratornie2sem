//Форд Беллман
using System;
class FordBellmanAlg
{
    static void Main(string[] args)
    {
        int[,] matrixgraph = {
            { 0, 1, 0, 0, 3 },  // пример матрицы. при необходимости изменить
            { 0, 0, 3, 3, 8 },
            { 0, 0, 0, 1, -5 },
            { 0, 0, 2, 0, 0 },
            { 0, 0, 0, 4, 0 }
        };
        int top1 = 0; // начальная вершина. при необходиомти заменить
        try
        {
            int[] distance = FordBellman(matrixgraph, top1);
            Console.WriteLine($"Кратчайшие расстояния от вершины {top1}: ");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"До вершины {i}: {distance[i]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int[] FordBellman(int[,] matrixgraph, int top1)
    {
        int n = matrixgraph.GetLength(0);
        int[] distance = new int[n]; 
        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue; 
        }
        distance[top1] = 0; 
        for (int i = 0; i < n - 1; i++)
        {
            for (int s = 0; s < n; s++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (matrixgraph[s, k] != 0 && distance[s] != int.MaxValue && distance[s] + matrixgraph[s, k] < distance[k])
                    {
                        distance[k] = distance[s] + matrixgraph[s, k];
                    }
                }
            }
        }
        return distance;
    }
}
//Намятова Анастасия Фит-242