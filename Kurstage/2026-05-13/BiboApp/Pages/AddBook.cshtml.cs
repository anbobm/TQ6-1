using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddBookModel : PageModel
{
    public List<Author> Authors { get; set; }

    public List<Genre> Genres { get; set; }

    public void OnGet()
    {
        var db = new Db();

        Authors = db.Authors.ToList();
        Genres = db.Genres.ToList();
    }

    public void OnPost(int author, string title, int pages, int genre)
    {
        var db = new Db();

        Authors = db.Authors.ToList();
        Genres = db.Genres.ToList();
        
        var neuesBuch = new Book
        {
            AuthorId = author,
            GenreId = genre,
            Title = title,
            Pages = pages
        };

        db.Books.Add(neuesBuch);

        db.SaveChanges();
    }
}