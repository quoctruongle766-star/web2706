using Microsoft.AspNetCore.Mvc;
using LqtLesson06Models.Models;

namespace LqtLesson06Models.Controllers
{
    public class LqtMemberController : Controller
    {
        // mock data
        private static readonly List<LqtMember> _lqtMembers = new List<LqtMember>()
        {
            new LqtMember
    {
        LqtMemberId = Guid.NewGuid().ToString(),
        LqtMemberUserName = "QuocTruongLe",
        LqtMemberPassword = "Truong111@",
        LqtMemberFullName = "Lê Quốc Trưởng",
        LqtMemberEmail = "quoctruongle@gmail.com"
    },

    new LqtMember
    {
        LqtMemberId = Guid.NewGuid().ToString(),
        LqtMemberUserName = "tranthib",
        LqtMemberPassword = "123456",
        LqtMemberEmail = "tranthib@gmail.com",
        LqtMemberFullName = "Trần Thị B"
    },

    new LqtMember
    {
        LqtMemberId = Guid.NewGuid().ToString(),
        LqtMemberUserName = "levanc",
        LqtMemberPassword = "123456",
        LqtMemberEmail = "levanc@gmail.com",
        LqtMemberFullName = "Lê Văn C"
    },

    new LqtMember
    {
        LqtMemberId = Guid.NewGuid().ToString(),
        LqtMemberUserName = "phamthid",
        LqtMemberPassword = "123456",
        LqtMemberEmail = "phamthid@gmail.com",
        LqtMemberFullName = "Phạm Thị D"
    },

    new LqtMember
    {
        LqtMemberId = Guid.NewGuid().ToString(),
        LqtMemberUserName = "hoangvane",
        LqtMemberPassword = "123456",
        LqtMemberEmail = "hoangvane@gmail.com",
        LqtMemberFullName = "Hoàng Văn E"
    }
        };

        public IActionResult LqtIndex()
        {
            return View();
        }

        public IActionResult LqtCreate()
        {
            return View();
        }

        public IActionResult LqtEdit(string id)
        {
            var lqtMember = _lqtMembers.FirstOrDefault(x => x.LqtMemberId.Equals(id));
            return View(lqtMember);
        }

        [HttpPost]
        public IActionResult LqtEdit(string id, LqtMember lqtMember)
        {
            for (int i = 0; i < _lqtMembers.Count; i++)
            {
                if (_lqtMembers[i].LqtMemberId == id)
                {
                    _lqtMembers[i].LqtMemberId = lqtMember.LqtMemberId;
                    _lqtMembers[i].LqtMemberUserName = lqtMember.LqtMemberUserName;
                    _lqtMembers[i].LqtMemberPassword = lqtMember.LqtMemberPassword;
                    _lqtMembers[i].LqtMemberFullName = lqtMember.LqtMemberFullName;
                    _lqtMembers[i].LqtMemberEmail = lqtMember.LqtMemberEmail;
                }
            }

            return RedirectToAction("LqtIndex");
        }

        public IActionResult LqtGetDetails()
        {
            var lqtMember = new LqtMember()
            {
                LqtMemberId = Guid.NewGuid().ToString(),
                LqtMemberUserName = "QuocTruongLe",
                LqtMemberPassword = "Truong111@",
                LqtMemberFullName = "Lê Quốc Trưởng",
                LqtMemberEmail = "quoctruongle@gmail.com"
            };

            return View(lqtMember);
        }
    }
}