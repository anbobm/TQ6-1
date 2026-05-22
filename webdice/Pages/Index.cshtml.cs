using Microsoft.AspNetCore.Mvc.RazorPages;

class IndexModel : PageModel {
    public void OnPost(string playerNameInput){
        var db = new Db();
        var player = new Player();
        player.Name = playerNameInput;
        var scoreSheet = new ScoreSheet();
        scoreSheet.Player = player;
        db.ScoreSheet.Add(scoreSheet);
        db.SaveChanges();
    }
}
