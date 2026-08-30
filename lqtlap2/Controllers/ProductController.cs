using Microsoft.AspNetCore.Mvc;
using Lab02_Controller.Models;

namespace Lab02_Controller.Controllers;

public class ProductController : Controller
{
    private static readonly List<Category> Categories = new()
    {
        new Category { Id = 1, Name = "Đồ bơi cho trẻ em" },
        new Category { Id = 2, Name = "Thời trang nam" },
        new Category { Id = 3, Name = "Thời trang nữ" },
        new Category { Id = 4, Name = "Phụ kiện" }
    };

    private static readonly List<Product> Products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Bộ đồ bơi cho trẻ em nam",
            Image = "/images/product-1.svg",
            Price = 50000,
            SalePrice = 35000,
            Categoryid = 1,
            Description = "Bộ đồ bơi cho trẻ em nam, chất liệu nhẹ, phù hợp khi đi bơi.",
            Status = true,
            CreatedAt = new DateTime(2021, 7, 15)
        },
        new Product
        {
            Id = 2,
            Name = "Bộ đồ bơi cho trẻ em gái",
            Image = "/images/product-2.svg",
            Price = 60000,
            SalePrice = 42000,
            Categoryid = 1,
            Description = "Bộ đồ bơi cho trẻ em gái, thiết kế thoải mái và dễ vận động.",
            Status = true,
            CreatedAt = new DateTime(2021, 7, 16)
        },
        new Product
        {
            Id = 3,
            Name = "Áo thun nam Basic 2021",
            Image = "/images/product-3.svg",
            Price = 120000,
            SalePrice = 89000,
            Categoryid = 2,
            Description = "Áo thun nam kiểu basic, phù hợp mặc hằng ngày.",
            Status = true,
            CreatedAt = new DateTime(2021, 8, 2)
        },
        new Product
        {
            Id = 4,
            Name = "Quần short nam thể thao",
            Image = "/images/product-4.svg",
            Price = 180000,
            SalePrice = 135000,
            Categoryid = 2,
            Description = "Quần short nam phong cách thể thao, tiện dụng.",
            Status = true,
            CreatedAt = new DateTime(2021, 8, 8)
        },
        new Product
        {
            Id = 5,
            Name = "Áo thun nữ thời trang",
            Image = "/images/product-5.svg",
            Price = 150000,
            SalePrice = 99000,
            Categoryid = 3,
            Description = "Áo thun nữ thời trang, thiết kế đơn giản và dễ phối đồ.",
            Status = true,
            CreatedAt = new DateTime(2021, 8, 12)
        },
        new Product
        {
            Id = 6,
            Name = "Túi đeo chéo thời trang",
            Image = "/images/product-6.svg",
            Price = 220000,
            SalePrice = 175000,
            Categoryid = 4,
            Description = "Túi đeo chéo nhỏ gọn, phù hợp sử dụng hằng ngày.",
            Status = false,
            CreatedAt = new DateTime(2021, 9, 1)
        }
    };

    public IActionResult Index(int? id)
    {
        ViewBag.Categories = Categories;
        ViewBag.SelectedCategoryId = id;

        List<Product> products = id.HasValue
            ? Products.Where(p => p.Categoryid == id.Value).ToList()
            : Products;

        ViewBag.Products = products;
        return View();
    }

    public IActionResult Details(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        ViewBag.Category = Categories.FirstOrDefault(c => c.Id == product.Categoryid);
        return View(product);
    }
}
