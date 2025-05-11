//Лабораторная за 28.03 Скачки
/* есть начальная позиция старт и есть финиш. Три объекта - имя и скорость. через заданный момент времени 
случайным образом у каждого объекта меняется скорость.
Обработать событие победы одного из объектов(выдать сообщение о победе такого-то
объекта)*/
public class HorseEvent : EventArgs
{
    public string HorseName { get; set; }
    public double Position { get; set; }
}
class Horse
{
    public string Name { get; }
    public double Position { get; private set; }
    public double Speed { get; private set; }

    public event EventHandler<HorseEvent> Finished;
    public event EventHandler<HorseEvent> PositionChanged;
    public Horse(string name, double speed)
    {
        Name = name;
        Speed = speed;
        Position = 0;
    }
    public void UpdatePosition(double timeStep)
    {
        Position += Speed * timeStep;
        OnPositionUpdated(); 

        if (Position >= Race.FinishLine)
        {
            OnFinished(); 
        }
    }
    public void ChangeSpeed()
    {
        Random rand = new Random();
        double change = rand.NextDouble() * 0.5 - 0.3;
        Speed *= (1 + change);
    }
    protected virtual void OnFinished()
    {
        Finished?.Invoke(this, new HorseEvent { HorseName = Name, Position = Position });
    }
    protected virtual void OnPositionUpdated()
    {
        PositionChanged?.Invoke(this, new HorseEvent { HorseName = Name, Position = Position });
    }
}
static class Race
{
    public static double FinishLine { get; set; } = 100;

    public static void Start(List<Horse> horses, double timeStep)
    {
        bool raceFinished = false;

        while (!raceFinished)
        {
            foreach (var horse in horses)
            {
                horse.ChangeSpeed();
                horse.UpdatePosition(timeStep);
            }
            Console.WriteLine("-------------------------");
        }
    }
}
class Program
{
    static void Main()
    {
        List<Horse> horses = new List<Horse>
        {
            new Horse("Лошадь 1", 5),
            new Horse("Лошадь 2", 6),
            new Horse("Лошадь 3", 6)
        };
        Console.Write("Введите длину дистанции: ");
        Race.FinishLine = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите интервал обновления (в секундах): ");
        double timeStep = Convert.ToDouble(Console.ReadLine());
        foreach (var horse in horses)
        {
            horse.Finished += Horse_Finished;
            horse.PositionChanged += Horse_PositionChanged;
        }
        Race.Start(horses, timeStep);
    }
    private static void Horse_PositionChanged(object? sender, HorseEvent e)
    {
        Console.WriteLine($"{e.HorseName}: текущая позиция — {e.Position:F2}");
    }
    private static void Horse_Finished(object? sender, HorseEvent e)
    {
        Console.WriteLine($"\n!!!Победил: {e.HorseName}!");
        Environment.Exit(0); 
    }
}