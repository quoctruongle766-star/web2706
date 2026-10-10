using LqtBookStore.Data;
using LqtBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LqtBookStore.Controllers;

public class BooksController : Controller
{
    private readonly IBookRepository _books;
    public BooksController(IBookRepository books) => _books = books;

    public async Task<IActionResult> Index(string? searchString)
    {
        ViewData["SearchString"] = searchString;
        return View(await _books.GetBooksAsync(searchString));
    }

    public async Task<IActionResult> Details(string? id)
    {
        if (id == null) return NotFound();
        var book = await _books.GetBookAsync(id);
        return book == null ? NotFound() : View(book);
    }

    public async Task<IActionResult> Create()
    {
        await LoadListsAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,Title,Author,Release,Price,Description,Picture,PublisherId,CategoryId")] Book book)
    {
        if (await _books.BookExistsAsync(book.BookId))
            ModelState.AddModelError(nameof(book.BookId), "Mã sách đã tồn tại.");
        if (ModelState.IsValid)
        {
            await _books.AddBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        await LoadListsAsync(book);
        return View(book);
    }

    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null) return NotFound();
        var book = await _books.GetBookAsync(id);
        if (book == null) return NotFound();
        await LoadListsAsync(book);
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("BookId,Title,Author,Release,Price,Description,Picture,PublisherId,CategoryId")] Book book)
    {
        if (id != book.BookId) return NotFound();
        if (!ModelState.IsValid)
        {
            await LoadListsAsync(book);
            return View(book);
        }
        if (!await _books.BookExistsAsync(id)) return NotFound();
        await _books.UpdateBookAsync(book);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null) return NotFound();
        var book = await _books.GetBookAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var book = await _books.GetBookAsync(id);
        if (book == null) return RedirectToAction(nameof(Index));
        if (await _books.HasOrderDetailsAsync(id))
        {
            TempData["Error"] = "Không thể xóa sách đã có trong đơn hàng.";
            return RedirectToAction(nameof(Index));
        }
        await _books.DeleteBookAsync(book);
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadListsAsync(Book? book = null)
    {
        ViewData["PublisherId"] = new SelectList(await _books.GetPublishersAsync(), "PublisherId", "PublisherName", book?.PublisherId);
        ViewData["CategoryId"] = new SelectList(await _books.GetCategoriesAsync(), "CategoryId", "CategoryName", book?.CategoryId);
    }
}
