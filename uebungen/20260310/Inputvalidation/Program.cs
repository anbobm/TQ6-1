// See https://aka.ms/new-console-template for more information

string? userInput; //Nullable String

int inputValue = 0;
bool validInput = false;

Console.WriteLine("Please enter a number between 5 and 10 (min max included)");
do{
    userInput = Console.ReadLine();
    validInput = int.TryParse(userInput, out inputValue);
    if(validInput && (inputValue > 10 || inputValue < 5)){
        validInput = !validInput;
    }
    if(!validInput){
        Console.WriteLine($"Your input \"{userInput}\" is not valid. Please try again.");
    }
}while(!validInput);

Console.WriteLine($"Your input \"{userInput}\" is valid.");
