using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string Foo { get; set; }

    public void OnGet(string foo)
    {
        Foo = foo;
    }
}