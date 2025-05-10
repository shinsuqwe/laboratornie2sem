/* Лабораторная за 28.03 Задание 1.
Класс точка с переменными х и у. Класс области, являющейся прямоугольным элементом (с 2 точками). 
Когда создается объект точка начальные координаты лежат внутри заданной области. Обработать событие, 
которое возникает при движении точки на шаг приращения по х и у и выдать сообщения, что точка вышла за 
пределы границы
Есть делегат. Есть класс событие. Есть метод (в отдельнмо классе). В мейне когда точка вышла за границы 
вызывать событие о том, что точка вышла за границы
*/
using System;
public delegate void PointOutAreaHandler();
class Program
{
    static void Main()
    {
        Area area = new Area(0, 10, 0, 10); //размер области (поменять при желании)
        Point point = new Point(area);
        AreaHandler handler = new AreaHandler();
        point.Notify += handler.PointOut;
        for (int i = 0; i < 5; i++) //количество перемещений (поменять при желании)
        {
            Console.WriteLine($"Текущая позиция: ({point.X}, {point.Y})");
            point.Move();
            Console.WriteLine();
        }
    }
}
class Area
{
    public int MinX { get; }
    public int MaxX { get; }
    public int MinY { get; }
    public int MaxY { get; }
    public Area(int minX, int maxX, int minY, int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }
    public bool withinLimits(int x, int y)
    {
        return x >= MinX && x <= MaxX && y >= MinY && y <= MaxY;
    }
}
class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly Area _area;
    private Random _random = new Random();
    public event PointOutAreaHandler Notify;
    public Point (Area area)
    {
        _area = area;
        X = _random.Next(area.MinX, area.MaxX + 1);
        Y = _random.Next(area.MinY, area.MaxY + 1);
    }

    public void Move()
    {
        int rnX = _random.Next(-5, 6); //шаги (поменять при желании)
        int rnY = _random.Next(-5, 6);

        X += rnX;
        Y += rnY;
        Console.WriteLine($"Движение на ({rnX}, {rnY})! Новая позиция: ({X}, {Y})");
        if (!_area.withinLimits(X, Y))
        {
            Notify?.Invoke();
        }
    }
}
class AreaHandler
{
    public void PointOut()
    {
        Console.WriteLine("Точка вышла за пределы!");
    }
}