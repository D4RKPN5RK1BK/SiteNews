using Microsoft.EntityFrameworkCore;
using SiteNews.sakila;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultDatabase");


builder.Services.AddDbContext<goreftinskyContext>(
    options => options.UseMySQL(connection)
) ;

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
