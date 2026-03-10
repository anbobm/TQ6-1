// See https://aka.ms/new-console-template for more information

string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

foreach (string myString in myStrings){
    string mySubString = myString;
    int dotIndex = mySubString.IndexOf(".");
    if(dotIndex == -1){
        Console.WriteLine(myString);
    }
    while(dotIndex > -1){
        Console.WriteLine(mySubString.Substring(0, dotIndex).TrimStart());
        mySubString = mySubString.Substring(dotIndex+1, mySubString.Length - dotIndex - 1);
        dotIndex = mySubString.IndexOf(".");
        if(dotIndex == -1){
            Console.WriteLine(mySubString.TrimStart());
        }
    }
}
