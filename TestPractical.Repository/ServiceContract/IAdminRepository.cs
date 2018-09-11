using TestPractical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractical.Repository
{
    public interface IAdminRepository : IDisposable
    {
        Admin GetAdmin(string username, string password);
    }
}
