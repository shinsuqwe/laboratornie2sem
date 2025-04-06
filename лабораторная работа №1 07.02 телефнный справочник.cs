/* Дана база данных - телефонный справочник с ФИО, номером телефона (может быть
несколько у одного человека), город, оператор связи, год подключения.
Осуществить выборку по ФИО, оператору, номеру телефона. */
using System;
class Phone
{
    private string _number;
    private string _operator;
    private string _year;
    public string Number
    {
        get {return _number;} set { _number = value; } 
    }
    public string Operator
    {
        get { return _operator; } set { _operator = value; } 
    }
    public string Year
    {
        get { return _year; } set { _year = value; }
    }
}
class Person
{
    private string _name;
    private string _city;
    private Phone[] _numbers;

    public string Name
    {
        get { return _name; } set { _name = value; }
    }
    public string City
    {
        get { return _city; } set { _city = value; }
    }
    public Phone[] Nums
    {
        get { return _numbers; } set { _numbers = value; }
    }
}
class Program
{
    static Phone[] numbers(int n)
    {
        Phone[] phones = new Phone[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите номер телефона {i + 1}: ");
            string number = Console.ReadLine();
            Console.Write($"Введите оператора {i + 1}: ");
            string oper = Console.ReadLine();
            Console.Write($"Введите год подключения {i + 1}: ");
            string year = Console.ReadLine();
            phones[i] = new Phone
            {
                Number = number,
                Operator = oper,
                Year = year
            };
        }
        return phones;
    }
    static void Main()
    {
        Person[] people = Array.Empty<Person>();
        int choice = 0;
        bool dataEntry = false;
        while (choice != 5)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Поиск по ФИО");
            Console.WriteLine("3. Поиск по оператору");
            Console.WriteLine("4. Поиск по номеру телефона");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введите количество человек: ");
                    int personcount = Convert.ToInt32(Console.ReadLine());
                    people = new Person[personcount];
                    for (int i = 0; i < personcount; i++)
                    {
                        Console.Write($"Введите ФИО человека {i + 1}: ");
                        string name = Console.ReadLine();
                        Console.Write($"Введите город человека {i + 1}: ");
                        string city = Console.ReadLine();
                        Console.Write($"Введите количество телефонов человека {i + 1}: ");
                        int phoneCount = Convert.ToInt32(Console.ReadLine());
                        people[i] = new Person
                        {
                            Name = name,
                            City = city,
                            Nums = numbers(phoneCount)
                        };
                    }
                    dataEntry = true;
                    break;

                case 2:
                    if (!dataEntry)
                    {
                        Console.WriteLine("Сначала введите данные.");
                        break;
                    }
                    Console.Write("Введите ФИО для поиска: ");
                    string searchname = Console.ReadLine();
                    bool foundname = false;
                    foreach (var person in people)
                    {
                        if (person.Name.Equals(searchname, StringComparison.OrdinalIgnoreCase))
                        {
                            foundname = true; 
                            Console.WriteLine($"Список номеров для {person.Name}:");
                            foreach (var phone in person.Nums)
                            {
                                Console.WriteLine($"  Номер: {phone.Number}, Оператор: {phone.Operator}, Год: {phone.Year}");
                            }
                        }
                    }
                    if (!foundname)
                    {
                        Console.WriteLine("Человек с таким ФИО не найден.");
                    }
                    break;

                case 3:
                    if (!dataEntry)
                    {
                        Console.WriteLine("Сначала введите данные.");
                        break;
                    }

                    Console.Write("Введите оператора для поиска: ");
                    string searchoper = Console.ReadLine();
                    bool foundoper = false;
                    foreach (var person in people)
                    {
                        foreach (var phone in person.Nums)
                        {
                            {
                                Console.WriteLine($"Человек: {person.Name}, Номер: {phone.Number}, Год: {phone.Year}");
                            }
                        }
                    }
                    if (!foundoper)
                    {
                        Console.WriteLine("Номера с таким оператором не найдены.");
                    }
                    break;

                case 4:
                    if (!dataEntry)
                    {
                        Console.WriteLine("Сначала введите данные.");
                        break;
                    }
                    Console.Write("Введите номер телефона для поиска: ");
                    string searchnum = Console.ReadLine();
                    bool foundnum = false;
                    foreach (var person in people)
                    {
                        foreach (var phone in person.Nums)
                        {
                            if (phone.Number == searchnum)
                            {
                                foundnum = true;
                                Console.WriteLine($"Номер принадлежит человеку: {person.Name}, Город: {person.City}");
                            }
                        }
                    }
                    if (!foundnum)
                    {
                        Console.WriteLine("Человек с таким номером не найден.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
