// See https://aka.ms/new-console-template for more information

//Message.renderRolls(Dice.rollMany(5));

//var gameController = new GameController();
//Message.renderScoreSheet(gameController.ScoreSheet);
//Message.renderTurnOptions(gameController.Turn, gameController.Rolls);

var uiController = new UIController();
uiController.InitGame();

class UIController(){

    private string? UserInputRaw = "";
    private string UserInput = "";
    private GameController GameController = new GameController();

    public void GameLoop(){
        //bool endOfGame = false;

        while(!GameController.EndOfGame){
            Message.RenderGameState(GameController);
            Message.RenderOptions(GameController);
            UserInputRaw = Console.ReadLine();
            if(UserInputRaw != null){
                UserInput = UserInputRaw.Trim().ToLower();
            }

            bool validChoice = GameController.ExecuteChoice(UserInput);
            if(!validChoice){
                Message.InputError();
            }
        }
    }

    public void InitGame(){
        Message.Greeting();

        int playerCount = ReadPlayerCount();
        string[] playerNames = new string[playerCount];

        for(int i=0; i<playerCount; i+=1){
            playerNames[i] = ReadPlayerName(i);
        }

        GameController.PlayersAdd(playerNames);
        GameLoop();
    }

    private string ReadPlayerName(int playerIndex){
        bool validPlayerName = false;
        string playerName = "";

        while(!validPlayerName){
            Message.PlayerName(playerIndex);
            UserInputRaw = Console.ReadLine();
            if(UserInputRaw != null){
                UserInput = UserInputRaw;
            }
            if(UserInput != "" && UserInput.Length <= 10){
                playerName = UserInput;
                break;
            }
            if(UserInput == ""){
                Message.EmptyPlayerNameError();
            }
            if(UserInput.Length > 10){
                Message.LongPlayerNameError();
            }
        }
        return playerName;
    }

    private int ReadPlayerCount(){
        bool validPlayerCount = false;
        int playerCount = 0;

        while(!validPlayerCount){
            Message.PlayerCount();
            UserInputRaw = Console.ReadLine();
            if(UserInputRaw != null){
                UserInput = UserInputRaw;
            }
            if(int.TryParse(UserInput, out playerCount)){
                if(playerCount > 0 && playerCount <= 4){
                    validPlayerCount = true;
                }else{
                    Message.InputError();
                }
            }else{
                Message.InputError();
            } 
        }
        return playerCount;
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
    public string Name {get; set;} = "";
    public ScoreSheet ScoreSheet {get; set;} = new ScoreSheet();

    public Player(string name){
        Name = name;
    }
}

class GameController {
    public List<Player> Players {get; set;} = new List<Player>();
    public int Turn {get; set;} = 1;
    private int ActivePlayerIndex {get; set;} = 0;
    public int RollCount {get; set;} = 0;
    public int[] Roll = {1, 1, 1, 1, 1};
    public bool EndOfGame {get; set;} = false;

    public bool ExecuteChoice(string choice){
        if(RollCount == 0 && choice == "w"){
            return rollAll();
        }

        if(RollCount !=3 && choice == "w"){
            return rollAll();
        }

        if(RollCount != 3 && choice != "x"){
            return rollSpecific(choice);
        }

        if(RollCount != 3 && choice == "x"){
            RollCount = 3;
            return true;
        }

        return ScoreRoll(choice);
/*
        if(RollCount == 3){

        }
*/
        return false;
    }

    private bool ScoreRoll(choice){
        //TODO: CONTINUE HERE
    }

    private bool rollAll(){
        List<int> rollList = Dice.RollMany(5);
        for(int i=0; i<5; i+=1){
            Roll[i] = rollList[i];
        }
        RollCount += 1;
        return true;
    }

    private bool rollSpecific(string choice){
        string[] validOptions = ["w1", "w2", "w3", "w4", "w5"];
        string[] diceChoosen = choice.Split(' ');
        if(diceChoosen.Length > 5){
            return false;
        }
        foreach(string diceName in diceChoosen){
            if(!validOptions.Contains(diceName)){
                return false;
            }
        }
        
        foreach(string diceName in diceChoosen){
            int diceIndex = int.Parse(diceName[1].ToString())-1;
            Roll[diceIndex] = Dice.RollOne();
        }
        RollCount += 1;
        return true;
    }

    public void PlayersAdd(string[] names){
        foreach(string name in names){
            Players.Add(new Player(name));
        }
    }

    public string ActivePlayerName{
        get {return Players[ActivePlayerIndex].Name;}
    }

    public ScoreSheet ActivePlayerScore{
        get {return Players[ActivePlayerIndex].ScoreSheet;}
    }
    
}

class Message {
    public static List<string> DiceSymbols = new List<string>(["⚀", "⚁", "⚂", "⚃", "⚄", "⚅"]);

    public static void RenderGameState(GameController gameController){
        Console.WriteLine($"{gameController.ActivePlayerName} ist am Zug");
        RenderScoreSheet(gameController.ActivePlayerScore);
        if(gameController.RollCount > 0){
            RenderRoll(gameController.Roll);
        }
    }

    public static void RenderOptions(GameController gameController){
        Console.WriteLine("Deine Möglichkeiten: ");
        if(gameController.RollCount == 0){
            Console.WriteLine("[W] Würfeln");
            Console.Write("Deine Wahl: ");
        }

        if(gameController.RollCount > 0 && gameController.RollCount < 3){
            Console.WriteLine("Gib die Namen der Würfel ein, die du nochmal würfeln möchtest. Bsp.:[W1 W3]");
            Console.WriteLine("[W] Alle Würfel nochmal würfeln.");
            Console.WriteLine("[X] Wurf eintragen und Zug beenden.");
            Console.Write("Deine Wahl: ");
        }

        if(gameController.RollCount == 3){
            Console.WriteLine("Wo möchtest du deinen Wurf eintragen?");
            Console.Write("Deine Wahl: ");
        }
    }

    public static void LongPlayerNameError(){
        Console.WriteLine("Ungültige Eingabe: Spielername darf maximal 10 Zeichen lang sein.");
    }

    public static void EmptyPlayerNameError(){
        Console.WriteLine("Ungültige Eingabe: Spielername darf nicht leer sein.");
    }

    public static void PlayerName(int playerIndex){
        Console.Write($"Bitte gib einen Namen für Spieler {playerIndex + 1} ein: ");
    }

    public static void PlayerCount(){
        Console.Write("Bitte gib die Anzahl an Mitspielern ein (1-4): ");
    }

    public static void InputError(){
        Console.WriteLine("Ungültige Eingabe -_-");
    }

    public static void RenderRoll(int[] roll){
        Console.WriteLine("|W1|W2|W3|W4|W5|");
        string symbols = "|";
        string eyes = "|";
        foreach(int dice in roll){
            symbols += $"{DiceSymbols[dice-1]} |";
            eyes += $"{dice} |";
        }
        Console.WriteLine(symbols);
        Console.WriteLine(eyes);
    }

    public static void RenderScoreSheet(ScoreSheet scoreSheet){
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

    public static void Greeting(){
        Console.WriteLine("Definetly not Kniffel");
        Console.WriteLine("Herzlich Willkommen!");
    }
}

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
}

class Turn {
    public int tries {get; set;} = 0;
    public List<int> roll {get; set;} = [];
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

