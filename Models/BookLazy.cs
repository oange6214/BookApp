using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("booklazys")]
public class BookLazy
{
    [Column("booklazy_id")]
    public int BookLazyId { get; set; }
    
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
    public virtual PriceOffer Promotion { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
    public virtual ICollection<BookAuthor> AuthorsLink { get; set; }
}