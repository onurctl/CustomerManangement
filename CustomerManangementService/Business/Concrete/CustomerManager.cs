using CustomerManangementService.Business.Abstract;
using CustomerManangementService.DAL.Abstract;
using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManangementService.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDAL _customerDAL;
        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customerDAL.AddAsync(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
             _customerDAL.Delete(customer);
        }

        public List<CustomerDTO> GetAllCustomer()
        {
            return _customerDAL.GetAllCustomer();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerDAL.GetAsync(x=>x.customerId==id);
            return customer != null ? customer : null;
        }

        public void ListDeleteCustomer(int id)
        {
            var listCustomer = _customerDAL.GetCustomerByAdminID(id);
            _customerDAL.ListDelete(listCustomer);
        }

        public async Task Update(Customer customer)
        {
            var newCustomer= await _customerDAL.GetAsync(x=>x.customerId == customer.customerId);
            newCustomer.nameSurname = customer.nameSurname;
            newCustomer.phone = customer.phone;
            newCustomer.adress = customer.adress;
            _customerDAL.Update(newCustomer); 
        }
    }
}
