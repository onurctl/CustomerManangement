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
    public interface ICustomerDAL : IEntityRepository<Customer>
    {
        public List<CustomerDTO> GetAllCustomer();
        List<Customer> GetCustomerByAdminID(int adminID);
    }
}
