// See https://aka.ms/new-console-template for more information

string pangram = "The quick brown fox jumps over the lazy dog";
string[] wordArray = pangram.Split(" ");
int counter = 0;

foreach(string word in wordArray){
    char[] letterArray = word.ToCharArray();
    Array.Reverse(letterArray);
    wordArray[counter] = String.Join("", letterArray);
    counter += 1;
}

Console.WriteLine(String.Join(" ", wordArray));
