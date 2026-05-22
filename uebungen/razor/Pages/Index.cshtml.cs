using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel: PageModel{
    public string? Name {get; set;}

    public void OnGet(string name){
        Name = name;
    }
} 
