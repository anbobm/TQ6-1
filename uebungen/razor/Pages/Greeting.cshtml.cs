using Microsoft.AspNetCore.Mvc.RazorPages;

public class GreetingModel: PageModel{
    public string? Name {get; set;}
    public string? Birthday {get; set;}
    public int? Alter {get; set;}

    public void OnGet(string name, string birthday, int? alter){
        Name = name;
        Birthday = birthday;
        Alter = alter;
    }
}
