using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LeQuocTruong_241230876.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Hãy chọn thể loại.")]
    public int MaTL { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên sách.")]
    [StringLength(100, ErrorMessage = "Tên sách dài tối đa 100 ký tự.")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Hãy nhập giá.")]
    [Range(50, 1000, ErrorMessage = "Giá phải từ 50 đến 1000.")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên ảnh.")]
    [StringLength(100, ErrorMessage = "Tên ảnh dài tối đa 100 ký tự.")]
    [RegularExpression(@"[^\x00-\x1F\\/:*?""<>|#%]+", ErrorMessage = "Chỉ nhập tên tệp ảnh.")]
    [FileExtensions(Extensions = "jpg,jpeg,png,webp",
        ErrorMessage = "Ảnh phải có đuôi jpg, jpeg, png hoặc webp.")]
    public string? Anh { get; set; }

    [ValidateNever]
    public virtual TheLoai MaTLNavigation { get; set; } = null!;
}
