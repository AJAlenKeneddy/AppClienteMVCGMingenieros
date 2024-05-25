using Microsoft.EntityFrameworkCore;
using AppClienteMVCGMingenieros.Models;


var builder = WebApplication.CreateBuilder(args);
var conexion = builder.Configuration.GetConnectionString("cn1");

builder.Services.AddDbContext<DatadecomprasgmContext>(options =>
{
    options.UseSqlServer(conexion);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comprobantes}/{action=IndexComprobantes}/{id?}");

app.Run();
