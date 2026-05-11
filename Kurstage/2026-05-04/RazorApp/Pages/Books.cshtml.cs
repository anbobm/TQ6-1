using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class BooksModel : PageModel
{
    public List<Book> Books { get; set; } = new();

    public void OnGet()
    {
        var db = new Db();
        db.Database.EnsureCreated();   // erstellt die .db-Datei falls noch nicht vorhanden
        Books = db.Books.ToList();
    }
}