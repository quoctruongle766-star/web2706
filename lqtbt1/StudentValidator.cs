using System.Text.RegularExpressions;
using lmq_Day01.Models;

namespace lmq_Day01.Validators;

internal static class StudentValidator
{
    public static bool KiemTraMaSinhVien(string? masv)
    {
        return !string.IsNullOrWhiteSpace(masv);
    }

    public static bool KiemTraHoTen(string? hoTen)
    {
        return !string.IsNullOrWhiteSpace(hoTen);
    }

    public static bool KiemTraDiem(float dtb)
    {
        return dtb >= 0 && dtb <= 10;
    }

    public static bool KiemTraEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool KiemTraSinhVien(Student sv, out string loi)
    {
        if (!KiemTraMaSinhVien(sv.masv))
        {
            loi = "Mã sinh viên không được để trống.";
            return false;
        }

        if (!KiemTraHoTen(sv.hoTen))
        {
            loi = "Họ tên không được để trống.";
            return false;
        }

        if (!KiemTraDiem(sv.dtb))
        {
            loi = "Điểm trung bình phải từ 0 đến 10.";
            return false;
        }

        if (!string.IsNullOrWhiteSpace(sv.email) && !KiemTraEmail(sv.email))
        {
            loi = "Email không đúng định dạng.";
            return false;
        }

        if (sv.ngaysinh.HasValue && sv.ngaysinh.Value.Date > DateTime.Today)
        {
            loi = "Ngày sinh không hợp lệ.";
            return false;
        }

        loi = string.Empty;
        return true;
    }
}
