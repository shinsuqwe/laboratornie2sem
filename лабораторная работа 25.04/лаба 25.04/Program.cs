class Program
{
    static void Main()
    {
        FileInfo file1 = new FileInfo("input.txt");
        StreamReader sr = file1.OpenText();
        string a = null;
        string nums = "1234567890";
        bool check = true;
        List<string> strs = new List<string>();
        while ((a = sr.ReadLine()) != null)
        {
            string num = null;
            foreach (char i in a)
            {
                foreach (char n in nums)
                {
                    if (i == n)
                    {
                        if (num == null)
                        {
                            num = Convert.ToString(i);
                            check = false;
                        }
                        else num = num + i;
                        check = false;
                    }
                }
                if (check == false)
                {
                    if (num.Length > 1) { check = true; continue; }
                    else if (num.Length == 1 && i != a[a.Length - 1]) { check = true; continue; }
                    else
                    {
                        if (Convert.ToInt32(num) % 2 == 0)
                        {
                            strs.Add(a);
                            break;
                        }
                    }
                }
                if (check)
                {
                    if (num != null)
                    {
                        if (Convert.ToInt32(num) % 2 == 0)
                        {
                            strs.Add(a);
                            break;
                        }
                        else num = null;
                    }

                }

            }
        }
        using (StreamWriter sw = new StreamWriter("output.txt"))
        {
            foreach (var i in strs)
            {
                sw.WriteLine(i);
            }
        }
    }
}
