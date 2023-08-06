using CustomerManangementService.Business.Abstract;
using CustomerManangementService.DAL.Abstract;
using CustomerManangementService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDAL _adminDAL;
        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public async Task AddAdmin(Admin admin)
        {
            await _adminDAL.AddAsync(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminDAL.Delete(admin);
        }

        public async Task<IEnumerable<Admin>> GetAllAdmin()
        {
            return await _adminDAL.GetAllAsync();
        }

        public Task<Admin> GetAdminById(int id)
        {
            return _adminDAL.GetAsync(x=> x.adminId == id);
        }

        public Admin Login(Admin admin)
        {
            return _adminDAL.Login(admin);
        }

        public  async Task UpdateAdmin(Admin admin)
        {
            var newAdmin = await _adminDAL.GetAsync(x => x.adminId == admin.adminId);
            newAdmin.username = admin.username;
            newAdmin.password = admin.password;
            _adminDAL.Update(newAdmin);
        }
    }
}
