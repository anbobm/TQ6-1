using Microsoft.AspNetCore.Mvc.RazorPages;

public class GreetingModel : PageModel
{
    public string Name { get; set; }

    public bool IsBirthday { get; set; }

    public void OnGet(string name, DateTime geburtsdatum)
    {
        Name = name;

        var heute = DateTime.Now;

        if (heute.Day == geburtsdatum.Day && heute.Month == geburtsdatum.Month)
        {
            IsBirthday = true;
        }
    }
}