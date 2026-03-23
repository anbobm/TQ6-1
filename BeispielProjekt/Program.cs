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
        // Logging();
        TestBaujahr();
    }

    static void TestBaujahr()
    {
        var logger = new FakeLogger();
        var auto1 = new Auto("BMW", "3er", 2000, logger);

        auto1.Baujahr = 1700;

        if (logger.Messages.Any(msg => msg == "Es wurde versucht Baujahr auf einen ungültigen Wert (1700) zu setzen."))
        {
            Console.WriteLine("Warnung war da 👍");
        }
    }

    static void Logging()
    {
        var logger = new FileLogger("filelogger.log");

        logger.LogError("Beladung zu groß. Beladung wurde nicht geändert.");
        logger.LogInfo("Es gibt Reis! Baby, Baby, es gibt Reis!");
        logger.LogWarning("Achtung, es ist kalt draußen!");

        var auto1 = new Auto("BMW", "3er", 2000, logger);
        auto1.Baujahr = 1700;
    }

    static void Autofahn()
    {
        var logger = new ConsoleLogger();

        var lkw1 = new Lkw(40000);
        Console.WriteLine(lkw1.Beladung);
        lkw1.Beladung = 40;
        Console.WriteLine(lkw1.Beladung);
        lkw1.Beladung = 100_000;
        Console.WriteLine(lkw1.Beladung);

        var cabrio1 = new Cabrio("BMW", "3er", 2000, logger);
        cabrio1.DisplayInfo();

        var auto1 = new Auto("FooW", "Fooran", 1999, logger);

        var auto2 = new Auto("Trabant", "P 60", 2005, logger);

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

        // Funktioniert, wenn Mitarbeiter IComparable implementiert
        Array.Sort(array);

        // Funktioniert mit übergebenem Comparer
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
            return this.Gehalt - other.Gehalt;
        }
    }

    class MitarbeiterComparer : IComparer<Mitarbeiter>
    {
        public int Compare(Mitarbeiter? x, Mitarbeiter? y)
        {
            return x.Gehalt - y.Gehalt;
        }
    }


    static void Exceptions()
    {
        try
        {
            // Convert.ToInt32("foobar");
            int NULL = 0;
            var foo = 1 / NULL;
        }
        catch(FormatException)
        {
            Console.WriteLine("String war nicht in einem korrekten Format");
        }
    }

    static void Tupel()
    {
        var person = ("Alice", 30, "Dorfweg 1, 01234 Dorf");

        Console.WriteLine(person.Item1);
        Console.WriteLine(person.Item2);
        Console.WriteLine(person.Item3);

        person.Item1 = "Max";

        Console.WriteLine(person);

        var person2 = GetPerson();
    }

    static (string, int)  GetPerson()
    {
        return ("Bob", 25);
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



        // KeyNotFoundException
        // Console.WriteLine(dict["bar"]);

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
        //Output: 37, 78, 81, 92, 99

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
        // Schreibe ein Programm, welches eine Zahl vom Benutzer einliest (z.B. 5)
        // und dann folgende Ausgabe erzeugt:
        // (1 + 2 + 3 + 4 + 5) * 2 = 30
        // Schreibe das Programm einmal mit einer for-Schleife und
        // einmal mit einer while-Schleife.

        Console.WriteLine("Gib Zahl!");
        var zahl = Convert.ToInt32(Console.ReadLine());

        // Alternative 1 mit for
        // var summe = 0;
        // Console.Write("(");
        // for(int i = 1; i <= zahl; i++)
        // {
        //     if (i > 1)
        //     {
        //         Console.Write(" + ");
        //     }
        //     Console.Write(i);
        //     summe += i;
        // }
        // Console.WriteLine($") * 2 = {summe * 2}");

        // Alternative 2 mit for
        // var summe = 0;
        // var liste = new List<string>();
        // for(int i = 1; i <= zahl; i++)
        // {
        //     liste.Add(i.ToString());
        //     summe += i;
        // }
        // Console.WriteLine($"({string.Join(" + ", liste)}) * 2 = {summe * 2}");

        // Alternative 3 mit while
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
        // Methoden der Math-Klasse
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


        // Random-Klasse für Zufallszahlen
        var random = new Random();
        Console.WriteLine(random.Next());

        // File-Klasse für Zugriffe auf das Dateisystem
        var file = File.ReadLines("foo.txt");
    }

    static void ZusammengesetzteZuweisung()
    {
        int foo = 0;

        // Zusammengesetzte Zuweisung

        foo += 5; // foo = foo + 5;
        foo -= 7; // foo = foo - 7;
        foo /= 3; // foo = foo / 3;
        foo *= 4; // foo = foo * 4;
    }

    static void Typumwandlungen()
    {
        // Implizierter Cast von int -> long
        int zahl = 3218238;
        long große_zahl = zahl;

        // Explizierter Cast von long -> int
        // Explizit weil prinzipiell Datenverlust, so wie hier:
        große_zahl = 2_147_483_648;
        zahl = (int) große_zahl;
        Console.WriteLine(zahl); // -2^31

        // Implizierter Cast von int -> double
        zahl = 3218238;
        double kommazahl = zahl; // 3218238.0

        // Expliziert Cast von double -> int
        kommazahl = 3.5;
        zahl = (int) kommazahl;
        Console.WriteLine(zahl);

        // Strings in Zahlen umwandeln
        Console.WriteLine(Convert.ToInt32("32512"));

        // das geht auch mit anderen Basen: 2, 8, 16
        Console.WriteLine(Convert.ToInt32("CAFE", 16));
        Console.WriteLine(Convert.ToInt32("10010101101", 2));
    }

    static void Division()
    {
        // Ganzzahlige Division (links und rechts vom / ist ganzzahlig)
        var quotient_int = 7 / 2;
        Console.WriteLine(quotient_int);

        // Gebrochenzahlige Division (links oder rechts vom / ist gebrochen)
        var quotient_double = 7 / 2.0;
        Console.WriteLine(quotient_double);
    }

    static void Begrüßung(string name)
    {
        // Methode mit Parametern ^^^
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
}