using Microsoft.AspNetCore.Mvc.RazorPages;

public class BookSearchModel: PageModel{
    public List<MyBook>? Books {get; set;}

    public void OnGet(string? queryInput){
        
        var db = new Db();
        Books = db.book.Where(b => b.Title.Contains(queryInput)).ToList();
        //Books = db.book.Where((b) => {return b.Title.Contains(queryInput);}).ToList();
    }
}
