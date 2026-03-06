// See https://aka.ms/new-console-template for more information

using System;

class Program {
    static void Main(){
        Console.Write("Gib eine Zahl ein: ");

        int userInput = Convert.ToInt32(Console.ReadLine());

        if(userInput < 0){
            Console.WriteLine("Zahl ist kleiner 0");
        }else if(userInput == 42){
            Console.WriteLine("Zahl ist 42");
        }else if(userInput > 50){
            Console.WriteLine("Zahl ist >50");
        }else{
            Console.WriteLine(false);
        }

        switch(userInput){
            case < 0:
                Console.WriteLine("Zahl ist kleiner 0");
                break;
            case 42:
                Console.WriteLine("Zahl ist 42");
                break;
            case > 50:
                Console.WriteLine("Zahl ist größer 50");
                break;
            default:
                Console.WriteLine(false);
                break;
        }
    }
}
