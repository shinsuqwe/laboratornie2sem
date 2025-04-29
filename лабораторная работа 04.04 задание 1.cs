/* Лабораторная за 04.04
Необходимо с помощью лямбда-выражений вычислить сумму, произведение, разность и деление
между двумя переменными. */
delegate void Addition(int a, int b);
delegate void Difference(int a, int b);
delegate void Multiplication(int a, int b);
delegate void Division(int a, int b);
class Expression
{
    static void Main()
    {
        Console.WriteLine("Введите числа (2 должно быть целым)");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        Addition add = (a, b) => Console.WriteLine($"Сложеение: {a} + {b} = {a + b}"); add(a, b);
        Difference dif = (a, b) => Console.WriteLine($"Разность: {a} - {b} = {a - b}"); dif(a, b);
        Addition multi = (a, b) => Console.WriteLine($"Умножение: {a} * {b} = {a * b}"); multi(a, b);
        Addition div = (a, b) => Console.WriteLine($"Деление: {a} / {b} = {a / b}"); div(a, b);
    }
}