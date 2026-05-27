using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

class LoadGameModel : PageModel {
    public List<Game> Games {get; set;}
    public Action Action {get; set;}
    public string ActionJson {get; set;}

    public void OnGet(){
        var db = new Db();
        Games = db.Game
            .Where(g=> g.OnGoing == true)
            .OrderByDescending(g=> g.CreatedAt)
            .ToList();
        Action = new Action();
        ActionJson = JsonSerializer.Serialize(Action);
    }
}
