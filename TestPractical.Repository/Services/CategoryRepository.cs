using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuuCoin.Model;

namespace BuuCoin.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private TestEntities _context;
        public CategoryRepository(TestEntities context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var user = _context.Category.Where(u => u.Id == id).FirstOrDefault();
            _context.Category.Remove(user);
            _context.SaveChanges();
        }
       
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            var user = _context.Category.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public Int32 Insert(Category model)
        {
            _context.Category.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public Int32 Update(Category model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
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
