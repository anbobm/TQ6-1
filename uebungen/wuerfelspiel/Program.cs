// See https://aka.ms/new-console-template for more information

//Message.renderRolls(Dice.rollMany(5));

var gameController = new GameController();
Message.renderScoreSheet(gameController.ScoreSheet);
Message.renderTurnOptions(gameController.Turn, gameController.Rolls);

while(true){
    string userInput = "";
    Console.Write("Deine Wahl? ");
    string? userInputRaw = Console.ReadLine();
    if(userInputRaw != null){
        userInput = userInputRaw.Trim().ToLower();
    }
    switch(userInput){
        case "r":
            if(gameController(checkLegalChoice())){
                gameController.rollDices();
            }
        case "q":
            break
    }
    if(userInput == "q"){
        break;
    }
}

class Score {
    public string Name {get; set;}
    public int Points {get; set;}
    public bool Open {get; set;} = true;

    public Score(string name, int points){
        Name = name;
        Points = points;
    }
}

class Player {
    public string Name {get; set;}
    public ScoreSheet ScoreSheet {get; set;} = new ScoreSheet()
}

class GameController {
    public ScoreSheet ScoreSheet = new ScoreSheet();
    public int Turn = 1;
    public int Rolls = 0;
}

class Message {
    public static List<string> DiceSymbols = new List<string>(["⚀", "⚁", "⚂", "⚃", "⚄", "⚅"]);

    public static void renderRolls(List<int>rolls){
        Console.WriteLine(string.Join(" ", rolls));
    }

    public static void renderScoreSheet(ScoreSheet scoreSheet){
        int optionCounter = 1;
        foreach(Score score in scoreSheet.Score){
            if(optionCounter==7){
                Console.WriteLine($"{scoreSheet.Conclusion[0].Name} \t\t {scoreSheet.Conclusion[0].Points}");
                Console.WriteLine($"{scoreSheet.Conclusion[1].Name} \t\t\t {scoreSheet.Conclusion[1].Points}");
                Console.WriteLine($"{scoreSheet.Conclusion[2].Name} \t\t\t {scoreSheet.Conclusion[2].Points}");
                optionCounter += 1;
                continue;
            }
            string scoreMsg = $"[{optionCounter.ToString().PadLeft(2, ' ')}] {score.Name}";
            if(score.Name.Length < 10){scoreMsg += "\t\t\t";}
            if(score.Name.Length >= 10){scoreMsg += "\t\t";}
            if(!score.Open){scoreMsg += score.Points; } 
            
            Console.WriteLine(scoreMsg);
            optionCounter += 1;
        }
        Console.WriteLine($"{scoreSheet.Conclusion[3].Name} \t\t {scoreSheet.Conclusion[3].Points}");
        Console.WriteLine($"{scoreSheet.Conclusion[4].Name} \t\t\t {scoreSheet.Conclusion[4].Points}");
    }

    public static void renderTurnOptions(int turn, int roll){
        if(roll == 0){
            Console.WriteLine("[R]: Würfeln");
            Console.WriteLine("[Q]: Beenden");
        }
    }

}

class Dice {
    public static Random random {get; set;} = new Random();
    public static int rollOne(){
        return random.Next(1, 7);
    }
    public static List<int> rollMany(int amount){
        List<int> rolls = new List<int>();
        for(int i=0; i<amount; i+=1){
            rolls.Add(rollOne());
        }
        return rolls;
    }
}

class Turn {
    public int tries {get; set;} = 0;
    public List<List<int>> rolls {get; set;} = [];

    public string currentRoll(){
        List<string> dices = new List<string>(["⚀", "⚁", "⚂", "⚃", "⚄", "⚅"]);
        string currRoll = "";
        foreach(int val in rolls){
            currRoll += $"{dices[val-1]} ";
        }
        return currRoll;
    }

    public List<int> rollAll(){
        var random = new Random();
        for(int i=0; i<5; i+=1){
            rolls.Add(random.Next(1, 7));
        }
        return rolls;
    }
}

class ScoreSheet {
    public List<Score> Score = new List<Score>{
        new Score("⚀ ⚀ ⚀", 0),
        new Score("⚁ ⚁ ⚁", 0),
        new Score("⚂ ⚂ ⚂", 0),
        new Score("⚃ ⚃ ⚃", 0),
        new Score("⚄ ⚄ ⚄", 0),
        new Score("⚅ ⚅ ⚅", 0),
        new Score("Dreierpasch", 0),
        new Score("Viererpasch", 0),
        new Score("Full-House", 0),
        new Score("Kl. Straße", 0),
        new Score("Gr. Straße", 0),
        new Score("Gr. Kniffel", 0),
    };

    public List<Score> Conclusion = new List<Score>{
        new Score("P. Oben", 0),
        new Score("Bonus", 0),
        new Score("Total", 0),
        new Score("P. Unten", 0),
        new Score("Total", 0),
    };

    public int scoreUpper(List<int>roll, int eyes){
        foreach(int dice in roll){
            Score[eyes-1].Points += dice;
        }
        Score[eyes-1].Open = false;
        return Score[eyes-1].Points;
    }


}

//List<Int32> = new List(Int32);
//core.Add(5);




/*
class ScoreSheet {
    list score = new List(Int32)
}

Console.WriteLine("[1]: 1er:")
*/
