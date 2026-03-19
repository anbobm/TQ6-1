internal class Program
{
    private static void Main(string[] args)
    {
        // Klassenbibliothek();
        // ZusammengesetzteZuweisung();
        // Typumwandlungen();
        // Division();
        // IfElse();
        // Switch();
        // Begrüßung("Max");
        // Lösung();
        // Arrays();
        // Linq();
        // ArraySort();
        // Dictionaries();
        // Tupel();
        // Exceptions();
        // Vererbung();
        // ArraySortWithComparer();
        // PasswortStärke();
        // PasswortStärke();
        // TextStatistik();
        // NumberToolsTest();
        // Autofahn();
        TestLogger();
    }

    static void TestLogger()
    {
        ILog console = new ConsoleLogger();
        console.LogInfo("Server gestartet");
        console.LogWarning("Speicher niedrig");
        console.LogError("Verbindung getrennt");

        ILog file = new FileLogger("log.txt");
        file.LogInfo("Server gestartet");
        file.LogWarning("Speicher niedrig");
        file.LogError("Verbindung getrennt");
    }

    static void Autofahn()
    {
        var cabrio1 = new Cabrio2("BMW", "3er", 2000);
        cabrio1.DisplayInfo();

        var auto1 = new Auto2("FooW", "Fooran", 1999);

        var auto2 = new Auto2("Trabant", "P 60", 2005);

        auto1.DisplayInfo();
        auto2.DisplayInfo();
        auto2.Modell = "P 601";
        auto2.DisplayInfo();
        auto2.Marke = "Opel";
        auto2.DisplayInfo();
        auto2.Marke = "FooW";
        auto2.DisplayInfo();
        auto2.Modell = "alksdj";
        auto2.DisplayInfo();
    }

    static void NumberToolsTest()
    {
        Console.WriteLine($"35 prim: {NumberTools.IsPrime(35)}");
        Console.WriteLine($"2 prim: {NumberTools.IsPrime(2)}");
        Console.WriteLine($"17 prim: {NumberTools.IsPrime(17)}");
        Console.WriteLine($"65537 prim: {NumberTools.IsPrime(65537)}");
        Console.WriteLine($"114713 prim: {NumberTools.IsPrime(114713)}");
        Console.WriteLine($"{2147483647} prim: {NumberTools.IsPrime(2147483647)}");

        NumberTools.PrintPrimesInRange(0, 100);
        Console.WriteLine();

        Console.WriteLine($"5! = {NumberTools.Factorial(5)}");
        Console.WriteLine($"10! = {NumberTools.Factorial(10)}");
        Console.WriteLine($"52! = {NumberTools.Factorial(52)}");
    }

    static void TextStatistik()
    {
        Console.WriteLine(TextStatistikTool.CountLetters("Hallo Welt von C#"));
        Console.WriteLine(TextStatistikTool.CountVowels("Hallo Welt von C#"));
        Console.WriteLine(TextStatistikTool.CountWords("Hallo  Welt von C#"));
    }

    static void PasswortStärke()
    {
        PasswortStärkePrüfer.PrintStrengthReport("a2sD!");
        PasswortStärkePrüfer.PrintStrengthReport("a2saaafgdD!");
        PasswortStärkePrüfer.PrintStrengthReport("aasdassD!");
        PasswortStärkePrüfer.PrintStrengthReport("aaaaaaaaaaaaaa");
    }

    static void ArraySortWithComparer()
    {
        Mitarbeiter[] array = [new Mitarbeiter(11), new Mitarbeiter(1000),
        new Mitarbeiter(10000000), new Mitarbeiter(0)];

        Array.Sort(array);

        Array.Sort(array, new MitarbeiterComparer());

        foreach(var el in array)
        {
            Console.WriteLine(el.Gehalt);
        }
    }

    class Mitarbeiter : IComparable<Mitarbeiter>
    {
        public int Gehalt { get; set; }

        public Mitarbeiter(int gehalt)
        {
            Gehalt = gehalt;
        }

        public int CompareTo(Mitarbeiter? other)
        {
            return Gehalt.CompareTo(other?.Gehalt);
        }
    }

    class MitarbeiterComparer : IComparer<Mitarbeiter>
    {
        public int Compare(Mitarbeiter? x, Mitarbeiter? y)
        {
            return x!.Gehalt.CompareTo(y!.Gehalt);
        }
    }

    static void TestAuto2()
    {
        Auto2 auto1 = new Auto2("BMW", "3er", 2020);
        Auto2 auto2 = new Auto2("Opel", "Corsa", 2018);
        Auto2 auto3 = new Auto2("Trabant", "P 50", 2022);

        auto1.DisplayInfo();
        auto2.DisplayInfo();
        auto3.DisplayInfo();
    }

    private static void Dictionaries()
    {
        var dict = new Dictionary<string, int>();
        dict["foo"] = 1234;
        dict.Add("bar", 6789);

        var dict2 = new Dictionary<string, string>()
        {
            {"foo", "bar"},
            {"bla", "blub"}
        };

        var ausgelesenerWert = dict["foo"];

        int wert = 5;

        dict.ContainsKey("asdasdasd");
        dict.TryGetValue("asdasdasd", out wert);

        Console.WriteLine(wert);

        foreach(var values in dict.Values)
        {
            Console.WriteLine($"Wert: {values}");
        }
    }

    private static void ArraySort()
    {
        int[] grades = new int[]{78, 92, 99, 37, 81};

        Array.Sort(grades);

        foreach(int number in grades){
            Console.Write(number + ", ");
        }
    }

    private static void Linq()
    {
        int[] grades = {78, 92, 99, 37, 81};
        int min = grades.Min();
        int sum = grades.Sum();
        var avg = grades.Average();

        Console.WriteLine($"The sum of the grades is {sum}. The smallest grade is {min}. The average is {avg}");
    }

    static void Arrays()
    {
        int[] zahlen = new int[30];
        var random = new Random();

        for(int i = 0; i < zahlen.Length; i++)
        {
            zahlen[i] = random.Next(1, 101);
        }

        foreach(var zahl in zahlen)
        {
            Console.Write($"{zahl}, ");
        }
    }

    static void Lösung()
    {
        Console.WriteLine("Gib Zahl!");
        var zahl = Convert.ToInt32(Console.ReadLine());

        var summe = 0;
        Console.Write("(");
        int i = 1;
        while(i <= zahl)
        {
            if (i > 1)
            {
                Console.Write(" + ");
            }
            Console.Write(i);
            summe += i;
            i++;
        }
        Console.WriteLine($") * 2 = {summe * 2}");
    }

    static void Klassenbibliothek()
    {
        Console.WriteLine(Math.Max(3,4));
        Console.WriteLine(Math.Min(3,4));
        Console.WriteLine(Math.Abs(-12));
        Console.WriteLine(Math.Round(2.5));
        Console.WriteLine(Math.Round(-2.015, 2, MidpointRounding.AwayFromZero));
        Console.WriteLine(Math.Round(-2.015, 2, MidpointRounding.ToZero));
        Console.WriteLine(Math.Ceiling(2.0001));
        Console.WriteLine(Math.Floor(2.0001));
        Console.WriteLine(Math.Sqrt(81));
        Console.WriteLine(Math.Pow(2, 8));

        var random = new Random();
        Console.WriteLine(random.Next());

        var file = File.ReadLines("foo.txt");
    }

    static void ZusammengesetzteZuweisung()
    {
        int foo = 0;

        foo += 5;
        foo -= 7;
        foo /= 3;
        foo *= 4;
    }

    static void Typumwandlungen()
    {
        int zahl = 3218238;
        long große_zahl = zahl;

        große_zahl = 2_147_483_648;
        zahl = (int) große_zahl;
        Console.WriteLine(zahl);

        zahl = 3218238;
        double kommazahl = zahl;

        kommazahl = 3.5;
        zahl = (int) kommazahl;
        Console.WriteLine(zahl);

        Console.WriteLine(Convert.ToInt32("32512"));
        Console.WriteLine(Convert.ToInt32("CAFE", 16));
        Console.WriteLine(Convert.ToInt32("10010101101", 2));
    }

    static void Division()
    {
        var quotient_int = 7 / 2;
        Console.WriteLine(quotient_int);

        var quotient_double = 7 / 2.0;
        Console.WriteLine(quotient_double);
    }

    static void Begrüßung(string name)
    {
        Console.WriteLine($"Willkommen im Kurs, {name}!");
    }

    static void IfElse()
    {
        var eingabe = Convert.ToInt32(Console.ReadLine());

        if (eingabe < 0)
        {
            Console.WriteLine("Kleiner Null");
        }
        else if (eingabe == 42)
        {
            Console.WriteLine("Die Antwort.");
        }
        else if (eingabe > 50)
        {
            Console.WriteLine("Frührente");
        }
        else
        {
            Console.WriteLine(false);
        }
    }

    static void Switch()
    {
        Console.WriteLine("[1] Begrüßen\n[2] Verabschieden\n[E] Ende");

        var eingabe = Console.ReadLine();

        switch(eingabe)
        {
            case "1":
                Console.WriteLine("Hallo!");
                break;
            case "2":
                Console.WriteLine("SCHÖSS!");
                break;
            case "E":
                Console.WriteLine("Beenden...");
                break;
            default:
                Console.WriteLine("Keine Ahnung was das soll");
                break;
        }
    }

    static void AufagbeArray()
    {
        Random rnd = new Random();

        int[] zahlen = new int[30];

        for (int i = 0; i < zahlen.Length; i++)
        {
            zahlen[i] = rnd.Next(1, 101);
        }

        for (int i = 0; i < zahlen.Length; i++)
        {
            Console.WriteLine(zahlen[i]);
        }
    }
}
