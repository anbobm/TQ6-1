using Microsoft.AspNetCore.Mvc.RazorPages;

public class BooklistModel: PageModel{
    public List<MyBook>? Books {get; set;}

    public void OnGet(){
        var db = new Db();
        Books = db.book.ToList();
    }
}
