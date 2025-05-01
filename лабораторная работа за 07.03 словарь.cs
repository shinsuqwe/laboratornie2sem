/*Лабораторная за 07.03
дан список из экземпляров класса телефон где каждая запись характеризуется номером, 
фио владельца, оператор подключения необходимо с помощью элемента коллекции словарь 
определить частоту использования оператора связи*/
class Program
{
    class Phone
    {
        private string _number;
        private string _name;
        private string _operator;

        public string Number
        {
            get { return _number; } set { _number = value; }
        }
        public string Name
        {
            get { return _name; } set { _name = value; }
        }
        public string Operator
        {
            get { return _operator; } set { _operator = value; }
        }
        static void Main()
        {
            List<Phone> phones = new List<Phone>();
            Console.Write("Введите количество номеров: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите номер {i + 1}: ");
                string number = Console.ReadLine();
                Console.Write($"Введите ФИО человека, которому принадлежит номер {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Введите оператора номера {i + 1}: ");
                string oper = Console.ReadLine();
                phones.Add(new Phone { Number = number, Name = name, Operator = oper });
            }
            Dictionary<string, int> frequencyOfOccurence = new Dictionary<string, int>();
            foreach (var phone in phones)
            {
                if (frequencyOfOccurence.ContainsKey(phone.Operator))
                {
                    frequencyOfOccurence[phone.Operator]++;
                }
                else
                {
                    frequencyOfOccurence[phone.Operator] = 1;
                }
            }
            Console.WriteLine("Частота использования операторов: ");
            foreach (var value in frequencyOfOccurence)
            {
                Console.WriteLine($"Оператор {value.Key} встречается {value.Value} раз(-а)");
            }
        }
    }
}



