// See https://aka.ms/new-console-template for more information

using System.Numerics;
UI.MainLoop();

class UI {
    public static void MainLoop(){
        while(true){
            Console.Clear();
            PrintMainMenu();
            string userInput = ReadUserInput();
            int number = 0;
            bool validInput = false;
            if(userInput == "q")break;
            switch(userInput){
                case "1":
                    Console.Clear();
                    PrintIsPrimeMenu();
                    userInput = ReadUserInput();
                    validInput = int.TryParse(userInput, out number);
                    if(!validInput){
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                    }
                    bool isPrime = NumberTools.IsPrime(number);
                    Console.Clear();
                    if(isPrime)Console.WriteLine($"{number} ist eine Primzahl. :)");
                    if(!isPrime)Console.WriteLine($"{number} ist keine Primzahl. :(");
                    break;
                case "2":
                    Console.Clear();
                    PrintFactorialMenu();
                    userInput = ReadUserInput();
                    validInput = int.TryParse(userInput, out number);
                    if(!validInput){
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"{number}! = {NumberTools.Factorial(number).ToString("N0")}");
                    break;
                case "3":
                    Console.Clear();
                    PrintPrimeSearchMenu();
                    userInput = ReadUserInput();
                    var minMax = userInput.Split(' ');
                    Console.WriteLine(minMax.Length);
                    validInput = minMax.Length == 2;
                    if(!validInput){
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                    }
                    int min = 0;
                    int max = 0;
                    bool minValid = int.TryParse(minMax[0], out min);
                    bool maxValid = int.TryParse(minMax[1], out max);
                    if(!minValid || !maxValid){
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                    }
                    Console.Clear();
                    NumberTools.PrintPrimesInRange(min, max);
                    break;
                case "4":
                    Console.Clear();
                    PrintDigitSumMenu();
                    userInput = ReadUserInput();
                    validInput = int.TryParse(userInput, out number);
                    if(!validInput){
                        Console.WriteLine("Ungültige Eingabe");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"Die Quersumme von {number} ist {NumberTools.SumOfDigits(number)}");
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
            QuitDialog();
            userInput = ReadUserInput();
            if(userInput == "q")break;
        }
    }

    public static void PrintMainMenu(){
        Console.WriteLine("Zahlen-Werkzeuge");
        Console.WriteLine("[1] Primzahlenprüfer");
        Console.WriteLine("[2] Fakultät");
        Console.WriteLine("[3] Primzahlensuche");
        Console.WriteLine("[4] Quersumme");
        Console.WriteLine("[q] Beenden");
        Console.Write("Was möchtest du tun? ");
    }

    public static void QuitDialog(){
        Console.WriteLine("[w] Zum Hauptmenü");
        Console.WriteLine("[q] Beenden");
        Console.Write("Was möchtest du tun? ");
    } 

    public static void PrintDigitSumMenu(){
        Console.WriteLine("Quersumme");
        Console.Write("Bitte gib die gewünschte Zahl ein: ");
    }

    public static void PrintIsPrimeMenu(){
        Console.WriteLine("Primzahlenprüfer");
        Console.Write("Bitte gib die gewünschte Zahl ein: ");
    }

    public static void PrintFactorialMenu(){
        Console.WriteLine("Fakultät berechnen");
        Console.Write("Bitte gib die gewünschte Zahl ein: ");
    }

    public static void PrintPrimeSearchMenu(){
        Console.WriteLine("Finde alle Primzahlen in einem Bereich");
        Console.Write("[min max] Suchbereich: ");
    }

    public static string ReadUserInput(){
        string? userInput = "";
        userInput = Console.ReadLine();
        if(userInput != null){
            return userInput;
        }
        return "";
    }
}

class NumberTools {
    public static int SumOfDigits(int n){
        int sum = 0;
        foreach(char digit in n.ToString()){
            sum+=int.Parse(digit.ToString());
        }
        return sum;
    }

    public static bool IsPrime(int n){
        if(n < 2)return false;
        if(n == 2)return true;
        if(n % 2 == 0)return false;
        for(int i = 3; i<=Math.Ceiling(Math.Sqrt(n)); i+=2){
            if(n % i == 0)return false;
        }
        return true;
    }

    // Long is really not a good type for Factorial calculations.
    // Replaced with BigInteger.
    public static BigInteger Factorial(int n){
        if(n < 0)return -1;
        if(n == 0)return 1;
        BigInteger factorial = 1;
        for(int i=1; i<=n; i+=1){
            factorial *= i;
        }
        return factorial;
    }

    public static void PrintPrimesInRange(int start, int end){
        Console.WriteLine($"{CountPrimesInRange(start, end)} Primzahlen zwischen {start} und {end} gefunden:");
        var primeList = new List<int>();
        for(int i=start; i<=end; i+=1){
            if(IsPrime(i))primeList.Add(i);
        }
        foreach(int prime in primeList){
            Console.WriteLine($"\t{prime}");
        }
    }

    public static int CountPrimesInRange(int start, int end){
        int primeCounter = 0;
        for(int i=start; i<=end; i+=1){
            if(IsPrime(i))primeCounter += 1;
        }
        return primeCounter;
    }
}
