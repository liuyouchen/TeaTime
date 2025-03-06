using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository//inherit class and interface
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)//parent constructer
        {
            _db = db;
        }

        public void Update(ShoppingCart obj)
        {
            _db.shoppingCarts.Update(obj);
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}
    }
}
