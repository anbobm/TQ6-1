using System.Runtime.CompilerServices;

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
        System.Console.WriteLine(zahl); // -2^31

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
            System.Console.WriteLine("Kleiner Null");
        }
        else if (eingabe == 42)
        {
            System.Console.WriteLine("Die Antwort.");
        }
        else if (eingabe > 50)
        {
            System.Console.WriteLine("Frührente");
        }
        else
        {
            System.Console.WriteLine(false);
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