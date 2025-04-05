//Алгоритм Дейкстры)
class Deiksrta
{
    static void Main(string[] args)
    {
        int[,] matrixgraph =
        {
        { 0, 5, 0, 0, 2, 4 },    // пример матрицы. заменнить при необходимости
        { 5, 0, 12, 0, 0, 1 },
        { 0, 12, 0, 9, 0, 3 },
        { 0, 0, 9, 0, 7, 0 },
        { 2, 0, 0, 7, 0, 8 },
        { 4, 1, 3, 0, 8, 0 }
    };
        int top1 = 0; // начальная вершина. заменнить при необходимости
        int[] distance = Deikstra(matrixgraph, top1);
        Console.WriteLine($"Кратчайшие расстояния от вершины {top1}: ");
        for (int i = 0; i < distance.Length; i++)
        {
            Console.WriteLine($"До вершины {i}: {distance[i]}");
        }
    }
    static int[] Deikstra(int[,] matrixgraph, int top1)
    {
        int n = matrixgraph.GetLength(0);
        int[] distance = new int[n];
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }
        distance[top1] = 0;
        for (int c = 0; c < n - 1; c++)
        {
            int s = MinDistance(distance, visited);
            visited[s] = true;
            for (int k = 0; k < n; k++)
            {
                if (!visited[k] && matrixgraph[s, k] != 0 && distance[s] != int.MaxValue && distance[s] + matrixgraph[s, k] < distance[k])
                {
                    distance[k] = distance[s] + matrixgraph[s, k];
                }
            }
        }
        return distance;
    }
    static int MinDistance(int[] distance, bool[] visited)
    {
        int min = int.MaxValue, minind = -1;

        for (int k = 0; k < distance.Length; k++)
        {
            if (!visited[k] && distance[k] <= min)
            {
                min = distance[k];
                minind = k;
            }
        }

        return minind;
    }
}

//Намятова Анастасия ФИТ-242

