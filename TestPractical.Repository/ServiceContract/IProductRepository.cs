using TestPractical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractical.Repository
{
    public interface IProductRepository : IDisposable
    {
        Int32 Insert(Product model);
        Int32 Update(Product model);
        List<Product> GetAll();
        Product GetById(Int32 id);
        void Delete(Int32 id);
    }
}
