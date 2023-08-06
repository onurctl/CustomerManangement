using CustomerManangementService.Business.Abstract;
using CustomerManangementService.Core.DataAccess.EntityFramework;
using CustomerManangementService.DAL.Abstract;
using CustomerManangementService.DAL.Concrete.EntityFramework;
using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.DAL.Concrete
{
    public class EFAdminDAL : EfEntityRepositoryBase<Admin, CustomerManangementDbContext>, IAdminDAL
    {
       

        public Admin Login(Admin admin)
        {
            using (CustomerManangementDbContext db = new CustomerManangementDbContext())
            {
                var obj = db.Admin.Where(a => a.username == admin.username && a.password == admin.password).FirstOrDefault();
                return obj;
            }
        }
    }
}
