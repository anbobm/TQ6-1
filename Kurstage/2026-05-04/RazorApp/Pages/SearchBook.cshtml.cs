using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class SearchBookModel : PageModel
{

    public List<Book> Results { get; set; } = new();

    public void OnGet() { }

    public void OnPost(string search)
    {
        var db = new Db();
        Results = db.Books
            .Where(b => b.Title.Contains(search))
            .ToList();
    }
}