using System.ComponentModel.DataAnnotations;

namespace LqtBookStore.Models;

public class Publisher
{
    public int PublisherId { get; set; }
    [Display(Name = "Nhà xuất bản")]
    public string? PublisherName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
