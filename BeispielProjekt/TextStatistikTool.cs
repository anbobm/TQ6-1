// Aufgabenstellung
// Implementiere folgende Methoden:
// int CountLetters(string text, bool countSpaces = false)
// int CountVowels(string text, string vowels = "aeiouAEIOU")
// int CountWords(string text)
// void PrintTextStats(string text)
// Regeln
// •
// CountLetters zählt Buchstaben (Leerzeichen nur, wenn countSpaces == true)
// •
// CountWords zählt Wörter, getrennt durch Leerzeichen
// •
// Mehrere Leerzeichen zählen nicht als mehrere Wörter
// •
// PrintTextStats gibt alle Ergebnisse formatiert aus
// Beispiel
// Eingabe:
// Hallo Welt von C#
// Ausgabe:
// Buchstaben: 14
// Vokale: 4
// Wörter: 4

public class TextStatistikTool
{
    public static int CountLetters(string text, bool countSpaces = false)
    {
        var count = 0;
        
        foreach(var c in text)
        {
            if (char.IsAsciiLetter(c) || c == '#' || countSpaces && char.IsWhiteSpace(c)) {
                count += 1;
            }
        }

        return count;
    }

    public static int CountVowels(string text, string vowels = "aeiouAEIOU")
    {
        var count = 0;
        
        foreach(var c in text)
        {
            if (vowels.Contains(c)) {
                count += 1;
            }
        }

        return count;
    }

    public static int CountWords(string text)
    {
        var wörter = text.Split(" ");
        
        var count = 0;

        foreach(var wort in wörter)
        {
            // Leere Wörter nicht mitzählen
            if (wort != "")
            {
                count += 1;
            }
        }

        return count;
    }
}

// 0000 bis   FFFF
// 0000 bis 10FFFF