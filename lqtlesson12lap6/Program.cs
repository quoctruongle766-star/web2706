using Microsoft.EntityFrameworkCore;

using lqtlesson12lap6.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LqtSchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        LqtDbInitializer.LqtInitialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "LearnerCompat",
    pattern: "Learner/{action=Index}/{id?}",
    defaults: new { controller = "LqtLearner" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LqtLearner}/{action=Index}/{id?}");

app.Run();
