using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите постфиксное выражение: ");
        string input = Console.ReadLine();
        string[] tokens = input.Split(new Char[] { ' ' });
        Stack stack = new Stack();
        bool check = true;
        string operators = "+-*/";
        foreach (string token in tokens)
        {
            if (Number(token))
            {
                stack.Push(double.Parse(token));
            }
            else if (operators.Contains(token))
            {
                if (stack.Count < 2)
                {
                    check = false;
                    break;
                }
                double operand2 = (double)stack.Pop();
                double operand1 = (double)stack.Pop();
                double result = Operation(token, operand1, operand2);
                stack.Push(result);
            }
            else
            {
                check = false;
                break;
            }
        }
        if (check && stack.Count == 1)
        {
            Console.WriteLine($"Результат: {stack.Pop()}");
        }
        else
        {
            Console.WriteLine("Некорректное выражение.");
        }
    }
    static bool Number(string token)
    {
        return double.TryParse(token, out _);
    }
    static double Operation(string operation, double operand1, double operand2)
    {
        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                {
                    Console.WriteLine("Деление на ноль.");
                    Environment.Exit(1);
                }
                return operand1 / operand2;
            default:
                Console.WriteLine($"Неизвестный оператор '{operation}'.");
                Environment.Exit(1);
                return 0;
        }
    }
}
