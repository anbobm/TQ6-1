using Microsoft.AspNetCore.Mvc.RazorPages;

public class BooksModel : PageModel
{
    public List<Book> Books { get; set; }

    public void OnGet()
    {
        var db = new Db();

        // SELECT * FROM Books
        db.Books.ToList();
        // SELECT Id, Title FROM Books
        db.Books.Select(b => new { b.Id, b.Title }).ToList();
        // SELECT * FROM Books WHERE Id = 3
        Books = db.Books.Where(b => b.Id == 3).ToList();
    }

}