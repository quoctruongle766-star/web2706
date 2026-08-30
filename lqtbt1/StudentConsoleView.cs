using lmq_Day01.Models;
using lmq_Day01.Validators;

namespace lmq_Day01.Views;

internal class StudentConsoleView
{
    public void HienThiDanhSach(IEnumerable<Student> danhSach)
    {
        List<Student> ds = danhSach.ToList();

        if (ds.Count == 0)
        {
            Console.WriteLine("Danh sách trống.");
            return;
        }

        Console.WriteLine(
            "-------------------------------------------------------------------------------------------------------------");
        Console.WriteLine(
            $"{"MSSV",-8} | {"Họ tên",-20} | {"Ngày sinh",-10} | {"GT",-3} | {"Ngành học",-22} | {"DTB",-6} | {"Trạng thái"}");
        Console.WriteLine(
            "-------------------------------------------------------------------------------------------------------------");

        foreach (Student sv in ds)
            sv.InThongTin();

        Console.WriteLine(
            "-------------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"-> Tổng cộng: {ds.Count} sinh viên.");
    }

    public Student NhapSinhVien()
    {
        Console.Write("Mã sinh viên: ");
        string masv = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Họ tên: ");
        string hoTen = Console.ReadLine()?.Trim() ?? string.Empty;

        DateTime? ngaysinh = NhapNgaySinh();

        Console.Write("Giới tính (1 = Nam, 0 = Nữ): ");
        bool gioitinh = Console.ReadLine() == "1";

        Console.Write("Email (Enter để bỏ trống): ");
        string email = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Số điện thoại (Enter để bỏ trống): ");
        string soDienThoai = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("Ngành học: ");
        string nganhHoc = Console.ReadLine()?.Trim() ?? string.Empty;

        float dtb = NhapDiem();

        Console.Write("Trạng thái (1 = Đang học, 0 = Không còn học): ");
        bool trangThai = Console.ReadLine() != "0";

        return new Student(
            masv,
            hoTen,
            ngaysinh,
            gioitinh,
            email,
            soDienThoai,
            nganhHoc,
            dtb,
            trangThai);
    }

    public DateTime? NhapNgaySinh()
    {
        while (true)
        {
            Console.Write("Ngày sinh (dd/MM/yyyy, Enter để bỏ trống): ");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (DateTime.TryParseExact(
                input,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime ngaySinh)
                && ngaySinh.Date <= DateTime.Today)
            {
                return ngaySinh;
            }

            Console.WriteLine("Ngày sinh không hợp lệ.");
        }
    }

    public float NhapDiem()
    {
        while (true)
        {
            Console.Write("Điểm trung bình (0 - 10): ");

            if (float.TryParse(Console.ReadLine(), out float dtb)
                && StudentValidator.KiemTraDiem(dtb))
            {
                return dtb;
            }

            Console.WriteLine("Điểm phải nằm trong khoảng 0 đến 10.");
        }
    }

    public string NhapMaSinhVien(string noiDung)
    {
        Console.Write(noiDung);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public string NhapTuKhoa()
    {
        Console.Write("Nhập từ khóa họ tên: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public bool XacNhan(string noiDung)
    {
        Console.Write(noiDung);
        string traLoi = Console.ReadLine() ?? string.Empty;
        return traLoi.Equals("Y", StringComparison.OrdinalIgnoreCase);
    }

    public void TamDung()
    {
        Console.WriteLine();
        Console.WriteLine("Nhấn Enter để tiếp tục...");
        Console.ReadLine();
    }
}
