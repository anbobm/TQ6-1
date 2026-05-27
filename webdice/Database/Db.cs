using Microsoft.EntityFrameworkCore;

class Db : DbContext{
    public DbSet<Player> Player {get; set;} // <Classname> Tablename
    public DbSet<ScoreSheet> ScoreSheet {get; set;} // <Classname> Tablename
    public DbSet<Game> Game {get; set;} // <Classname> Tablename

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source = Database/webdice.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Game>()
            .HasOne(g => g.ActiveScoreSheet)
            .WithOne(s => s.ActiveGame)
            .HasForeignKey<Game>(g => g.ActiveScoreSheetId);

        modelBuilder.Entity<Game>()
            .Property(g=> g.CreatedAt)
            .HasDefaultValueSql("datetime('now')")
            .ValueGeneratedOnAdd();
    }
}
