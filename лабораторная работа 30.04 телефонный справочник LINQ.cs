/* есть класс описывающий телефон, который включает следующие поля: 
номер, фио, дата постановки, оператор. 
необходимо сформировать запросы по выборке сведений о телефоне по:
1. заданному фио 
2. заданному номеру телефона, 
3. по всем телефонам сгруппированныи по году
3. по всем телефонам сгруппированным по оператору связи. */
using System;
class Phone
{
    private string _number;
    private string _operator;
    private string _year;
    private string _name;
    public string Number
    {
        get { return _number; } set { _number = value; }
    }
    public string Operator
    {
        get { return _operator; } set { _operator = value; }
    }
    public string Year
    {
        get { return _year; } set { _year = value; }
    }
    public string Name
    {
        get { return _name; } set { _name = value; }
    }
}
class Program
{
    static Phone[] numbers(int n)
    {
        Phone[] phones = new Phone[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для телефона {i + 1}: ");
            Console.Write($"Введите ФИО владельца номера {i + 1}: ");
            string name = Console.ReadLine();
            Console.Write($"Введите номер телефона {i + 1}: ");
            string number = Console.ReadLine();
            Console.Write($"Введите оператора {i + 1}: ");
            string oper = Console.ReadLine();
            Console.Write($"Введите год подключения {i + 1}: ");
            string year = Console.ReadLine();
            phones[i] = new Phone
            {
                Name = name,
                Number = number,
                Operator = oper,
                Year = year
            };
        }
        return phones;
    }
    static void Main()
    {
        int choice = 0;
        bool dataEntry = false;
        Phone[] phones = null;
        while (choice != 6)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Поиск по ФИО");
            Console.WriteLine("3. Поиск по номеру телефона");
            Console.WriteLine("4. Сгруппированный поиск по году");
            Console.WriteLine("5. Сгруппированный поиск по оператору связи");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите пункт: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Введите количество телефонов: ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    phones = numbers(n);
                    dataEntry = true;
                    break;

                case 2:
                    if (!dataEntry || phones == null)
                    {
                        Console.WriteLine("Введите данные!");
                        break;
                    }
                    Console.Write("Введите ФИО для поиска: ");
                    string searchName = Console.ReadLine();
                    var phonesName = from phone in phones where phone.Name == searchName select phone;
                    if (phonesName.Any())
                    {
                        Console.WriteLine("\nРезультаты поиска по ФИО");
                        foreach (var phone in phonesName) 
                        {
                            Console.WriteLine($"Номер: {phone.Number}, Оператор: {phone.Operator}, Год: {phone.Year}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Телефоны с таким ФИО не найдены.");
                    }
                    break;

                case 3:
                    if (!dataEntry || phones == null)
                    {
                        Console.WriteLine("Введите данные!");
                        break;
                    }
                    Console.Write("Введите номер телефона для поиска: ");
                    string searchNumber = Console.ReadLine();
                    var phoneNumber = from phone in phones where phone.Number == searchNumber select phone;
                    if (phoneNumber.Any())
                    {
                        Console.WriteLine("\nРезультаты поиска по номеру телефона");
                        foreach (var phone in phoneNumber) 
                        {
                            Console.WriteLine($"ФИО: {phone.Name}, Оператор: {phone.Operator}, Год: {phone.Year}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Телефон с таким номером не найден.");
                    }
                    break;

                case 4:
                    if (!dataEntry || phones == null)
                    {
                        Console.WriteLine("Введите данные!");
                        break;
                    }
                    var searchYear = phones.GroupBy(phones => phones.Year);
                    Console.WriteLine("\nТелефоны, сгруппированные по году");
                    foreach (var group in searchYear)
                    {
                        Console.WriteLine($"\nГод: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.Number}, ФИО: {phone.Name}, Оператор: {phone.Operator}");
                        }
                    }
                    break;

                case 5:
                    if (!dataEntry || phones == null)
                    {
                        Console.WriteLine("Сначала введите данные!");
                        break;
                    }
                    var phonesByOperator = phones.GroupBy(p => p.Operator);
                    Console.WriteLine("\nТелефоны, сгруппированные по оператору связи");
                    foreach (var group in phonesByOperator)
                    {
                        Console.WriteLine($"\nОператор: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.Number}, ФИО: {phone.Name}, Год: {phone.Year}");
                        }
                    }
                    break;

                case 6:
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}