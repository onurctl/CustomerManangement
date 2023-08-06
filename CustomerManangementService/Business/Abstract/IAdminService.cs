using CustomerManangementService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.Business.Abstract
{
    public interface IAdminService
    {
        Admin Login(Admin admin);
        Task<IEnumerable<Admin>> GetAllAdmin();
        Task<Admin> GetAdminById(int id);
        Task AddAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        Task UpdateAdmin(Admin admin);
    }
}
