using Microsoft.AspNetCore.Mvc.RazorPages;

public class SetCookieModel : PageModel
{
    public void OnGet(string key, string value)
    {
        if (key == null || value == null)
        {
            return;
        }

        Response.Cookies.Append(key, value);
    }
}