using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/Views/Student/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/LqtStudent/{0}.cshtml");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "StudentList",
    pattern: "Admin/Student/List",
    defaults: new { controller = "LqtStudent", action = "Index" });

app.MapControllerRoute(
    name: "StudentCreate",
    pattern: "Admin/Student/Add",
    defaults: new { controller = "LqtStudent", action = "Create" });

app.MapControllerRoute(
    name: "StudentCompat",
    pattern: "Student/{action=Index}/{id?}",
    defaults: new { controller = "LqtStudent" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LqtStudent}/{action=Index}/{id?}");

app.Run();
