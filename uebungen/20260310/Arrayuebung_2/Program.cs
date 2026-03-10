// See https://aka.ms/new-console-template for more information

int[] randomNumbers = new int[30];

for(int i=0; i<randomNumbers.Length; i+=1){
    Random random = new Random();
    randomNumbers[i] = random.Next(1, 101);
}

foreach(int number in randomNumbers){
    Console.WriteLine(number);
}
