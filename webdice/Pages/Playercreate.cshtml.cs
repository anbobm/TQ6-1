using Microsoft.AspNetCore.Mvc.RazorPages;

class PlayercreateModel : PageModel {
    public void OnPost(string playerNameInput){
        var db = new Db();
        var player = new Player();
        player.Name = playerNameInput;
        db.Player.Add(player);
        db.SaveChanges();
    }
}
