using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    public readonly EfCoreContext _dbContext;
    public BooksController(EfCoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _dbContext.Books
                    .Include(b => b.Promotion)
                    .Include(b => b.Reviews)
                    .Include(b => b.Tags)
                    .Include(b => b.AuthorsLink)
                    .FirstOrDefault(b => b.BookId == id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
        return _dbContext.Books.AsNoTracking().Where(p => p.Title.StartsWith("Quantum")).ToList();
    }

    [HttpGet("eagerloading-reviews")]
    public IActionResult GetBookWithReviews()
    {
        var firstBook = _dbContext.Books
            .Include(book => book.Reviews)
            .FirstOrDefault();

        if (firstBook == null)
        {
            return NotFound(); // Handle no book found scenario
        }

        return Ok(firstBook); // Explicitly return the Book object
    }

    [HttpGet("eagerloading-reviews-complex")]
    public IActionResult GetBookWithReviewsComplex()
    {
        var firstBook = _dbContext.Books
            .Include(book => book.AuthorsLink)
                .ThenInclude(bookAuthor => bookAuthor.Author)
            .Include(book => book.Reviews)
            .Include(book => book.Tags)
            .Include(book => book.Promotion)
            .FirstOrDefault();

        if (firstBook == null)
        {
            return NotFound(); // Handle no book found scenario
        }

        return Ok(firstBook); // Explicitly return the Book object
    }

    [HttpGet("eagerloading-reviews-sort-filter")]
    public IActionResult GetBookWithReviewsSortFilter()
    {
        var firstBook = _dbContext.Books
            .Include(book => book.AuthorsLink
                .OrderBy(bookAuthor => bookAuthor.Order))
            .ThenInclude(bookAuthor => bookAuthor.Author)
            .Include(book => book.Reviews
                .Where(review => review.NumStars == 5))
            .Include(book => book.Promotion)
            .First();

        if (firstBook == null)
        {
            return NotFound();
        }

        return Ok(firstBook);
    }

    [HttpGet("explicitloading-book")]
    public IActionResult GetBookRelatedData()
    {
        var firstBook = _dbContext.Books.First();

        _dbContext.Entry(firstBook)
            .Collection(book => book.AuthorsLink).Load();

        foreach (var authorLink in firstBook.AuthorsLink)
        {
            _dbContext.Entry(authorLink)
                .Reference(bookAuthor =>
                    bookAuthor.Author).Load();
        }

        _dbContext.Entry(firstBook)
            .Collection(book => book.Tags).Load();
        
        _dbContext.Entry(firstBook)
            .Reference(book => book.Promotion).Load();
        
        return Ok(firstBook);
    }

    [HttpGet("explicitloading-book-query")]
    public IActionResult GetBookRelatedDataQuery()
    {
        var firstBook = _dbContext.Books.First();

        // Executes a query to count reviews for this book
        var numReviews = _dbContext.Entry(firstBook)
            .Collection(book => book.Reviews)
            .Query()
            .Count();

        // Executes a query to get all the star ratings for the book
        var starRatings = _dbContext.Entry(firstBook)
            .Collection(book => book.Reviews)
            .Query()
            .Select(review => review.NumStars)
            .ToList();

        return Ok(starRatings);
    }

    [HttpGet("selectloading-book")]
    public IActionResult GetBookSpecProperties()
    {
        var books = _dbContext.Books
            .Select(book => new
            {
                book.Title,
                book.Price,
                numReviews = book.Reviews.Count,
            })
            .ToList();

        return Ok(books);
    }

    [HttpGet("lazyloading-bookLazy")]
    public IActionResult GetBookReviews()
    {
        var book = _dbContext.BookLazy.Single();
        var reviews = book.Reviews.ToList();

        return Ok(reviews);
    }

    [HttpGet("client-server-promotion")]
    public IActionResult GetBookJoinAuthor()
    {
        var firstBook = _dbContext.Books
            .Select(book => new 
            {
                book.BookId,
                book.Title,
                AuthorString = string.Join(", ", book.AuthorsLink
                    .OrderBy(ba => ba.Order)
                    .Select(ba => ba.Author.Name)
                    )
            });

        return Ok(firstBook);
    }

    

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
    }
}
