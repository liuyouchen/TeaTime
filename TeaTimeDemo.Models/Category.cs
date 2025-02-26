using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeaTimeDemo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("類別名稱")]
        public string Name { get; set; }
        [DisplayName("顯示順序")]
        [Range(1, 100, ErrorMessage = "輸入範圍應該要在1-100之間")]
        public int DisplayOrder { get; set; }
    }
}
//Category Model define Category metadata
//Microsoft.EntityFrameworkCore.* version munt be same
//must inherit Dbcontext
//public class MyDbContext : DbContext
//{
//    public DbSet<Customer> Customers { get; set; }
//}

//public class Customer
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//}