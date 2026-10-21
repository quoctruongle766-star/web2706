using Microsoft.AspNetCore.Mvc;
using LqtThlap2.Models;

namespace LqtThlap2.ViewComponents
{
    [ViewComponent(Name = "Render")]
    public class LqtRenderViewComponent : ViewComponent
    {
        private List<LqtMenuItem> MenuItems = new List<LqtMenuItem>();

        public LqtRenderViewComponent()
        {
            MenuItems = new List<LqtMenuItem>()
            {
                new LqtMenuItem() { Id = 1, Name = "Branches", Link = "Branches/List" },
                new LqtMenuItem() { Id = 2, Name = "Students", Link = "Students/List" },
                new LqtMenuItem() { Id = 3, Name = "Subjects", Link = "Subjects/List" },
                new LqtMenuItem() { Id = 4, Name = "Courses", Link = "Courses/List" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
