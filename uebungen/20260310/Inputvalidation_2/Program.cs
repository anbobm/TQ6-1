// See https://aka.ms/new-console-template for more information

List<string> validRoles = new List<string> {"administrator", "manager", "user"};
string? userInput;
string sanitizedInput = "";
bool validInput = false;

Console.WriteLine("Please enter your role name (Administrator, Manager or User)");

do{
    userInput = Console.ReadLine();
    if(userInput != null){
        sanitizedInput = userInput.ToLower();
        sanitizedInput = sanitizedInput.Trim();
    }
    validInput = validRoles.Contains(sanitizedInput);
    if(!validInput){
        Console.WriteLine($"Unknown role name: {userInput}");
        Console.WriteLine("Please enter your role name (Administrator, Manager or User)");
    }
}while(!validInput);

Console.WriteLine($"Your input {userInput} has been accepted.");
