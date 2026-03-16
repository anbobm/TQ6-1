// See https://akams/new-console-template for more information

string? userInputRaw = "";
string userInput = "";

do {
    Console.WriteLine("Optionen");
    Console.Write("Zähle Leerzeichen als Buchstaben? [y] ");
    userInputRaw = Console.ReadLine();

    if(userInputRaw != null){
        userInput = userInputRaw;
    }

    bool countSpaces = false;

    if(userInput == "y")countSpaces = true;

    Console.WriteLine("Bitte gib einen Text ein:");
    userInputRaw = Console.ReadLine();
    if(userInputRaw != null){
        userInput = userInputRaw;
    }

    TextStatistikTool.PrintTextStats(userInput, countSpaces);

    Console.Write("Nochmal? (y) ");
    userInputRaw = Console.ReadLine();
    if(userInputRaw != null){
        userInput = userInputRaw;
    }
}while(userInput == "y");

class TextStatistikTool {

    private static int CountLetters(string text, bool countSpaces = false){
        int letterCounter = 0;
        foreach(char c in text){
            if(Char.IsAsciiLetter(c) || (countSpaces && Char.GetUnicodeCategory(c).ToString() == "SpaceSeparator"))letterCounter += 1;
        }
        return letterCounter;
    }

    private static int CountVowels(string text, string vowels="aeiouAEIOU"){
        int vowelCounter = 0;
        foreach(char letter in text){
            if(vowels.Contains(letter))vowelCounter += 1;
        }
        return vowelCounter;
    }

    private static int CountWords(string text){
         string[] subStrings = text.Split(' ');
         return subStrings.Length;
    }

    public static void PrintTextStats(string text, bool countspaces = false){
        Console.WriteLine($"Buchstaben: {CountLetters(text, countspaces)}");
        Console.WriteLine($"Vokale: {CountVowels(text)}");
        Console.WriteLine($"Words: {CountWords(text)}");
    }
}
