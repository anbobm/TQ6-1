
Genre

AuthorId

OrderBy (a=>a.lastName)

Join
db.Books.Include(b=>b.Author).ToList()


public class Db : Dbcontext {
    public DBSet<Book> Books {get; set;} // <Klassenname> Tablename
    protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
}

PageModel

public void OnGet(){
    var db = new DB()
    Books = db.Books.ToList();
}
