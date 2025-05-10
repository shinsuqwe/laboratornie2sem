/* class Name
{
    static void Main()
    {
        Console.WriteLine("Введите имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите фамилию: ");
        string surname = Console.ReadLine();
        Console.WriteLine($"Добро пожаловать, {name} {surname}!");
    }
}
*/

/* class Name
{
    static void Main()
    {
        Console.WriteLine("Введите имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите возраст: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Имя {name}, Возраст {age}"); 
    }
}
*/

/*
class Date
{
    static void Main()
    {
        Console.WriteLine("Текущий день недели: ");
        string dayweek = Console.ReadLine();
        Console.WriteLine("Текущий месяц: ");
        string month = Console.ReadLine();
        Console.WriteLine("Число: ");
        int date = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"{dayweek} {date} {month}");
    }
} */

/*
class Age
{
    static void Main()
    {
        Console.WriteLine("Введите дату рождения(день/месяц/год): ");
        int day = Int32.Parse(Console.ReadLine());
        int month = Int32.Parse(Console.ReadLine());
        int year = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Введите сегодняшнюю дату(день/месяц/год: ");
        int daynow = Int32.Parse(Console.ReadLine());
        int monthnow = Int32.Parse(Console.ReadLine());
        int yearnow = Int32.Parse(Console.ReadLine());
        int dayb = daynow - day;
        int monthb = monthnow - month;
        int yearb = yearnow - year;
        Console.WriteLine($"Возраст: {dayb} дня(-ей) {monthb} месяца(-ев) {yearb} лет(год)");
    }
}
*/
/*
class Division
{
    static void Main()
    {
        Console.WriteLine("Введите число: ");
        int number = Int32.Parse(Console.ReadLine());
        int res = number % 3;
        string result = (res == 0) ? ("делится на 3") : ("не делится на 3");
        Console.WriteLine(result);
    }
}
*/

/*
class Division
{
    static void Main()
    {
        Console.WriteLine("Введите число: ");
        int number = Int32.Parse(Console.ReadLine());
        int res1 = number % 5;
        int res2 = number % 7;
        string result1 = (res1 == 2) ? ("Делится на 5 с остатком 2") : ("Не делится на 5 с остатком 2");
        string result2 = (res2 == 1) ? ("Делится на 7 с остатком 1") : ("Не делится на 7 с остатком 1");
        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }
}
*/

class 