internal class Program
{
    private static void Main(string[] args)
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

        Console.WriteLine(Convert.ToInt32("f10101", 16));

        // Ganzzahlige Division (links und rechts vom / ist ganzzahlig)
        var quotient_int = 7 / 2;
        Console.WriteLine(quotient_int);

        // Gebrochenzahlige Division (links oder rechts vom / ist gebrochen)
        var quotient_double = 7 / 2.0;
        Console.WriteLine(quotient_double);
    }
}

// 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 
// 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 