using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lqtlesson12lap6.Data;

namespace lqtlesson12lap6.ViewComponents;

public class LqtMajorViewComponent(LqtSchoolContext lqtContext) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var lqtMajors = await lqtContext.Majors.AsNoTracking().OrderBy(m => m.MajorID).ToListAsync();
        return View("LqtRenderMajor", lqtMajors);
    }
}
