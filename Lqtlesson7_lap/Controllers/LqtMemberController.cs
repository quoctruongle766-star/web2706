using Microsoft.AspNetCore.Mvc;
using Lqtlesson7_lap.Models.DataModels;
using Lqtlesson7_lap.Models.ViewModels;

namespace Lqtlesson7_lap.Controllers;

public class LqtMemberController : Controller
{
    private static readonly List<LqtMember> LqtMembers = new();

    public IActionResult Index()
    {
        return View(LqtMembers);
    }

    // Data Annotation + ModelState validation giống nội dung slide.
    [HttpGet]
    public IActionResult Create()
    {
        return View(new LqtRegisterViewModel
        {
            Birthday = DateTime.Now.AddYears(-18)
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(LqtRegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            var lqtMember = new LqtMember
            {
                MemberId = Guid.NewGuid().ToString(),
                UserName = register.UserName,
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                ConfirmPassword = register.ConfirmPassword,
                Phone = register.Phone,
                Birthday = register.Birthday
            };

            LqtMembers.Add(lqtMember);
            return RedirectToAction(nameof(Index));
        }

        return View(register);
    }

    // Ví dụ Manual Validation: kiểm tra trực tiếp trong Action.
    [HttpGet]
    public IActionResult ManualCreate()
    {
        return View(new LqtMember());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ManualCreate(LqtMember lqtMember)
    {
        var lqtIsValid = true;

        if (string.IsNullOrWhiteSpace(lqtMember.UserName) ||
            lqtMember.UserName.Length < 3 ||
            lqtMember.UserName.Length > 20)
        {
            ModelState.AddModelError(nameof(lqtMember.UserName),
                "Tên đăng nhập phải từ 3 đến 20 ký tự.");
            lqtIsValid = false;
        }

        if (string.IsNullOrWhiteSpace(lqtMember.FullName))
        {
            ModelState.AddModelError(nameof(lqtMember.FullName),
                "Họ và tên không được trống.");
            lqtIsValid = false;
        }

        if (string.IsNullOrWhiteSpace(lqtMember.Email) ||
            !lqtMember.Email.Contains('@'))
        {
            ModelState.AddModelError(nameof(lqtMember.Email),
                "Email không hợp lệ.");
            lqtIsValid = false;
        }

        if (lqtMember.Password != lqtMember.ConfirmPassword)
        {
            ModelState.AddModelError(nameof(lqtMember.ConfirmPassword),
                "Mật khẩu xác nhận không khớp.");
            lqtIsValid = false;
        }

        if (!lqtIsValid)
            return View(lqtMember);

        LqtMembers.Add(lqtMember);
        return RedirectToAction(nameof(Index));
    }
}
