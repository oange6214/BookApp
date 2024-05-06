using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("book_authors")]
public class BookAuthor
{
    [Column("book_id")]
    public int BookId { get; set; }
    
    [Column("author_id")]
    public int AuthorId { get; set; }

    [Column("order_num")]
    public byte Order { get; set; }

    // Relationships
    public Book? Book { get; set; }
    public Author? Author { get; set; }
}