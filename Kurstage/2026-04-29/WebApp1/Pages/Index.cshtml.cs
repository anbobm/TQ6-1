using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string Foo { get; set; }

    public string Cookie { get; set; }

    public void OnGet(string foo)
    {
        Foo = foo;

        Cookie = Request.Cookies["foo"];

        Response.Cookies.Append("foo", "baz");
    }
}