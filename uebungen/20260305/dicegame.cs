//var random = new Random(seed)

//erzeugt random integer
//random.Next(min, max)

using System;

class Program {
    static void Main()
    {
        var random = new Random();
        int dice1 = random.Next(1, 7);
        int dice2 = random.Next(1, 7);
        int dice3 = random.Next(1, 7);

        Console.WriteLine($"Gewürfelt: [{dice1}] [{dice2}] [{dice3}]");
    }
}

class Dice
