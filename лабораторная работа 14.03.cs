/* 1
Есть класс с двумя элементами, и в нем реализованы методы: 
сложение, вычитание, умножение, деление. Также есть делегат и два объекта этого класса. 
Нужно настроить делегаты для каждого объекта так, чтобы для первого объекта последовательно 
выполнялись сложение, вычитание полученной суммы со вторым элементом, умножение результата 
на второй элемент. Для второго объекта — целочисленное деление, затем сумма результата со 
вторым элементом и умножение на второй элемент. */
delegate void Operation();
class Meaning
{
    public int a;
    public int b;

    public int Add(int a, int b) => a + b;
    public int Subtraction(int a, int b) => a - b;
    public int Multiplication(int a, int b) => a * b;
    public int Division(int a, int b) => a / b;
}
class Program
{
    static void Main()
    {
        Meaning ob1 = new Meaning();
        Console.WriteLine("Введите два целых числа для первого объекта: ");
        ob1.a = Convert.ToInt32(Console.ReadLine());
        ob1.b = Convert.ToInt32(Console.ReadLine());

        Meaning ob2 = new Meaning();
        Console.WriteLine("Введите два целых числа для второго объекта: ");
        ob2.a = Convert.ToInt32(Console.ReadLine());
        ob2.b = Convert.ToInt32(Console.ReadLine());

        Func<int, int> operation1 = a =>
        ob1.Multiplication(ob1.Subtraction(ob1.Add(ob1.a, ob1.b), ob1.b), ob1.b);

        Func<int, int> operation2 = b =>
        ob2.Multiplication(ob2.Add(ob2.Division(ob2.a, ob2.b), ob2.b), ob2.b);

        Console.WriteLine($"Результаты для первого объекта: {operation1(ob1.a)}");
        Console.WriteLine($"Результаты для второго объекта: {operation2(ob1.b)}");
    }
}
