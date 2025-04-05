//Алгоритм Ли (метод волны)
using System;
class Program
{
    static bool CanStep(int[,] grid, int row, int col)
    {
        return grid[row, col] != -1; 
    }
    static int[,] CreateGrid()
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
        int[,] grid = CreateGrid();
        int height = grid.GetLength(0) - 2; 
        int width = grid.GetLength(1) - 2; 
        Console.WriteLine("Начальная клетка:");
        Console.Write("Строка: "); int startRow = Convert.ToInt32(Console.ReadLine());
        Console.Write("Столбец: "); int startCol = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Конечная клетка:");
        Console.Write("Строка: "); int endRow = Convert.ToInt32(Console.ReadLine());
        Console.Write("Столбец: "); int endCol = Convert.ToInt32(Console.ReadLine());

        if (CanStep(grid, startRow + 1, startCol)) grid[startRow + 1, startCol] = 1;
        if (CanStep(grid, startRow - 1, startCol)) grid[startRow - 1, startCol] = 1;
        if (CanStep(grid, startRow, startCol + 1)) grid[startRow, startCol + 1] = 1;
        if (CanStep(grid, startRow, startCol - 1)) grid[startRow, startCol - 1] = 1;

        int stepCount = 1;
        bool foundPath = false;

        while (grid[endRow, endCol] == 0)
        {
            foundPath = false;

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    if (grid[i, j] == stepCount)
                    {
                        if (CanStep(grid, i + 1, j)) { grid[i + 1, j] = stepCount + 1; foundPath = true; }
                        if (CanStep(grid, i - 1, j)) { grid[i - 1, j] = stepCount + 1; foundPath = true; }
                        if (CanStep(grid, i, j + 1)) { grid[i, j + 1] = stepCount + 1; foundPath = true; }
                        if (CanStep(grid, i, j - 1)) { grid[i, j - 1] = stepCount + 1; foundPath = true; }
                    }
                }
            }

            if (!foundPath) break;
            stepCount++;
        }

        if (grid[endRow, endCol] == 0 || grid[endRow, endCol] == -1)
        {
            Console.WriteLine("Путь не найден.");
        }
        else
        {
            Console.WriteLine($"Минимальный путь равен {grid[endRow, endCol]} шагов.");
        }
    }
}

//Намятова Анастасия ФИТ-242


