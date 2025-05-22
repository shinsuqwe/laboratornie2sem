/*Алгоритм 1. Нахождение компонент связности*/
class Connectivity
{
    static void Main()
    {
        int[,] matrix = {
            {0, 0, 0, 1, 0, 0, 0, 1},  //Заменить при необходимости
            {0, 0, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 1, 0, 0, 0},
            {1, 0, 0, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 0, 0, 0, 0, 1, 0}
        };
        List<int> points = new List<int>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            points.Add(i);
        }
        List<List<int>> components = new List<List<int>>();
        while (points.Count > 0)
        {
            List<int> currentComponent = new List<int>();
            currentComponent.Add(points[0]);
            points.RemoveAt(0);
            int index = 0;
            while (index < currentComponent.Count)
            {
                int currentVertex = currentComponent[index];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[currentVertex, j] == 1 && points.Contains(j))
                    {
                        currentComponent.Add(j);
                        points.Remove(j);
                    }
                }
                index++;
            }
            components.Add(currentComponent);
        }
        Console.WriteLine($"Всего компонент связности: {components.Count}");
        for (int i = 0; i < components.Count; i++)
        {
            Console.WriteLine($"Компонента связности {i + 1}: {string.Join(", ", components[i])}");
        }
    }
}


