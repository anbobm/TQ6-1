using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddBookModel : PageModel
{
    public List<Author> Authors { get; set; }

    public void OnGet()
    {
        var db = new Db();

        Authors = db.Authors.ToList();
    }

    public void OnPost(int author, string title, int pages)
    {
        var db = new Db();

        Authors = db.Authors.ToList();
        
        var neuesBuch = new Book
        {
            AuthorId = author,
            Title = title,
            Pages = pages
        };

        db.Books.Add(neuesBuch);

        db.SaveChanges();
    }
}