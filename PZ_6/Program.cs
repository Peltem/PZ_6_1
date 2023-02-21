class Name
{
    static void Main(string[] args)
    {
        Sessia s = new Sessia();
        Sessia n = new Sessia();
        Sessia v   = new Sessia();
        Sessia m = new Sessia();
        Sessia p = new Sessia();
        Sessia o = new Sessia();
        s.Semestr = Convert.ToInt32(Console.ReadLine());
        n.Semestr = Convert.ToInt32(Console.ReadLine());
        v.Semestr = Convert.ToInt32(Console.ReadLine());
        m.Semestr = Convert.ToInt32(Console.ReadLine());
        p.Semestr = Convert.ToInt32(Console.ReadLine());
        o.Semestr = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Семестр = {0}", s.Semestr);
        s.Zacheti = 0;
        n.Zacheti = 0;
        v.Zacheti = 0;
        m.Zacheti = 0;
        p.Zacheti = 0;
        o.Zacheti = 0;
        Console.WriteLine("Зачеты = {0}", s.Zacheti);
        s.Ekzameni = Convert.ToInt32(Console.ReadLine());
        n.Ekzameni = Convert.ToInt32((Console.ReadLine()));
        v.Ekzameni = Convert.ToInt32(Console.ReadLine());
        m.Ekzameni = Convert.ToInt32((Console.ReadLine()));
        p.Ekzameni = Convert.ToInt32((Console.ReadLine()));
        o.Ekzameni = Convert.ToInt32((Console.ReadLine()));
        s.Zachet = Convert.ToInt32(Console.ReadLine());
        Letnaia z = new Letnaia();
        Console.WriteLine("Сдана практика?(Да/Нет)");
        z.Ocenka = Convert.ToString(Console.ReadLine());
        List<Sessia> ses = new List<Sessia>();
        
        ses.AddRange(new[] { s, n, v, m, p, o });
        Console.WriteLine("------------");
        var avg = ses.Average(s => s.Ekzameni);
        var y = ses.Where(i => i.Ekzameni >= avg).ToList();
        y.ForEach(x => x.Show());
        Console.WriteLine("------------"); 

        var zateti = ses.Where(s => s.Zacheti > 0 && s.Zacheti < 4).ToList();
        zateti.ForEach(x => x.Show());
        Console.WriteLine("------------");
        s.Show();

    }
    public class Sessia
    {
        private int _semestr;
        private int _zacheti;
        private int _ekzameni;
        private int _zachet;
        public int Semestr
        {
            get { return _semestr; }
            set
            {
                if (1 <= value && value <= 8) { _semestr = value; Console.WriteLine(_semestr.ToString()); } else { Console.WriteLine("Не кринжуй"); }
            }
        }
        public int Zacheti
        {
            get { return _zacheti; }
            set
            {

                if (Semestr != 0 && (Semestr == 3 || Semestr == 7))
                {
                    _zacheti = 3;
                }
                else if (Semestr != 0 && (Semestr == 5 || Semestr == 6))
                {
                    _zacheti = 4;
                }
                else { _zacheti = 5; }
            }
        }
        public int Ekzameni
        {
            get { return _ekzameni; }
            set
            {
                if (value <= 4)
                {
                    _ekzameni = value; Console.WriteLine("Кол-во Экзамен = {0}", _ekzameni.ToString());
                }
                else
                {
                    Console.WriteLine("Максимум 4 экзамена");
                }
            }
        }
        public int Zachet
        {
            get { return _zachet; }
            set
            {
                if (value >= _zacheti)
                {
                    _zachet = value;
                    Console.WriteLine("Зачетено");
                }
                else
                {
                    _zachet = value;
                    Console.WriteLine("Не зачтено");
                }

            }

        }
        public void Show()
        {
            List<string> list = new List<string>();
            list.Add(Semestr.ToString());
            list.Add(Zacheti.ToString());
            list.Add(Ekzameni.ToString());
            list.Add(Zachet.ToString());
            Console.WriteLine("Семестр = " + list[0] + " " + "Зачеты = " + list[1] + " " + "Экзамены = " + list[2] + " " + "Сданные зачеты = " + list[3]);
            foreach (string v in list)
            { Console.WriteLine(v); }


        }
    }
    public class Letnaia : Sessia
    {
        private string _ocenka;
        public string Ocenka
        {
            get { return _ocenka; }
            set
            {
                if (value == "Да" || value == "да" || value == "ДА")
                {
                    Console.WriteLine("з/т");
                }
                else if (value == "Нет" || value == "нет" || value == "НЕТ" || value == "НЕт" || value == "НеТ")
                {
                    Console.WriteLine("н/зт");
                }
                else { Console.WriteLine("н/ат"); }


            }
        }

    }
}
