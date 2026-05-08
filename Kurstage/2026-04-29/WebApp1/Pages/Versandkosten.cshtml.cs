using Microsoft.AspNetCore.Mvc.RazorPages;

public class VersandkostenModel : PageModel
{
    public int Versandkosten { get; set; }

    public void OnPost(string location)
    {
        switch(location)
        {
            case "germany":
                Versandkosten = 0;
                break;
            case "eu":
                Versandkosten = 5;
                break;
            case "international":
                Versandkosten = 15;
                break;
        }
    }
}