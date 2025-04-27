/* Лабораторная за 21.03
Есть класс машины, в котором имеются поля год выпуска, марка и чистота.
Есть класс гараж, хранящий список объектов класса машины. Есть класс мойка, 
в котором реализуется метод помывки машины. Необходимо реализовать помывку 
машин с помощью делегата. */
delegate void Cleaning(Car car);
class Car
{
    private int _year;
    private string _brand;
    private bool _clean;

    public int Year
    {
        get { return _year; } set { _year = value; }
    }
    public string Brand
    {
        get { return _brand; } set { _brand = value; }
    }
    public bool Clean
    {
        get { return _clean; } set { _clean = value; }
    }
    public override string ToString()
    {
        return $"Марка: {Brand}, Год выпуска: {Year}, Чистота: {(Clean ? "Чистая" : "Грязная")}";
    }
}
class Garage
{
    private List<Car> _cars = new List<Car>();
    public void AddCar(Car car)
    {
        _cars.Add(car);
    }
    public List<Car> GetCars()
    {
        return _cars;
    }
}
class Washing
{
    public void Clear(Car car)
    {
        if (!car.Clean)
        {
            car.Clean = true;
            Console.WriteLine($"Машина {car.Brand} вымыта.");
        }
        else
        {
            Console.WriteLine($"Машина {car.Brand} уже чистая, мойка не нужна.");
        }
    }
}
class Program
{
    static void Main()
    {
        Washing cleaner = new Washing();
        Cleaning cleanerDelegate = cleaner.Clear;
        Garage garage = new Garage();

        Console.Write("Введите количество машин: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Car c = new Car();
            Console.Write("Введите марку машины: ");
            string name = Console.ReadLine();
            Console.Write("Введите год выпуска машины: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Статус чистоты (1 - чистая, 0 - грязная): ");
            int status = Convert.ToInt32(Console.ReadLine());
            c.Brand = name;
            c.Year = year;
            c.Clean = status == 1;
            garage.AddCar(c);
        }

        Console.WriteLine("\nСписок машин в гараже:");
        foreach (var car in garage.GetCars())
        {
            Console.WriteLine(car); 
        }
        Console.WriteLine("\nНачинаем помывку машин:");
        foreach (var car in garage.GetCars())
        {
            cleanerDelegate(car);
        }
        Console.WriteLine("\nСостояние машин после помывки:");
        foreach (var car in garage.GetCars())
        {
            Console.WriteLine(car); 
        }
    }
}

