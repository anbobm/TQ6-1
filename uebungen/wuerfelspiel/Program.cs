// See https://aka.ms/new-console-template for more information
var uiController = new UIController();
uiController.InitGame();

class UIController(){

    private string? UserInputRaw = "";
    private string UserInput = "";
    private GameController GameController = new GameController();

    public void GameLoop(){
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

        Message.RenderEndOfGame(GameController);

        // ENDOFGAMEMESSAGE HERE
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

    }

    private bool ScoreRoll(string choice){
        int parsedValue = 0;
        bool validInt = int.TryParse(choice, out parsedValue);
        if(!validInt){return false;}
        if(parsedValue < 1 || parsedValue > 13){return false;}

        bool scoreSaved = false;
        if(parsedValue <= 6){
            scoreSaved = ActivePlayerScore.ScoreUpper(Roll, parsedValue);
        }

        if(parsedValue > 6){
            scoreSaved = ActivePlayerScore.ScoreLower(Roll, parsedValue);
        }

        if(!scoreSaved){
            return false;
        }

        RollCount = 0;

        if(Turn == 13 && ActivePlayerIndex == Players.Count - 1){
            EndOfGame = true;
            return true;
        }

        if(ActivePlayerIndex == Players.Count - 1){
            ActivePlayerIndex = 0;
            Turn += 1;
            return true;
        }

        if(ActivePlayerIndex != Players.Count -1){
            ActivePlayerIndex += 1;
            return true;
        }

        return false; 
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

    public static void RenderEndOfGame(GameController gameController){
        var ranking = gameController.Players.OrderByDescending(player => player.ScoreSheet.Conclusion[4].Points).ToList();
        Console.WriteLine($"Herzlichen Glückwunsch {ranking[0].Name}");
        Console.WriteLine("Endstand:");
        int rank = 1;
        foreach(var player in ranking){
            Console.WriteLine($"{rank}. {player.Name} - {player.ScoreSheet.Conclusion[4].Points} Punkte");
            rank += 1;
        }
    }

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
            Console.WriteLine("[W1..W6] Nochmal Würfeln.");
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
        //bool upperPartDone = false;
        foreach(Score score in scoreSheet.Score){
            //if(optionCounter == 7 && !upperPartDone){
            if(optionCounter == 7){
                Console.WriteLine($"{scoreSheet.Conclusion[0].Name}\t\t\t{scoreSheet.Conclusion[0].Points.ToString().PadLeft(3, ' ')}");
                Console.WriteLine($"{scoreSheet.Conclusion[1].Name}\t\t\t\t{scoreSheet.Conclusion[1].Points.ToString().PadLeft(3, ' ')}");
                Console.WriteLine($"{scoreSheet.Conclusion[2].Name}\t\t\t\t{scoreSheet.Conclusion[2].Points.ToString().PadLeft(3, ' ')}");
                //upperPartDone = true;
            }
            
            string scoreMsg = $"[{optionCounter.ToString().PadLeft(2, ' ')}] {score.Name.PadRight(11-score.Name.Length, ' ')}";
            if(score.Name.Length <= 10){scoreMsg += "\t\t\t";}
            if(score.Name.Length > 10){scoreMsg += "\t\t";}
            if(!score.Open){scoreMsg += score.Points.ToString().PadLeft(3, ' '); } 
            
            Console.WriteLine(scoreMsg);
            optionCounter += 1;
        }
        Console.WriteLine($"{scoreSheet.Conclusion[3].Name}\t\t\t{scoreSheet.Conclusion[3].Points.ToString().PadLeft(3, ' ')}");
        Console.WriteLine($"{scoreSheet.Conclusion[4].Name}\t\t\t\t{scoreSheet.Conclusion[4].Points.ToString().PadLeft(3, ' ')}");
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
        new Score("Kniffel", 0),
        new Score("Chance", 0),
    };

    public List<Score> Conclusion = new List<Score>{
        new Score("Punkte Oben", 0),
        new Score("Bonus", 0),
        new Score("Total", 0),
        new Score("Punkte Unten", 0),
        new Score("Total", 0),
    };

    public bool ScoreUpper(int[] roll, int eyes){
        if(!Score[eyes-1].Open){return false;}
        foreach(int dice in roll){
            if(eyes == dice){Score[eyes-1].Points += dice;}
        }
        Score[eyes-1].Open = false;
        updateConclusion();
        return true;
    }

    public bool ScoreLower(int[] roll, int choice){
        bool scoreSaved = false;
        switch(choice){
            case 7:
                scoreSaved = Score3OfAKind(roll);
                break;
            case 8:
                scoreSaved = Score4OfAKind(roll);
                break;
            case 9:
                scoreSaved = ScoreFullHouse(roll);
                break;
            case 10:
                scoreSaved = ScoreShortStraight(roll);
                break;
            case 11:
                scoreSaved = ScoreLongStraight(roll);
                break;
            case 12:
                scoreSaved = Score5OfAKind(roll);
                break;
            case 13:
                scoreSaved = ScoreChance(roll);
                break;
        }
        updateConclusion();
        return scoreSaved;
    }

    private bool ScoreChance(int[] roll){
        if(!Score[12].Open){return false;}
        foreach(int dice in roll){Score[12].Points += dice;}
        Score[12].Open = false;
        return true; 
    }

    private bool Score5OfAKind(int[] roll){
        if(!Score[11].Open){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid5OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 4){
                valid5OfAKind = true;
                break;
            }
        }

        if(!valid5OfAKind){
            Score[11].Points = 0;
            Score[11].Open = false;
            return true;
        }

        Score[11].Points = 50;
        Score[11].Open = false;
        return true;
    }

    private bool ScoreLongStraight(int[] roll){
        if(!Score[10].Open){return false;}
        SortedDictionary<int, int> eyeDict = new SortedDictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validStraight = false;
        int straightCounter = 0;

        foreach(var kvp in eyeDict){
            if(kvp.Value > 0){straightCounter += 1;}
            if(straightCounter > 4){
                validStraight = true;
                break;
            }
            if(kvp.Value == 0){straightCounter = 0;}
        }

        if(!validStraight){
            Score[10].Points = 0;
            Score[10].Open = false;
            return true;
        }

        Score[10].Points = 40; 
        Score[10].Open = false;
        return true;
    }


    private bool ScoreShortStraight(int[] roll){
        if(!Score[9].Open){return false;}
        SortedDictionary<int, int> eyeDict = new SortedDictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validStraight = false;
        int straightCounter = 0;

        foreach(var kvp in eyeDict){
            if(kvp.Value > 0){straightCounter += 1;}
            if(straightCounter > 3){
                validStraight = true;
                break;
            }
            if(kvp.Value == 0){straightCounter = 0;}
        }

        if(!validStraight){
            Score[9].Points = 0;
            Score[9].Open = false;
            return true;
        }

        Score[9].Points = 30; 
        Score[9].Open = false;
        return true;
    }

    private bool ScoreFullHouse(int[] roll){
        if(!Score[8].Open){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool validFullHouse = false;
        bool found3OfAKind = false;
        bool foundPair = false;
        bool found5OfAKind = false;

        foreach(var kvp in eyeDict){
            if(kvp.Value == 3){
                found3OfAKind = true;
            }
            if(kvp.Value == 2){
                foundPair = true;
            }
            if(kvp.Value > 4){
                found5OfAKind = true;
            }
        }

        if((found3OfAKind && foundPair) || found5OfAKind){
            validFullHouse = true;
        }

        if(!validFullHouse){
            Score[8].Points = 0;
            Score[8].Open = false;
            return true;
        }

        Score[8].Points = 25; 
        Score[8].Open = false;
        return true;
    }

    private bool Score4OfAKind(int[] roll){
        if(!Score[7].Open){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid4OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 3){
                valid4OfAKind = true;
                break;
            }
        }

        if(!valid4OfAKind){
            Score[7].Points = 0;
            Score[7].Open = false;
            return true;
        }

        foreach(int dice in roll){
            Score[7].Points += dice;
        }
        
        Score[7].Open = false;
        return true;
    }


    private bool Score3OfAKind(int[] roll){
        if(!Score[6].Open){return false;}
        Dictionary<int, int> eyeDict = new Dictionary<int, int> {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
        };

        foreach(var key in eyeDict.Keys.ToList()){
            int count = roll.Count(x => x==key);
            eyeDict[key] = count;
        }

        bool valid3OfAKind = false;
        foreach(var kvp in eyeDict){
            if(kvp.Value > 2){
                valid3OfAKind = true;
                break;
            }
        }

        if(!valid3OfAKind){
            Score[6].Points = 0;
            return true;
        }

        foreach(int dice in roll){
            Score[6].Points += dice;
        }
        
        Score[6].Open = false;
        return true;
    }

    private void updateConclusion(){
        int upperPoints = 0;
        for(int i=0; i<6; i+=1){
           upperPoints += Score[i].Points;
        }
        Conclusion[0].Points = upperPoints;
        if(upperPoints >= 63){Conclusion[1].Points = 35;}
        Conclusion[2].Points = Conclusion[0].Points + Conclusion[1].Points;
        int lowerPoints = 0;
        for(int i=6; i<Score.Count; i+=1){
            lowerPoints += Score[i].Points;
        }
        Conclusion[3].Points = lowerPoints;
        int total = 0;
        for(int i=0; i<4; i+=1){
            if(i==2){continue;}
            total += Conclusion[i].Points;
        }
        Conclusion[4].Points = total;
    } 
}
