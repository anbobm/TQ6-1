class Dice {
    public static Random random {get; set;} = new Random();
    
    public static int RollOne(){
        return random.Next(1, 7);
    }
    public static List<int> RollMany(int amount){
        List<int> rolls = new List<int>();
        for(int i=0; i<amount; i+=1){
            rolls.Add(RollOne());
        }
        return rolls;
    }
    public static int RollStartPlayer(int playerCount){
        return random.Next (0, playerCount);
    }

    public static string GetSymbol(int eyes){
        List<string> Symbols = ["⚀", "⚁", "⚂", "⚃", "⚄", "⚅"];
        return Symbols[eyes-1];
    }
}
