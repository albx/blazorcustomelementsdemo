using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Web.Site.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyAwesomeBlogContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyAwesomeBlog")));

builder.Services.AddScoped<PostsControllerServices>();

builder.Services.AddControllersWithViews();

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
    name: "PostDetail",
    pattern: "posts/d/{id:int}/{slug}",
    defaults: new { controller = "Posts", action = "Detail" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
