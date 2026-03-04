Console.WriteLine("Guten Tag, wir berechnen heute eine Hypothenuse!");
Console.WriteLine("Wie lang ist die 1. Kathete:");

var kathete1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Wie lang ist die 2. Kathete:");

var kathete2 = Convert.ToInt32(Console.ReadLine());

var hypothenuse = Math.Sqrt(Math.Pow(kathete1, 2) + Math.Pow(kathete2, 2));

System.Console.WriteLine($"Die Hypothenuse ist {hypothenuse} lang.");