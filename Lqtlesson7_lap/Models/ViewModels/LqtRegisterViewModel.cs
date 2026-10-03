using System.ComponentModel.DataAnnotations;

namespace Lqtlesson7_lap.Models.ViewModels;

public class LqtRegisterViewModel
{
    [DisplayName("Tên đăng nhập")]
    [Required(ErrorMessage = "Tên đăng nhập không được trống")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài tên từ 3-20 ký tự")]
    public string UserName { get; set; } = string.Empty;

    [DisplayName("Họ và tên")]
    [Required(ErrorMessage = "Họ và tên không được trống")]
    public string FullName { get; set; } = string.Empty;

    [DisplayName("Mật khẩu")]
    [Required(ErrorMessage = "Hãy nhập Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DisplayName("Gõ lại mật khẩu")]
    [Required(ErrorMessage = "Hãy nhập không khớp")]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;

    [DisplayName("Hộp thư")]
    [Required(ErrorMessage = "Email không bỏ trống")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Điện thoại")]
    [RegularExpression(@"^0\d{9,12}$", ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-13 số")]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("Ngày sinh")]
    public DateTime Birthday { get; set; }
}
