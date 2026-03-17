// Zahlen-Werkzeuge (Primzahlen & Fakultät)
// Methoden
// bool IsPrime(int n)
// long Factorial(int n)
// void PrintPrimesInRange(int start, int end)
// int CountPrimesInRange(int start, int end)
// Regeln
// Factorial gibt -1 zurück bei ungültiger Eingabe (z. B. negative Zahlen)
// PrintPrimesInRange gibt alle Primzahlen im Bereich aus
// Bonus
// int SumOfDigits(int n)
// Diese Methode soll die Quersumme einer Zahl berechnen.

static class NumberTools
{
    public static bool IsPrime(long n)
    {
        // n prim?
        //  2, 3, 4, 5, 6, 7, 8, 9, 10, 11.. , n-1 teilt n?
        
        if (n < 2)
        {
            return false;
        }

        if (n == 2)
        {
            return true;
        }

        if (n % 2 == 0)
        {
            return false;
        }

        for (var i = 3; i <= (int)Math.Sqrt(n); i += 2)
        {
            if(n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void PrintPrimesInRange(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            if(IsPrime(i))
            {
                Console.Write($"{i}, ");
            }
        }
    }

    public static int CountPrimesInRange(int start, int end)
    {
        var count = 0;

        for (int i = start; i <= end; i++)
        {
            if(IsPrime(i))
            {
                count += 1;
            }
        }

        return count;
    }

    public static int Factorial(int n)
    {
        if (n < 0)
        {
            return -1;
        }

        int product = 1;

        for (int i = 1; i <= n; i++)
        {
            // product = product * i;
            product *= i;
        }

        return product;
    }
}

// 0! = 1
// 1! = 1
// 5! = fakultät(5) = 5 * 4! = 5 * 4 * 3 * 2 * 1

