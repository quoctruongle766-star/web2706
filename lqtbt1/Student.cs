namespace lmq_Day01.Models;

internal class Student
{
    public string masv { get; set; } = string.Empty;
    public string hoTen { get; set; } = string.Empty;
    public DateTime? ngaysinh { get; set; }
    public bool gioitinh { get; set; }
    public string email { get; set; } = string.Empty;
    public string soDienThoai { get; set; } = string.Empty;
    public string nganhHoc { get; set; } = string.Empty;
    public float dtb { get; set; }
    public bool trangThai { get; set; }

    public Student()
    {
    }

    public Student(
        string masv,
        string hoTen,
        DateTime? ngaysinh,
        bool gioitinh,
        string email,
        string soDienThoai,
        string nganhHoc,
        float dtb,
        bool trangThai)
    {
        this.masv = masv;
        this.hoTen = hoTen;
        this.ngaysinh = ngaysinh;
        this.gioitinh = gioitinh;
        this.email = email;
        this.soDienThoai = soDienThoai;
        this.nganhHoc = nganhHoc;
        this.dtb = dtb;
        this.trangThai = trangThai;
    }

    public void InThongTin()
    {
        string gioiTinhStr = gioitinh ? "Nam" : "Nữ";
        string trangThaiStr = trangThai ? "Đang học" : "Không còn học";
        string ngaySinhStr = ngaysinh.HasValue
            ? ngaysinh.Value.ToString("dd/MM/yyyy")
            : "Chưa có";

        Console.WriteLine(
            $"{masv,-8} | {hoTen,-20} | {ngaySinhStr,-10} | {gioiTinhStr,-3} | " +
            $"{nganhHoc,-22} | DTB: {dtb,4:0.0} | {trangThaiStr}");
    }
}
