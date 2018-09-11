using BuuCoin.Model;
using BuuCoin.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuuCoin.Repository
{
    public class ProductRepository: IProductRepository
    {
        private TestEntities _context;
        public ProductRepository(TestEntities context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var user = _context.Product.Where(u => u.Id == id).FirstOrDefault();
            _context.Product.Remove(user);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public Product GetById(int id)
        {
            var user = _context.Product.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public Int32 Insert(Product model)
        {
            _context.Product.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public Int32 Update(Product model)
        {
            var user = _context.Product.Where(u => u.Id == model.Id).FirstOrDefault();
            if (user != null)
            {
                user.CategoryId = model.CategoryId;
                user.Name = model.Name;
                user.Description = model.Description;
                user.Price = model.Price;
                _context.SaveChanges();
            }
            return model.Id;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
