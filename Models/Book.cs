using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("books")]
public class Book
{
    [Column("book_id")]
    public int BookId { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("published_on")]
    public DateTime PublishedOn { get; set; }
    
    [Column("publisher")]
    public string Publisher { get; set; }
    
    [Column("price")]
    public decimal Price { get; set; }
    
    [Column("image_url")]
    public string ImageUrl { get; set; }

    // Relationships
    public PriceOffer Promotion { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<BookAuthor> AuthorsLink { get; set; }
}