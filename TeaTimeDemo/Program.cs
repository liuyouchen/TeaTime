using TeaTimeDemo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.DataAccess.Migrations;
using TeaTimeDemo.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);
//webhost
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//use sqlserver as db
//register applicationdbcontext to the container
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

app.UseAuthorization();
//authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
//default router struct
app.Run();
//start
//註冊：您通過 builder.Services.AddScoped<IProductRepository, ProductRepository>() 將 IProductRepository 映射到 ProductRepository 類。
//控制器使用：當 ProductController 被創建時，DI 容器會檢查它的建構函數，發現需要一個 IProductRepository 實例。
//容器注入：容器根據註冊的信息創建 ProductRepository 的實例，並將它注入到 ProductController 中。