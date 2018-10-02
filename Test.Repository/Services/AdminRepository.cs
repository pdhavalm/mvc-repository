using Test.Model;
using Test.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private TestEntities _context;
        public AdminRepository(TestEntities context)
        {
            _context = context;
        }

        public Admin GetAdmin(string username, string password)
        {
            var data = _context.Admin.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return data;
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
