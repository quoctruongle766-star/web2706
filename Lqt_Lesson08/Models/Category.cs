using System.ComponentModel.DataAnnotations;

namespace LqtBookStore.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Display(Name = "Thể loại")]
    public string? CategoryName { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
