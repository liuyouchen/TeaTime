using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }

    //泛型集合可接收class
    //ienumerable<T> 泛型集合 可接收資料庫物件 category...
    //T 資料列 filter 資料型態Expression<Func<T, bool>> lambda x=> x.id == id
    //T entity 資料列
    //ienumerable<T> 資料型態是 泛型集合
}
