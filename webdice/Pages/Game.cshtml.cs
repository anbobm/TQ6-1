using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

class GameModel : PageModel {
    public Game? Game {get; set;}
    public List<Player> Players {get; set;} = [];
    public List<ScoreSheet> ScoreSheets {get; set;} = [];
    public Action? Action {get; set;}
    public string? ActionJson {get; set;}

    public void OnGet(string players){
        string[] PlayerSubStrings = players.Split('-');
        List<int?> PlayerIds = [];
        foreach (var pID in PlayerSubStrings){
            PlayerIds.Add(Int32.Parse(pID));
        }
        var db = new Db();
        Game = new Game();
        db.Game.Add(Game);
        db.SaveChanges();
        Players = db.Player.Where(p => PlayerIds.Contains(p.Id.Value)).ToList();
        foreach (var player in Players){
            var scoreSheet = new ScoreSheet();
            scoreSheet.Player = player;
            scoreSheet.Game = Game;
            ScoreSheets.Add(scoreSheet);
            db.ScoreSheet.Add(scoreSheet);
        }
        db.SaveChanges();
        
        int activeScoreSheetIndex = Dice.RollStartPlayer(ScoreSheets.Count);

        Game.ActiveScoreSheet = ScoreSheets[activeScoreSheetIndex];
        db.SaveChanges();
        Action = new Action();
        int id = (Game.Id ?? 0);
        Action.GameId = id;
        ActionJson = JsonSerializer.Serialize(Action);
    }

    public void OnPost(string actionInput){
        Action = JsonSerializer.Deserialize<Action>(actionInput);
        var db = new Db();
        Game = db.Game
           .Include(g => g.ScoreSheets.OrderBy(s => s.Id))
           .ThenInclude(s => s.Player)
           .Include(g => g.ActiveScoreSheet)
           .Where(g => g.Id == Action.GameId).First();

        // The inclusion of ActiveScoreSheet, messes for some reason with the sorting.
        // But we need to keep the Scoresheets in order to determine who is next to play.
        Game.ScoreSheets = Game.ScoreSheets.OrderBy(s=> s.Id).ToList();
            
        // Scoring und validation
        if(Action.Choice == "Score" && Action.Rolls.Count > 0){
            bool validScoring = false;
            if(Action.Score == "0"){
                validScoring = Game.ActiveScoreSheet.ScoreOnes(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "1"){
                validScoring = Game.ActiveScoreSheet.ScoreTwos(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "2"){
                validScoring = Game.ActiveScoreSheet.ScoreThrees(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "3"){
                validScoring = Game.ActiveScoreSheet.ScoreFours(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "4"){
                validScoring = Game.ActiveScoreSheet.ScoreFives(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "5"){
                validScoring = Game.ActiveScoreSheet.ScoreSixes(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "8"){
                validScoring = Game.ActiveScoreSheet.Score3OfAKind(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "9"){
                validScoring = Game.ActiveScoreSheet.Score4OfAKind(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "10"){
                validScoring = Game.ActiveScoreSheet.ScoreFullHouse(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "11"){
                validScoring = Game.ActiveScoreSheet.ScoreStraight(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "12"){
                validScoring = Game.ActiveScoreSheet.ScoreLongStraight(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "13"){
                validScoring = Game.ActiveScoreSheet.Score5OfAKind(Action.Rolls[Action.Rolls.Count-1]);
            }else if(Action.Score == "14"){
                validScoring = Game.ActiveScoreSheet.ScoreChance(Action.Rolls[Action.Rolls.Count-1]);
            }

            if(!validScoring){
                if(Action.Rolls.Count < 3){
                    Action.Score = "none";
                    Action.Choice = "Roll";
                }else{
                    Action.Score = "none";
                    Action.Choice = "Score";
                }
                ActionJson = JsonSerializer.Serialize(Action);
                return;
            }

            Game.NextPlayer();
            Game.CheckOnGoing();
            db.SaveChanges();

            if(!Game.OnGoing){
                return;
            }

            Action = new Action();
            int id = (Game.Id ?? 0);
            Action.GameId = id;
        }
        else if(Action.Choice == "Roll" && Action.Rolls.Count == 0){
           Action.Rolls.Add(Dice.RollMany(5));
        }
        else if(Action.Choice == "Roll" && Action.Rolls.Count > 0){
            List<int> roll = [];
            foreach(int keep in Action.Keep){
                roll.Add(Action.Rolls[Action.Rolls.Count-1][keep]);
            }
            while(roll.Count < 5){
                roll.Add(Dice.RollOne());
            }
            Action.Rolls.Add(roll);
            Action.Keep = [];
        }
        ActionJson = JsonSerializer.Serialize(Action);
    }
}
