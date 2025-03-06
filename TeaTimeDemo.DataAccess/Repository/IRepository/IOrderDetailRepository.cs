using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail> //define T is Category
    {
        void Update(OrderDetail obj);
        //void Save();
    }//繼承自irepository 增加定義update的方法 and T s datatype
}
