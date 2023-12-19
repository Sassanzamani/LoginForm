using LoginForm.DataAccessLayer;
using LoginForm.Interfaces;
using LoginForm.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LoginDbCnSt");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(ICRUDServices), typeof(CRUDservices));
//builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();
app.UseAuthorization();
app.UseSession();
//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LoginPage}/{id?}");

app.Run();
