using TeaTimeDemo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.DataAccess.Migrations;
using TeaTimeDemo.DataAccess.Repository;
using TeaTimeDemo.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);
//webhost
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//register applicationdbcontext to the container
//use sqlserver as db
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
//use identityframecore page
var app = builder.Build();
//mvc struction
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//https staticfile add file set route
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//authorization
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
//default router struct
app.Run();
//start
// 註冊：你透過 builder.Services.AddScoped<IProductRepository, ProductRepository>() 來註冊 IProductRepository 對應到具體的 ProductRepository 類別。
// 依賴注入使用：當 ProductController 需要 IProductRepository 時，DI 容器會檢查已註冊的類別，並提供一個 ProductRepository 實例。
// 建構函式注入：當你在 ProductController 的建構函式中宣告一個 IProductRepository 參數時，ASP.NET Core 會自動將 ProductRepository 的實例傳入。
