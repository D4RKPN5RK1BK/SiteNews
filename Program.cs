using Microsoft.EntityFrameworkCore;
using SiteNews.sakila;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<goreftinskyContext>(
    options => options.UseMySQL("server=192.168.0.7;user=news_connection;password=bBnlqBf2;database=goreftinsky")
) ;
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");
});

app.Run();
