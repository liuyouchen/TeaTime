using TeaTimeDemo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.DataAccess.Migrations;
using TeaTimeDemo.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//webhost
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
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
app.UseAuthentication();
app.UseAuthorization();
//authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
//default router struct
app.Run();
//start
//���U�G�z�q�L builder.Services.AddScoped<IProductRepository, ProductRepository>() �N IProductRepository �M�g�� ProductRepository ���C
//����ϥΡG�� ProductController �Q�ЫخɡADI �e���|�ˬd�����غc��ơA�o�{�ݭn�@�� IProductRepository ��ҡC
//�e���`�J�G�e���ھڵ��U���H���Ы� ProductRepository ����ҡA�ñN���`�J�� ProductController ���C