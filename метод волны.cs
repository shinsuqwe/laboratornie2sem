//Алгоритм Ли (метод волны)
using System;
class Program
{
    static bool step(int[,] grid, int row, int column)
    {
        return grid[row, column] != -1; 
    }
    static int[,] Grid()
    {
        int[,] grid = new int[,]
        {
            { -1, -1, -1, -1, -1, -1, -1 },  //-1 - грницы
            { -1,  0,  0,  0, -1, -1, -1 },  //при необходимости менять только то, что внутри.
            { -1,  0, -1,  0,  0,  0, -1 }, 
            { -1,  0, -1,  0, -1,  0, -1 }, 
            { -1,  0,  0,  0, -1,  0, -1 }, 
            { -1,  0,  0,  0, -1,  0, -1 },
            { -1, -1, -1, -1, -1, -1, -1 }
        };

        return grid;
    }
    static void Main()
    {
        int[,] grid = Grid();
        int height = grid.GetLength(0) - 2; 
        int width = grid.GetLength(1) - 2; 

        Console.WriteLine("Начальная клетка:");
        Console.Write("Строка: "); int row1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Столбец: "); int colomn1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Конечная клетка:");
        Console.Write("Строка: "); int row2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Столбец: "); int colomn2 = Convert.ToInt32(Console.ReadLine());

        if (step(grid, row1 + 1, colomn1)) grid[row1 + 1, colomn1] = 1;
        if (step(grid, row1 - 1, colomn1)) grid[row1 - 1, colomn1] = 1;
        if (step(grid, row1, colomn1 + 1)) grid[row1, colomn1 + 1] = 1;
        if (step(grid, row1, colomn1 - 1)) grid[row1, colomn1 - 1] = 1;

        int makestap = 1;
        bool found = false;

        while (grid[row2, colomn2] == 0)
        {
            found = false;

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    if (grid[i, j] == makestap)
                    {
                        if (step(grid, i + 1, j)) { grid[i + 1, j] = makestap + 1; found = true; }
                        if (step(grid, i - 1, j)) { grid[i - 1, j] = makestap + 1; found = true; }
                        if (step(grid, i, j + 1)) { grid[i, j + 1] = makestap + 1; found = true; }
                        if (step(grid, i, j - 1)) { grid[i, j - 1] = makestap + 1; found = true; }
                    }
                }
            }

            if (!found) break;
            makestap++;
        }

        if (grid[row2, colomn2] == 0 || grid[row2, colomn2] == -1)
        {
            Console.WriteLine("Путь не найден.");
        }
        else
        {
            Console.WriteLine($"Минимальный путь равен {grid[row2, colomn2]} шагов.");
        }
    }
}

//Намятова Анастасия ФИТ-242


