using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("authors")]
public class Author
{
    [Column("author_id")]
    public int AuthorId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    // Relationships
    public ICollection<BookAuthor>? BooksLink { get; set; }
}