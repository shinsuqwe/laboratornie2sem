/* Дана строка, в которой присутствуют открывающиеся и закрывающиеся круглые, квадратные и 
фигурные скобки. Необходимо используя элементы коллекции стек определить, правильно ли 
расставлены скобки */
using System;
using System.Collections.Generic;
class Programm
{
    static void Main()
    {
        Console.WriteLine("Введите строку с круглыми, квадратными и фигурными скобками:");
        string n = Console.ReadLine();
        Stack<char> stack = new Stack<char>();
        bool check = true;
        foreach (char ch in n)
        {
            if (ch == '(' || ch == '[' || ch == '{')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}')
            {
                if (stack.Count == 0)
                {
                    check = false;
                    break;
                }
                char top = stack.Pop();
                if ((ch == ')' && top != '(') ||
                    (ch == ']' && top != '[') ||
                    (ch == '}' && top != '{'))
                {
                    check = false;
                    break;
                }
            }
        }
        if (stack.Count > 0)
        {
            check = false;
        }
        if (check)
        {
            Console.WriteLine("Скобки расставлены правильно.");
        }
        else
        {
            Console.WriteLine("Скобки расставлены неправильно.");
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("Стек пустой.");
        }
        else
        {
            Console.WriteLine("Стек не пустой. Остались незакрытые скобки.");
        }
    }
}
//Намятова Анастасия ФИТ-242
