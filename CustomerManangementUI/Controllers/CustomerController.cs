using CustomerManangementService.Business.Abstract;
using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CustomerManangementUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult ListCustomer(CustomerDTO customerDTO)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login","Home");
            }
            else
            {
                var listCustomers = _customerService.GetAllCustomer();
                return View(listCustomers);
            }

        }
        [HttpGet]   
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var customer = await _customerService.GetCustomerById(id);
                return View(customer);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            await _customerService.Update(customer);
            return RedirectToAction("ListCustomer", "Customer");
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            customer.adminId = HttpContext.Session.GetInt32("adminId").Value;
            await _customerService.AddCustomer(customer);
            return RedirectToAction("ListCustomer", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleteCustomer = await _customerService.GetCustomerById(id);
            _customerService.DeleteCustomer(deleteCustomer);
            return RedirectToAction("ListCustomer", "Customer");
        }
    }
}

