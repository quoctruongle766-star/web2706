using lmq_Day01.Models;

namespace lmq_Day01.Services;

internal class StudentService
{
    private readonly List<Student> danhSachSV = new List<Student>();

    public List<Student> LayDanhSach()
    {
        return danhSachSV;
    }

    // 1. Thêm sinh viên
    public bool ThemSinhVien(Student sv, out string thongBao)
    {
        if (danhSachSV.Any(x =>
            x.masv.Equals(sv.masv, StringComparison.OrdinalIgnoreCase)))
        {
            thongBao = "Mã sinh viên đã tồn tại.";
            return false;
        }

        danhSachSV.Add(sv);
        thongBao = "Đã thêm sinh viên thành công.";
        return true;
    }

    // 2. Tìm theo mã
    public Student? TimTheoMa(string masv)
    {
        return danhSachSV.FirstOrDefault(
            x => x.masv.Equals(masv, StringComparison.OrdinalIgnoreCase));
    }

    // 3. Tìm gần đúng theo họ tên
    public List<Student> TimGanDungTheoHoTen(string tuKhoa)
    {
        return danhSachSV
            .Where(x => x.hoTen.Contains(
                tuKhoa,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // 4. Cập nhật sinh viên
    public bool CapNhatSinhVien(
        string masv,
        Student thongTinMoi,
        out string thongBao)
    {
        Student? sv = TimTheoMa(masv);

        if (sv == null)
        {
            thongBao = "Không tìm thấy sinh viên.";
            return false;
        }

        sv.hoTen = thongTinMoi.hoTen;
        sv.ngaysinh = thongTinMoi.ngaysinh;
        sv.gioitinh = thongTinMoi.gioitinh;
        sv.email = thongTinMoi.email;
        sv.soDienThoai = thongTinMoi.soDienThoai;
        sv.nganhHoc = thongTinMoi.nganhHoc;
        sv.dtb = thongTinMoi.dtb;
        sv.trangThai = thongTinMoi.trangThai;

        thongBao = "Cập nhật sinh viên thành công.";
        return true;
    }

    // 5. Xóa sinh viên
    public bool XoaSinhVien(string masv, out string thongBao)
    {
        Student? sv = TimTheoMa(masv);

        if (sv == null)
        {
            thongBao = "Không tìm thấy sinh viên.";
            return false;
        }

        danhSachSV.Remove(sv);
        thongBao = "Đã xóa sinh viên.";
        return true;
    }

    // 6. Sắp xếp theo họ tên
    public List<Student> SapXepTheoHoTen()
    {
        return danhSachSV
            .OrderBy(x => x.hoTen)
            .ToList();
    }

    // 7. Sắp xếp theo điểm trung bình
    public List<Student> SapXepTheoDiem()
    {
        return danhSachSV
            .OrderByDescending(x => x.dtb)
            .ToList();
    }

    // 8. Lọc sinh viên có điểm từ 8 trở lên
    public List<Student> LocDiemTu8TroLen()
    {
        return danhSachSV
            .Where(x => x.dtb >= 8)
            .OrderByDescending(x => x.dtb)
            .ToList();
    }

    // 9. Sinh viên có điểm cao nhất
    public List<Student> SinhVienDiemCaoNhat()
    {
        if (danhSachSV.Count == 0)
            return new List<Student>();

        float diemCaoNhat = danhSachSV.Max(x => x.dtb);

        return danhSachSV
            .Where(x => x.dtb == diemCaoNhat)
            .ToList();
    }

    // 10. Điểm trung bình toàn bộ
    public double TinhDiemTrungBinhToanBo()
    {
        if (danhSachSV.Count == 0)
            return 0;

        return danhSachSV.Average(x => x.dtb);
    }

    // 11. Thống kê theo ngành
    public Dictionary<string, int> ThongKeTheoNganh()
    {
        return danhSachSV
            .GroupBy(x => x.nganhHoc)
            .ToDictionary(x => x.Key, x => x.Count());
    }

    // 12. Thống kê theo trạng thái
    public Dictionary<string, int> ThongKeTheoTrangThai()
    {
        return danhSachSV
            .GroupBy(x => x.trangThai ? "Đang học" : "Không còn học")
            .ToDictionary(x => x.Key, x => x.Count());
    }

    // 13. Hiển thị danh sách
    public List<Student> HienThiDanhSach()
    {
        return danhSachSV.ToList();
    }
}
