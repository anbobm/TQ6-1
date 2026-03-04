using System;

class Program
{
    static void Main()
    {
        double kath1 = Convert.ToDouble(Console.ReadLine());
        double kath2 = Convert.ToDouble(Console.ReadLine());
        double hypo = Math.Sqrt(Math.Pow(kath1, 2) + Math.Pow(kath2, 2));
        Console.WriteLine(hypo);
    }
}
