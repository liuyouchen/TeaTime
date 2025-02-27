using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; } //in the same floder can direct use
        IProductRepository Product { get; } //use Interface because need to have more flexable 
        void Save();
    }
}
