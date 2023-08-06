using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.Business.Abstract
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task Update(Customer customer);
        void DeleteCustomer(Customer customer);
        void ListDeleteCustomer(int id);
    }
}
