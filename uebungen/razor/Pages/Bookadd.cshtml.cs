using Microsoft.AspNetCore.Mvc.RazorPages;

public class BookAddModel: PageModel{
    //public List<MyBook>? Books {get; set;}
    public List<Author>? Authors {get; set;}
    public List<Genre>? Genres {get; set;}
    public Author Author {get; set;}
    public Genre Genre {get; set;}

    public void OnGet(){
        var db = new Db();
        Authors = db.author.ToList();
        Genres = db.genre.ToList();
    }

    public void OnPost(string? titleInput, int? authorSelect, int? genreSelect, int? pagesInput){
        var db = new Db();
        Authors = db.author.ToList();
        Genres = db.genre.ToList();

        Author = db.author.Where(a => a.Id == authorSelect).First();
        Genre = db.genre.Where(g => g.Id == genreSelect).First();

        var newBook = new MyBook();
        newBook.Title = titleInput;
        newBook.Author = Author;
        newBook.Genre = Genre;
        newBook.Pages = pagesInput;
        //var db = new Db();
        db.book.Add(newBook);
        db.SaveChanges();
    }
}
