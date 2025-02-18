/******************* 
Лабораторная работа №2 за 14.02. Задание: 
1. Бакзовый класс с одним полем - наименование
2. 3 класса наследника: 
    1 класс. окружность, поле будет хранить числовое значение радиуса
    2 класс. квадрат, числовое поле будет хранить длину стороны 
    3 класс. равносторлнрий треугольник, поле будет хранить длину одной из сторон
3. интерфейс, который будет включать два метода: определение периметра и определение площади.

каждый из 3 классов является наследником базового и наследником интерфейса, соответственно 
включает в себя реализацию интерфейса. необходимо в основной программе создать 3 объекта и 
выдать для каждого периметр и площадь. 
*******************/
class Geometry
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }


    public interface IGeometry
    {
        double Perimeter();
        double Square_footage();
    }
    class Circle : Geometry, IGeometry
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }
        public double Perimeter()
        {
            return 2 * 3.14 * Radius;
        }
        public double Square_footage()
        {
            return 3.14 * Radius * Radius;
        }
    }
    class Square : Geometry, IGeometry
    {
        private double _side_square;
        public double Side_square
        {
            get => _side_square;
            set => _side_square = value;
        }
        public double Perimeter()
        {
            return 4 * Side_square;
        }
        public double Square_footage()
        {
            return Side_square * Side_square;
        }
    }
    class Equilateral_triangle : Geometry, IGeometry
    {
        private double _side_triangle;
        public double Side_triangle
        {
            get => _side_triangle;
            set => _side_triangle = value;
        }
        public double Perimeter()
        {
            return 3 * Side_triangle;
        }
        public double Square_footage()
        {
            return Math.Sqrt(3) * 2 * Side_triangle / 4;
        }
    }

    class MainProgram
    {
        static void Main()
        {
            Circle object1 = new Circle();
            Console.Write("Ввведите имя окружности: ");
            string name_krug = Console.ReadLine();
            object1.Name = name_krug;
            Console.Write($"Введите значение радиуса окружности: ");
            double rad = Convert.ToDouble(Console.ReadLine());
            object1.Radius = rad;

            Square object2 = new Square();
            Console.Write("Ввведите имя квадрата: ");
            string name_square = Console.ReadLine();
            object2.Name = name_square;
            Console.Write($"Введите значение сторон квадрата: ");
            double ssq = Convert.ToDouble(Console.ReadLine());
            object2.Side_square = ssq;

            Equilateral_triangle object3 = new Equilateral_triangle();
            Console.Write("Ввведите имя треугольника: ");
            string name_triangle = Console.ReadLine();
            object3.Name = name_triangle; 
            Console.Write($"Введите значение стороны треуольника: ");
            double str = Convert.ToDouble(Console.ReadLine());
            object3.Side_triangle = str;

            Console.WriteLine($"Периметр окружности = {object1.Perimeter()}");
            Console.WriteLine($"Площадь окружности = {object1.Square_footage()}");
            Console.WriteLine($"Периметр квадрата = {object2.Perimeter()}");
            Console.WriteLine($"Площадь квадрата = {object2.Square_footage()}");
            Console.WriteLine($"Периметр окружности = {object3.Perimeter()}");
            Console.WriteLine($"Площадь окружности = {object3.Square_footage()}");
        }
    }
}
//Намятова Анастасия Валерьевна ФИТ-242