# Bài 1 - Quản lý sinh viên

## Thông tin
- Ngôn ngữ: C#
- Framework: .NET 8
- Loại chương trình: Console
- Namespace: `lqt_Day01`

## Cấu trúc
- `Program.cs`: điểm bắt đầu chương trình.
- `Models/Student.cs`: lớp Student và thông tin sinh viên.
- `Services/StudentService.cs`: xử lý danh sách và các chức năng nghiệp vụ.
- `Validators/StudentValidator.cs`: kiểm tra dữ liệu đầu vào.
- `Views/StudentConsoleView.cs`: nhập và hiển thị dữ liệu Console.
- `MenuManager.cs`: menu và điều khiển 13 chức năng.

## Chạy chương trình

```bash
dotnet restore
dotnet run
```

## 13 chức năng
1. Thêm sinh viên
2. Hiển thị danh sách
3. Tìm sinh viên theo mã
4. Tìm gần đúng theo họ tên
5. Cập nhật sinh viên
6. Xóa sinh viên
7. Sắp xếp theo họ tên
8. Sắp xếp theo điểm trung bình
9. Hiển thị sinh viên điểm từ 8 trở lên
10. Hiển thị sinh viên điểm cao nhất
11. Tính điểm trung bình toàn bộ sinh viên
12. Thống kê sinh viên theo ngành
13. Thống kê sinh viên theo trạng thái
