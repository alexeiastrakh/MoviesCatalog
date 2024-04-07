using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MoviesCatalog.Models.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MovieDbContext>(option => option.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Movie}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "movies",
        pattern: "movies/{action=Index/{id?}",
        defaults: new { controller = "Movie" });
    endpoints.MapControllerRoute(
        name: "categories",
        pattern: "categories/{action=Index}/{id?}",
        defaults: new { controller = "Category" });
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
