using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("reviews")]
public class Review
{
    [Column("review_id")]
    public int ReviewId { get; set; }
    
    [Column("voter_name")]
    public string VoterName { get; set; }
    
    [Column("num_stars")]
    public int NumStars { get; set; }
    
    [Column("comment")]
    public string Comment { get; set; }
    
    // Relationships
    
    [Column("book_id")]
    public int BookId { get; set; }
}