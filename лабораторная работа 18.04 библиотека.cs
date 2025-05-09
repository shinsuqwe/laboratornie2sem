/* Лабораторная за 18.04
Есть база данных библиотеки, в которой описание книг будет с использованием структуры,
включающей следующие поля: ФИО автора, название, год издания, наименование издательства.
Для каждой книги имеется формуляр (даты выдачи и сдачи). Необходимо написать программу,
которая позволит заполнять базу данных и делать выборку книг, которые не были на руках
и книг, которые не сданы в библиотеку. */
using System.Reflection.Metadata;
struct Book
{
    public string Author;
    public string NameBook;
    public int Year;
    public string Publisher;
    public string Issue;
    public string Pass;
}
class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>();
        bool check = false;
        while (!check)
        {
            Console.WriteLine("\nМеню");
            Console.WriteLine("1. Ввод данных");
            Console.WriteLine("2. Новые книги (не выдавались)");
            Console.WriteLine("3. Несданные книги");
            Console.WriteLine("4. Выход");
            Console.WriteLine("\nВыберите пункт: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    check = false;
                    Console.Write("Укажите количество книг: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < amount; i++)
                    {
                        Book book = new Book();
                        Console.Write($"Введите автора книги {i + 1}: ");
                        book.Author = Console.ReadLine();
                        Console.Write($"Введите название книги {i + 1}: ");
                        book.NameBook = Console.ReadLine();
                        Console.Write($"Введите год издания книги {i + 1}: ");
                        book.Year = Convert.ToInt32(Console.ReadLine());
                        Console.Write($"Введите издательство книги {i + 1}: ");
                        book.Publisher = Console.ReadLine();
                        Console.Write($"Была ли книга {i + 1} выдана? (да/нет): ");
                        string answer = Console.ReadLine();
                        if (answer == "да")
                        {
                            Console.Write($"Введите дату выдачи книги {i + 1}: ");
                            book.Issue = Console.ReadLine();
                            Console.Write($"Была ли книга {i + 1} сдана? (да/нет): ");
                            book.Pass = Console.ReadLine();
                            if (book.Pass == "да")
                            {
                                Console.Write($"Введите дату сдачи книги {i + 1}: ");
                                book.Pass = Console.ReadLine();
                            }
                            else
                            {
                                book.Pass = null;
                            }
                        }
                        else
                        {
                            book.Issue = null;
                        }
                            books.Add(book);
                    }
                    break;

                case 2:
                    Console.WriteLine("\nКниги, которые никогда не выдавались (новые): ");
                    var notIssue = books.Where(b => b.Issue == null);
                    foreach (var b in notIssue)
                    {
                        Console.WriteLine($"{b.Author} - {b.NameBook}, {b.Year}, {b.Publisher}");
                    }
                    break;

                case 3:
                    Console.WriteLine("\nКниги, которые не сданы: ");
                    var notPass = books.Where(b => b.Pass == null);
                    foreach (var b in notPass)
                    {
                        Console.WriteLine($"{b.Author} - {b.NameBook}, {b.Year}, {b.Publisher}");
                    }
                    break;

                case 4:
                    check = true;
                    break;
            }
        }
    }
}
