using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //constructer 建構時使用依賴注入DI引入資料庫連線物件
        public DbSet<Category> Categories { get; set; }
        //Dbset is table Dbcontext is application connect db object
        //dbcontext.dbset<T>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "茶飲", DisplayOrder = 1 },
                new Category { Id = 2, Name = "水果茶", DisplayOrder = 2 },
                new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 }
                );
        }
        //modelbuilder is setting database sechma include database logic 1 V M...
    }
}
