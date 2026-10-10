using LqtBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LqtBookStore.Data;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;
    public BookRepository(BookStoreDbContext context) => _context = context;

    public async Task<List<Book>> GetBooksAsync(string? searchString = null)
    {
        var query = _context.Books.Include(b => b.Category).Include(b => b.Publisher).AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchString))
            query = query.Where(b => b.Title.Contains(searchString) || (b.Author != null && b.Author.Contains(searchString)));
        return await query.OrderBy(b => b.Title).ToListAsync();
    }

    public Task<Book?> GetBookAsync(string id) => _context.Books
        .Include(b => b.Category).Include(b => b.Publisher)
        .FirstOrDefaultAsync(b => b.BookId == id);

    public Task<bool> BookExistsAsync(string id) => _context.Books.AnyAsync(b => b.BookId == id);
    public Task<bool> HasOrderDetailsAsync(string id) => _context.OrderDetails.AnyAsync(d => d.BookId == id);

    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public Task<List<Publisher>> GetPublishersAsync() => _context.Publishers.OrderBy(p => p.PublisherName).ToListAsync();
    public Task<List<Category>> GetCategoriesAsync() => _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
}
