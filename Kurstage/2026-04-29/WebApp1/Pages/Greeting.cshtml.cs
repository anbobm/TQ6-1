using Microsoft.AspNetCore.Mvc.RazorPages;

public class GreetingModel : PageModel
{
    public string Name { get; set; }

    public int? Alter { get; set; }

    public void OnGet(string name, int? alter)
    {
        Name = name;
        Alter = alter;
    }
}