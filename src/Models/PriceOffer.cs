using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

[Table("price_offers")]
public class PriceOffer
{
    [Column("price_offer_id")]
    public int PriceOfferId { get; set; }
    
    [Column("new_price")]
    public decimal NewPrice { get; set; }
    
    [Column("promotional_text")]
    public string PromotionalText { get; set; }
    
    // Relationships
    [Column("book_id")]
    public int BookId { get; set; }
}
