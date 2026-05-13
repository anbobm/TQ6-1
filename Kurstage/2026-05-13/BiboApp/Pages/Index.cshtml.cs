using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BiboApp.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        var db = new Db();

        var books = db.Books.Include(b => b.Author).ToList();

    }
}
