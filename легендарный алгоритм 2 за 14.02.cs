using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int[,] m =
        {
            {0, 0, 0, 1, 0, 0, 0, 1},  //Заменить при необходимости
            {0, 0, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 1, 0, 0, 0},
            {1, 0, 0, 0, 0, 1, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 0, 0, 0, 0, 1, 0}
        };
        int n = m.GetLength(0);
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
                    if (m[currentVertex, j] == 1 && points.Contains(j))
                    {
                        currentComponent.Add(j);
                        points.Remove(j);
                    }
                }
                ind++;
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
