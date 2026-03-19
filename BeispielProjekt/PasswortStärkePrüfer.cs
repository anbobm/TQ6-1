// Übung 1: Passwort-Stärke-Prüfer
// Lernziele
// Rückgabewerte (bool, int)
// String-Parameter
// Default-Parameter
// Trennung von Logik und Ausgabe
// Aufgabenstellung
// Implementiere folgende Methoden:
// bool HasMinLength(string text, int minLength = 8)
// bool ContainsDigit(string text)
// bool ContainsUppercase(string text)
// bool ContainsSpecialChar(string text, string special = "!@#$%^&*")
// int StrengthScore(string password)
// void PrintStrengthReport(string password)
// Regeln
// StrengthScore gibt einen Wert von 0 bis 4 zurück
// Für jede erfüllte Regel gibt es 1 Punkt
// PrintStrengthReport gibt aus:
// welche Regeln erfüllt sind
// die Gesamtpunktzahl
// Beispielausgabe
// Eingabe:
// Hello123!
// Ausgabe:
// Mindestlänge erfüllt
// Zahl enthalten
// Großbuchstabe enthalten
// Sonderzeichen enthalten
// Stärke: 4 / 4

static class PasswortStärkePrüfer
{
    public static bool HasMinLength(string text, int minLength = 8) 
    {
        return text.Length >= minLength;
    }

    public static bool ContainsDigit(string text)
    {
        foreach (var c in text)
        {
            if (char.IsAsciiDigit(c))
            {
                return true;
            }
        }
        return false;

        // Alternative 1
        // foreach (var c in text)
        // {
        //     if("0123456789".Contains(c))
        //     {
        //         return true;
        //     }
        // }
        // return false;

        // Alternative 9000
        // return text.Any(char.IsAsciiDigit);
    }

    public static bool ContainsUppercase(string text)
    {
        foreach (var c in text)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }
        return false;

        // // Alternative 9000
        // return text.Any(char.IsUpper);
    }

    public static bool ContainsSpecialChar(string text, string special = "!@#$%^&*") 
    {
        foreach (var c in text)
        {
            if (special.Contains(c))
            {
                return true;
            }
        }
        return false;

        // // Alternative 9000
        // return text.Any(special.Contains);
    }

    public static int StrengthScore(string password) 
    {
        var score = 0;

        if(HasMinLength(password))
        {
            score += 1;
        }

        if(ContainsDigit(password))
        {
            score += 1;
        }

        if(ContainsSpecialChar(password))
        {
            score += 1;
        }

        if(ContainsUppercase(password))
        {
            score += 1;
        }

        return score;
    }

    public static void PrintStrengthReport(string password)
    {
        Console.WriteLine($"Kriterien von Passwort {password}:");
        if(HasMinLength(password))
        {
            Console.WriteLine("\tLang jenuch");
        }

        if(ContainsDigit(password))
        {
            Console.WriteLine("\tZiffer drinne");
        }

        if(ContainsSpecialChar(password))
        {
            Console.WriteLine("\tSonderzeichen drinne");
        }

        if(ContainsUppercase(password))
        {
            Console.WriteLine("\tGroßbuchstaben drinne");
        }
        
        Console.WriteLine($"\tPunkte: {StrengthScore(password)} / 4");
    }
}