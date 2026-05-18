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

        // Beispielcode für Book-Publisher-Relationship
        var parfum = db.Books
            .Include(b => b.Publishers)
            .Where(b => b.Id == 3).First();
    }
}
