using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LqtBookStore.Models;

public class Book
{
    [Key, StringLength(10)]
    [Display(Name = "Mã sách")]
    public string BookId { get; set; } = "";

    [Required, StringLength(200)]
    [Display(Name = "Tên sách")]
    public string Title { get; set; } = "";

    [StringLength(100)]
    [Display(Name = "Tác giả")]
    public string? Author { get; set; }

    [Display(Name = "Năm phát hành")]
    public int? Release { get; set; }

    [Display(Name = "Giá")]
    public double? Price { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    public string? Picture { get; set; }
    public int? PublisherId { get; set; }
    public int? CategoryId { get; set; }

    [ForeignKey(nameof(PublisherId))]
    public Publisher? Publisher { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
