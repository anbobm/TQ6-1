using System.ComponentModel.DataAnnotations.Schema;

public class Game {
    public int? Id {get; set;}
    public List<ScoreSheet> ScoreSheets {get; set;} = [];
    public int? ActiveScoreSheetId {get; set;}
    public bool OnGoing {get; set;} = true;
    public ScoreSheet? ActiveScoreSheet {get; set;}
    public string? CreatedAt {get; set;}

    public bool NextPlayer(){
        int index = ScoreSheets.FindIndex(e => e.Id == ActiveScoreSheet.Id);
        if(index == ScoreSheets.Count -1){
            ActiveScoreSheet = ScoreSheets[0];
        }else{
            ActiveScoreSheet = ScoreSheets[index+1];
        }

        return true;
    }

    public bool CheckOnGoing(){
        foreach(var scoreSheet in ScoreSheets){
            if(scoreSheet.Ones is null){
                return OnGoing;
            }
            if(scoreSheet.Twos is null){
                return OnGoing;
            }
            if(scoreSheet.Threes is null){
                return OnGoing;
            }
            if(scoreSheet.Fours is null){
                return OnGoing;
            }
            if(scoreSheet.Fives is null){
                return OnGoing;
            }
            if(scoreSheet.Sixes is null){
                return OnGoing;
            }
            if(scoreSheet.ThreeOfAKind is null){
                return OnGoing;
            }
            if(scoreSheet.FourOfAKind is null){
                return OnGoing;
            }
            if(scoreSheet.FiveOfAKind is null){
                return OnGoing;
            }
            if(scoreSheet.FullHouse is null){
                return OnGoing;
            }
            if(scoreSheet.Straight is null){
                return OnGoing;
            }
            if(scoreSheet.LongStraight is null){
                return OnGoing;
            }
            if(scoreSheet.Chance is null){
                return OnGoing;
            }
        }
        OnGoing = false;
        return OnGoing;
    }

    public List<ScoreSheet> Ranking(){
        List<ScoreSheet> ranking = ScoreSheets.OrderByDescending(s => s.ScoreTotal()).ToList();
        return ranking;
    }
}
