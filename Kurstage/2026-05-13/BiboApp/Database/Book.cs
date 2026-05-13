public class Book
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required int Pages { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public int GenreId { get; set; }

    public Genre Genre { get; set; }
}