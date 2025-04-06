/* На вход подается список из целых положительных элементов. Необходимо
выдать элементы, с помощью которых составлен список, и частоту появления
каждого элемента. */
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        Console.Write("Введите количество элементов списка: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            int a = Convert.ToInt32(Console.ReadLine());
            list.Add(a);
        }
        list.Sort();
        Dictionary<int, int> rate = new Dictionary<int, int>();
        foreach (int el in list)
        {
            if (rate.ContainsKey(el))
            {
                rate[el]++;
            }
            else
            {
                rate[el] = 1;
            }
        }
        Console.WriteLine("Элементы и их частота появления:");
        foreach (var pair in rate)
        {
            Console.WriteLine($"Элемент {pair.Key}: {pair.Value} раз(-а)");
        }
    }
}
