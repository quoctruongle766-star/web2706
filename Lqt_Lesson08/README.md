# LqtBookStore

**Người thực hiện: Quốc Trưởng**  
**Công nghệ:** ASP.NET Core MVC, .NET 10, SQL Server, Entity Framework Core 10.

Project quản lý sách dựa trên database `BookStoreDB`, đổi tên project/namespace sang `LqtBookStore` và tên người thực hiện sang `Quốc Trưởng`.

## 1. Tạo database

1. Mở SQL Server Management Studio (SSMS).
2. Mở và chạy `Database/BookStoreDB.sql` một lần để tạo database, 6 bảng và dữ liệu mẫu.
3. Script đã cố định `AccountId` của tài khoản admin để khóa ngoại của đơn hàng mẫu hợp lệ.

> Nếu database `BookStoreDB` đã có các bảng, không chạy lại script tạo bảng. Hãy dùng database hiện có hoặc xóa database mẫu trước khi tạo lại.

## 2. Cấu hình kết nối

Mở `appsettings.json` và sửa chuỗi kết nối `BookStoreDB` cho đúng SQL Server của máy. Ví dụ:

- SQL Server mặc định: `Server=.;Database=BookStoreDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true`
- SQL Server Express: `Server=TENMAY\SQLEXPRESS;Database=BookStoreDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true`

## 3. Database-First theo slide

Slide minh họa dùng `Scaffold-DbContext` để sinh model và `DbContext` từ database đã có. Project đã kèm package `Microsoft.EntityFrameworkCore.Tools` và script `Scripts/Scaffold-DatabaseFirst.ps1`.

### Thực hiện trong Visual Studio

1. Mở `LqtBookStore.sln`.
2. Chọn **Tools → NuGet Package Manager → Package Manager Console**.
3. Chọn `LqtBookStore` làm **Default project**.
4. Đảm bảo database `BookStoreDB` đã tồn tại và chuỗi kết nối trong script đúng với máy bạn.
5. Nếu muốn sinh lại model trực tiếp từ database theo slide, chạy nội dung lệnh trong `Scripts/Scaffold-DatabaseFirst.ps1` tại Package Manager Console.

Lệnh tương đương:

```powershell
Scaffold-DbContext "Server=.;Database=BookStoreDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context BookStoreDbContext -Namespace LqtBookStore.Models -ContextNamespace LqtBookStore.Data -NoOnConfiguring -DataAnnotations -Force
```

**Chú ý:** `-Force` sẽ ghi đè các model và `BookStoreDbContext` hiện tại. Hãy commit Git hoặc sao lưu trước khi chạy. Sau khi scaffold, kiểm tra lại các tên DbSet/thuộc tính với `Data/BookRepository.cs`; nếu công cụ sinh tên khác, đồng bộ các tên trong repository.

Các model đang có trong project được ánh xạ theo schema SQL bạn cung cấp để project có thể mở và thực hành ngay. Lệnh scaffold là bước tái tạo model từ database theo đúng quy trình Database-First của slide.

## 4. Chạy project

1. Cài Visual Studio có workload **ASP.NET and web development** và .NET 10 SDK.
2. Mở `LqtBookStore.sln`, đợi NuGet restore hoàn tất.
3. Sửa chuỗi kết nối nếu cần.
4. Nhấn F5 hoặc Ctrl+F5. Trang đầu mở danh sách sách.

## 5. Chức năng đã có

- Danh sách sách và tìm kiếm theo tên/tác giả bằng LINQ.
- Xem chi tiết, thêm, sửa và xóa sách.
- Lấy thể loại/nhà xuất bản từ database cho dropdown.
- `BookStoreDbContext` cấu hình các bảng và quan hệ khóa ngoại.
- `IBookRepository` / `BookRepository` và đăng ký Dependency Injection.

## 6. Đưa lên GitHub

Trong Terminal tại thư mục project:

```bash
git init
git add .
git commit -m "Hoan thien LqtBookStore Database First"
git branch -M main
git remote add origin https://github.com/TEN_GITHUB_CUA_BAN/LqtBookStore.git
git push -u origin main
```

Thay URL ví dụ bằng URL repository bạn tạo trên GitHub. Không đưa mật khẩu hoặc thông tin kết nối nhạy cảm lên repository công khai.

## Giới hạn đã biết

Mã nguồn đã được chỉnh sửa và đóng gói, nhưng chưa thể build/chạy kiểm thử trên máy có SQL Server trong môi trường tạo file này. Sau khi chạy trên máy bạn, nếu có lỗi biên dịch hoặc kết nối, hãy gửi nguyên thông báo lỗi để xử lý tiếp.
