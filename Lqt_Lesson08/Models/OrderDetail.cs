namespace LqtBookStore.Models;

public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public string? OrderId { get; set; }
    public string? BookId { get; set; }
    public int? Quantity { get; set; }
    public int? Price { get; set; }
    public int? TotalMoney { get; private set; }
    public OrderBook? OrderBook { get; set; }
    public Book? Book { get; set; }
}
