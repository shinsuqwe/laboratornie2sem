/* Лабораторная работа №2 за 04.04
Дан список, состоящий из слов. Необходимо с помощью лямбда-выражений реализовать выборку слов,
которые начинаются на символ а.*/
delegate void Words(List<string> l);
class WordsA
{
    static void Main()
    {
        List<string> words = new List<string>();
        Console.Write("Укажите количество слов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите слово {i+1}: ");
            words.Add(Console.ReadLine());
        }
        foreach (string word in words)
        {
            if (word.Length > 0 && word[0] == 'а' || word.Length > 0 && word[0] == 'А')
            {
                Console.WriteLine($"Слова, начинающиеся на А или а: {word}");
            }
        }
    }
}