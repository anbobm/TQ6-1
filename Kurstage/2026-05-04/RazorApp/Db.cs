using Microsoft.EntityFrameworkCore;

namespace RazorApp;

public class Db : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=books.db");
}