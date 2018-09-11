using BuuCoin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuuCoin.Repository
{
    public interface ICategoryRepository : IDisposable
    {
        Int32 Insert(Category model);
        Int32 Update(Category model);
        List<Category> GetAll();
        Category GetById(Int32 id);
        void Delete(Int32 id);
    }
}
