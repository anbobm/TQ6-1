using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class ShowCookieModel : PageModel
{
    // Aufgabe 1: Der Wert eines bestimmten Cookies
    public string? CookieValue { get; set; }

    // Aufgabe 2: Alle Cookies als Dictionary (Schlüssel → Wert)
    public Dictionary<string, string> AlleCookies { get; set; } = new();

    public void OnGet()
    {
        // Aufgabe 1: Lese einen bestimmten Cookie
        CookieValue = Request.Cookies["Cookie"];

        // Aufgabe 2: Alle Cookies einlesen
        foreach (var cookie in Request.Cookies)
        {
            AlleCookies[cookie.Key] = cookie.Value;
        }
    }
}
