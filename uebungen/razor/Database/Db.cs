using Microsoft.EntityFrameworkCore;

class Db : DbContext{
    public DbSet<MyBook> book {get; set;} // <Classname> Tablename
    public DbSet<Author> author {get; set;} // <Classname> Tablename
    public DbSet<Genre> genre {get; set;} // <Classname> Tablename
    public DbSet<Member> member {get; set;} // <Classname> Tablename

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source = Database/tq6db.db");
}
