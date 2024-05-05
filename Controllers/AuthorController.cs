using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    public readonly EfCoreContext _dbContext;
    public AuthorController(EfCoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/Author/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var author = await _dbContext.Authors
                            .Include(a => a.BooksLink)
                            .FirstOrDefaultAsync(a => a.AuthorId == id);

        if (author == null)
        {
            return NotFound(); // Return 404 Not Found if author not found
        }

        return author;
    }


    // GET: api/Author
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAll()
    {
        return await _dbContext.Authors
                        .Include(a => a.BooksLink)
                        .ToListAsync();
    }

    // POST: api/Author
    [HttpPost]
    public async Task<ActionResult<Author>> Create(Author author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync();

        return CreatedAtRoute(nameof(GetAuthor), new { id = author.AuthorId }, author);
    }
}
