using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data;

public class EfCoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PriceOffer> PriceOffers { get; set; }
    public DbSet<BookLazy> BookLazy { get; set; }

    public EfCoreContext(DbContextOptions<EfCoreContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });
    }
}
