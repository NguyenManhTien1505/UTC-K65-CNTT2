using Microsoft.EntityFrameworkCore;
using nmt_231230923_de02.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NguyenManhTien231230923De02Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NguyenManhTien231230923De02Connection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NmtHome}/{action=NmtIndex}/{id?}");
// Map Razor Pages so Pages/Index.cshtml (and other .cshtml pages) are reachable at "/"
app.MapRazorPages();
app.Run();
