// See https://aka.ms/new-console-template for more information

int pwScore = 0;

do {
    string? userInputRaw = "";
    string userInput = "";

    Console.Write("Bitte gib ein Passwort ein: ");
    userInputRaw = Console.ReadLine();
    if(userInputRaw != null){
        userInput = userInputRaw;
    }

    pwScore = PasswordTester.StrengthScore(userInput);
    PasswordTester.PrintStrengthScore(userInput);
}while(pwScore < 4);

class PasswordTester {

    private static bool HasMinLength(string text, int minLength = 8){
        return text.Length >= minLength;
    }

    private static bool ContainsDigit(string text){
        for(int i=0; i<10; i+=1){
            string digit = i.ToString();
            if(text.Contains(digit))return true;
        }
        return false;
    }

    private static bool ContainsUpperCase(string text){
        foreach(char letter in text){
            char lower = Char.ToLower(letter);
            if(lower != letter)return true;
        }
        return false;
    }

    private static bool ContainsSpecialChar(string text, string special = "!@#$%^&*"){
        foreach(char specialChar in special){
            if(text.Contains(specialChar))return true;
        }
        return false;
    }

    public static int StrengthScore(string password){
        int score = 0;
        if(HasMinLength(password))score += 1;
        if(ContainsDigit(password))score += 1;
        if(ContainsUpperCase(password))score += 1;
        if(ContainsSpecialChar(password))score += 1;
        return score;
    }

    public static void PrintStrengthScore(string password){
        if(HasMinLength(password)){
            Console.WriteLine("Mindestlänge erfüllt.");
        }else{
            Console.WriteLine("Mindestlänge nicht erfüllt.");
        }

        if(ContainsDigit(password)){
            Console.WriteLine("Zahl enthalten.");
        }else{
            Console.WriteLine("Keine Zahl enthalten");
        }

        if(ContainsUpperCase(password)){
            Console.WriteLine("Großbuchstabe enthalten.");
        }else{
            Console.WriteLine("Kein Großbuchstabe enthalten.");
        }

        if(ContainsSpecialChar(password)){
            Console.WriteLine("Sonderzeichen enthalten.");
        }else{
            Console.WriteLine("Kein Sonderzeichen enthalten.");
        }

        Console.WriteLine($"Passwortstärke: {StrengthScore(password)}/4");
    }
}
