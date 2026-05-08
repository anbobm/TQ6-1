using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class SetCookieModel : PageModel
{
    // Der Wert, den der Nutzer im Formular eingibt
    [BindProperty]
    public string CookieValue { get; set; } = string.Empty;

    public void OnGet()
    {
        // Seite wird geladen – nichts zu tun
    }

    public IActionResult OnPost()
    {
        // Cookie setzen: Name = "Cookie", Wert = was der Nutzer eingegeben hat
        Response.Cookies.Append("Cookie", CookieValue);

        // Weiterleiten zur ShowCookie-Seite
        return RedirectToPage("/ShowCookie");
    }
}
