using DAL.IRepository;
using DAL.Repository;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ParkSpot.Areas.Identity.Data;
using ParkSpot.DAL.DbAccess;
using ParkSpot.Data;
using ParkSpot.Models;
using Service.Services.UserService;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ParkSpotDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ParkSpotDbContextConnection' not found.");

builder.Services.AddDbContext<ParkSpotDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ParkSlotDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserLoginModel>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ParkSpotDbContext>();
builder.Services.AddScoped(typeof(IParkSlotRepository<>), typeof(ParkSlotRepository<>));
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    _ = endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
app.MapRazorPages();

app.Run();
