using Microsoft.AspNetCore.Mvc.RazorPages;
class NewgameModel : PageModel {

    public List<Player> Players {get; set;} = [];

    public void OnGet(){
        var db = new Db();
        Players = db.Player.ToList();
    }
    public void OnPost(){
    }
}
