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
    public class EFCustomerDAL : EfEntityRepositoryBase<Customer, CustomerManangementDbContext>, ICustomerDAL
   {

        public List<Customer> GetCustomerByAdminID(int adminID)
        {
            using (CustomerManangementDbContext db = new CustomerManangementDbContext())
            {
                var result = db.Admin.Join(db.Customer, admin => admin.adminId, customer => customer.adminId, (admin, customer) => new
                {
                    customer.customerId,
                    customer.adminId,
                    customer.nameSurname,
                    customer.phone,
                    customer.adress
                })
                .Where(c => c.adminId == adminID).ToList();
                var listCustomer = new List<Customer>();
                foreach (var r in result)
                {
                    var customer = new Customer()
                    {
                        adminId = r.adminId,
                        customerId = r.customerId,
                        nameSurname = r.nameSurname,
                        phone = r.phone,
                        adress = r.adress
                    };
                    listCustomer.Add(customer);
                }
                return listCustomer != null ? listCustomer : null;

            }
        }
        public List<CustomerDTO> GetAllCustomer()
        {
            using(CustomerManangementDbContext  db = new CustomerManangementDbContext())
            {
                var listCustomer = db.Customer.Join(db.Admin, c => c.adminId, a => a.adminId, (c, a) => new CustomerDTO
                {
                    customerId = c.customerId,
                    Admin = a.username,
                    nameSurname = c.nameSurname,
                    adress = c.adress,
                    phone = c.phone
                }).ToList();
                return listCustomer;

            }
        }
    }
}
