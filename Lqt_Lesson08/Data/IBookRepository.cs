using LqtBookStore.Models;

namespace LqtBookStore.Data;

public interface IBookRepository
{
    Task<List<Book>> GetBooksAsync(string? searchString = null);
    Task<Book?> GetBookAsync(string id);
    Task<bool> BookExistsAsync(string id);
    Task<bool> HasOrderDetailsAsync(string id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(Book book);
    Task<List<Publisher>> GetPublishersAsync();
    Task<List<Category>> GetCategoriesAsync();
}
