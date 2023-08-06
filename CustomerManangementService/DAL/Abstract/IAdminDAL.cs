using CustomerManangementService.Core.DataAccess;
using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.DAL.Abstract
{
    public interface IAdminDAL : IEntityRepository<Admin>
    { 
        Admin Login(Admin adminDTO);
        
    }
}
