using Microsoft.AspNetCore.Mvc.RazorPages;

public class SetCookieModel : PageModel
{
    public void OnGet(string keks)
    {
        if (keks == null)
        {
            return;
        }

        Response.Cookies.Append("keks", keks);
    }
}