using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

class GameModel : PageModel {
    public Game? Game {get; set;}
    public List<Player> Players {get; set;} = [];
    public List<ScoreSheet> ScoreSheets {get; set;} = [];
    public Turn? Turn {get; set;}
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
           .Include(g => g.ScoreSheets)
           .ThenInclude(s => s.Player)
           .Include(g => g.ActiveScoreSheet)
           .Where(g => g.Id == Action.GameId).First();

        if(Action.Choice == "Roll" && Action.Rolls.Count == 0){
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
