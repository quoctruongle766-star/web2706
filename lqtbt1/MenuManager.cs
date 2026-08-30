using lmq_Day01.Models;
using lmq_Day01.Services;
using lmq_Day01.Validators;
using lmq_Day01.Views;

namespace lqt_Day01;

internal class MenuManager
{
    private readonly StudentService studentService;
    private readonly StudentConsoleView view;

    public MenuManager(
        StudentService studentService,
        StudentConsoleView view)
    {
        this.studentService = studentService;
        this.view = view;
    }

    public void ChayMenu()
    {
        bool tiepTuc = true;

        while (tiepTuc)
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("          QUẢN LÝ SINH VIÊN - BÀI 1");
            Console.WriteLine("==============================================");
            Console.WriteLine("1.  Thêm sinh viên");
            Console.WriteLine("2.  Hiển thị danh sách");
            Console.WriteLine("3.  Tìm sinh viên theo mã");
            Console.WriteLine("4.  Tìm gần đúng theo họ tên");
            Console.WriteLine("5.  Cập nhật sinh viên");
            Console.WriteLine("6.  Xóa sinh viên");
            Console.WriteLine("7.  Sắp xếp theo họ tên");
            Console.WriteLine("8.  Sắp xếp theo điểm trung bình");
            Console.WriteLine("9.  Hiển thị sinh viên điểm từ 8 trở lên");
            Console.WriteLine("10. Hiển thị sinh viên điểm cao nhất");
            Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
            Console.WriteLine("12. Thống kê sinh viên theo ngành");
            Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
            Console.WriteLine("0.  Thoát");
            Console.WriteLine("==============================================");

            Console.Write("Chọn chức năng: ");
            string luaChon = Console.ReadLine() ?? string.Empty;

            try
            {
                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien();
                        break;
                    case "2":
                        HienThiDanhSach();
                        break;
                    case "3":
                        TimTheoMa();
                        break;
                    case "4":
                        TimGanDungTheoHoTen();
                        break;
                    case "5":
                        CapNhatSinhVien();
                        break;
                    case "6":
                        XoaSinhVien();
                        break;
                    case "7":
                        SapXepTheoHoTen();
                        break;
                    case "8":
                        SapXepTheoDiem();
                        break;
                    case "9":
                        LocDiemTu8TroLen();
                        break;
                    case "10":
                        SinhVienDiemCaoNhat();
                        break;
                    case "11":
                        TinhDiemTrungBinhToanBo();
                        break;
                    case "12":
                        ThongKeTheoNganh();
                        break;
                    case "13":
                        ThongKeTheoTrangThai();
                        break;
                    case "0":
                        tiepTuc = false;
                        continue;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            view.TamDung();
        }

        Console.WriteLine("Tạm biệt!");
    }

    private void ThemSinhVien()
    {
        Console.WriteLine("===== 1. THÊM SINH VIÊN =====");

        Student sv = view.NhapSinhVien();

        if (!StudentValidator.KiemTraSinhVien(sv, out string loi))
        {
            Console.WriteLine(loi);
            return;
        }

        studentService.ThemSinhVien(sv, out string thongBao);
        Console.WriteLine(thongBao);
    }

    private void HienThiDanhSach()
    {
        Console.WriteLine("===== 2. HIỂN THỊ DANH SÁCH =====");
        view.HienThiDanhSach(studentService.HienThiDanhSach());
    }

    private void TimTheoMa()
    {
        Console.WriteLine("===== 3. TÌM SINH VIÊN THEO MÃ =====");

        string masv = view.NhapMaSinhVien("Nhập mã sinh viên cần tìm: ");
        Student? sv = studentService.TimTheoMa(masv);

        if (sv == null)
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
            return;
        }

        view.HienThiDanhSach(new[] { sv });
    }

    private void TimGanDungTheoHoTen()
    {
        Console.WriteLine("===== 4. TÌM GẦN ĐÚNG THEO HỌ TÊN =====");

        string tuKhoa = view.NhapTuKhoa();
        List<Student> ketQua = studentService.TimGanDungTheoHoTen(tuKhoa);

        view.HienThiDanhSach(ketQua);
    }

    private void CapNhatSinhVien()
    {
        Console.WriteLine("===== 5. CẬP NHẬT SINH VIÊN =====");

        string masv = view.NhapMaSinhVien(
            "Nhập mã sinh viên cần cập nhật: ");

        Student? sv = studentService.TimTheoMa(masv);

        if (sv == null)
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
            return;
        }

        Console.WriteLine("Thông tin hiện tại:");
        view.HienThiDanhSach(new[] { sv });

        Console.WriteLine("Nhập thông tin mới:");
        Student thongTinMoi = view.NhapSinhVien();

        // Không đổi mã sinh viên khi cập nhật.
        thongTinMoi.masv = sv.masv;

        if (!StudentValidator.KiemTraSinhVien(
            thongTinMoi,
            out string loi))
        {
            Console.WriteLine(loi);
            return;
        }

        studentService.CapNhatSinhVien(
            masv,
            thongTinMoi,
            out string thongBao);

        Console.WriteLine(thongBao);
    }

    private void XoaSinhVien()
    {
        Console.WriteLine("===== 6. XÓA SINH VIÊN =====");

        string masv = view.NhapMaSinhVien(
            "Nhập mã sinh viên cần xóa: ");

        Student? sv = studentService.TimTheoMa(masv);

        if (sv == null)
        {
            Console.WriteLine("Không tìm thấy sinh viên.");
            return;
        }

        view.HienThiDanhSach(new[] { sv });

        if (!view.XacNhan("Bạn có chắc muốn xóa? (Y/N): "))
        {
            Console.WriteLine("Đã hủy xóa.");
            return;
        }

        studentService.XoaSinhVien(
            masv,
            out string thongBao);

        Console.WriteLine(thongBao);
    }

    private void SapXepTheoHoTen()
    {
        Console.WriteLine("===== 7. SẮP XẾP THEO HỌ TÊN =====");
        view.HienThiDanhSach(studentService.SapXepTheoHoTen());
    }

    private void SapXepTheoDiem()
    {
        Console.WriteLine("===== 8. SẮP XẾP THEO ĐIỂM TRUNG BÌNH =====");
        view.HienThiDanhSach(studentService.SapXepTheoDiem());
    }

    private void LocDiemTu8TroLen()
    {
        Console.WriteLine("===== 9. SINH VIÊN ĐIỂM TỪ 8 TRỞ LÊN =====");
        view.HienThiDanhSach(studentService.LocDiemTu8TroLen());
    }

    private void SinhVienDiemCaoNhat()
    {
        Console.WriteLine("===== 10. SINH VIÊN ĐIỂM CAO NHẤT =====");
        view.HienThiDanhSach(studentService.SinhVienDiemCaoNhat());
    }

    private void TinhDiemTrungBinhToanBo()
    {
        Console.WriteLine("===== 11. ĐIỂM TRUNG BÌNH TOÀN BỘ =====");

        double dtb = studentService.TinhDiemTrungBinhToanBo();

        if (studentService.LayDanhSach().Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }

        Console.WriteLine(
            $"Điểm trung bình toàn bộ sinh viên: {dtb:0.00}");
    }

    private void ThongKeTheoNganh()
    {
        Console.WriteLine("===== 12. THỐNG KÊ THEO NGÀNH =====");

        Dictionary<string, int> thongKe =
            studentService.ThongKeTheoNganh();

        if (thongKe.Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }

        foreach (var nhom in thongKe)
            Console.WriteLine($"- {nhom.Key}: {nhom.Value} sinh viên");
    }

    private void ThongKeTheoTrangThai()
    {
        Console.WriteLine("===== 13. THỐNG KÊ THEO TRẠNG THÁI =====");

        Dictionary<string, int> thongKe =
            studentService.ThongKeTheoTrangThai();

        if (thongKe.Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }

        foreach (var nhom in thongKe)
            Console.WriteLine($"- {nhom.Key}: {nhom.Value} sinh viên");
    }

    public void NapDuLieuMau()
    {
        studentService.ThemSinhVien(
            new Student(
                "SV001",
                "Nguyễn Văn An",
                new DateTime(2004, 3, 12),
                true,
                "an.nv@example.com",
                "0901000001",
                "Công nghệ thông tin",
                8.5f,
                true),
            out _);

        studentService.ThemSinhVien(
            new Student(
                "SV002",
                "Trần Thị Bình",
                new DateTime(2003, 11, 5),
                false,
                "binh.tt@example.com",
                "0901000002",
                "Công nghệ thông tin",
                7.2f,
                true),
            out _);

        studentService.ThemSinhVien(
            new Student(
                "SV003",
                "Lê Hoàng Cường",
                new DateTime(2004, 7, 20),
                true,
                "cuong.lh@example.com",
                "0901000003",
                "Kỹ thuật phần mềm",
                9.1f,
                false),
            out _);
    }
}
