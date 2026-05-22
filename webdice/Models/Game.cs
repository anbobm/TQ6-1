using System.ComponentModel.DataAnnotations.Schema;

public class Game {
    public int? Id {get; set;}
    public string? CreatedAt {get; set;}
    public List<ScoreSheet> ScoreSheets {get; set;} = [];
    public int? ActiveScoreSheetId {get; set;}
    public bool ongoing {get; set;} = true;
    public ScoreSheet? ActiveScoreSheet {get; set;}
}
