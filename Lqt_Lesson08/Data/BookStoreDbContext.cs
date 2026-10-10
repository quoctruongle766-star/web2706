using LqtBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace LqtBookStore.Data;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<OrderBook> OrderBooks => Set<OrderBook>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");
            entity.HasKey(x => x.BookId);
            entity.Property(x => x.BookId).HasMaxLength(10);
            entity.Property(x => x.Title).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Author).HasMaxLength(100);
            entity.Property(x => x.Description).HasColumnType("ntext");
            entity.Property(x => x.Picture).HasMaxLength(100);
            entity.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            entity.HasOne(x => x.Category).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("Publisher");
            entity.HasKey(x => x.PublisherId);
            entity.Property(x => x.PublisherName).HasMaxLength(200);
            entity.Property(x => x.Phone).HasMaxLength(30).IsUnicode(false);
            entity.Property(x => x.Address).HasMaxLength(200);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
            entity.HasKey(x => x.CategoryId);
            entity.Property(x => x.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
            entity.HasKey(x => x.AccountId);
            entity.Property(x => x.AccountId).HasMaxLength(36).IsUnicode(false);
            entity.Property(x => x.Username).HasMaxLength(64).IsUnicode(false).IsRequired();
            entity.Property(x => x.Password).HasMaxLength(256).IsUnicode(false);
            entity.Property(x => x.Picture).HasMaxLength(512).IsUnicode(false);
            entity.Property(x => x.Email).HasMaxLength(64).IsUnicode(false);
            entity.Property(x => x.Address).HasMaxLength(512);
            entity.Property(x => x.Phone).HasMaxLength(64).IsUnicode(false);
        });

        modelBuilder.Entity<OrderBook>(entity =>
        {
            entity.ToTable("OrderBook");
            entity.HasKey(x => x.OrderId);
            entity.Property(x => x.OrderId).HasMaxLength(16).IsUnicode(false);
            entity.Property(x => x.AccountId).HasMaxLength(36).IsUnicode(false);
            entity.Property(x => x.ReceiveAddress).HasMaxLength(512);
            entity.Property(x => x.ReceivePhone).HasMaxLength(64).IsUnicode(false);
            entity.Property(x => x.Note).HasMaxLength(512);
            entity.Property(x => x.Status).HasMaxLength(16).IsUnicode(false);
            entity.HasOne(x => x.Account).WithMany(x => x.Orders).HasForeignKey(x => x.AccountId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");
            entity.HasKey(x => x.OrderDetailId);
            entity.Property(x => x.TotalMoney).HasComputedColumnSql("[Quantity]*[Price]", stored: false);
            entity.HasOne(x => x.OrderBook).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            entity.HasOne(x => x.Book).WithMany(x => x.OrderDetails).HasForeignKey(x => x.BookId);
        });
    }
}
