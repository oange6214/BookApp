using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApp.Models;

 [Table("tags")]
public class Tag
{
    [Key]
    [Required]
    [MaxLength(40)]
    [Column("tag_id")]
    public string TagId { get; set; }

    // Relationships

    public ICollection<Book> Books { get; set; }
}