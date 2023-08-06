using CustomerManangementService.Business.Abstract;
using CustomerManangementService.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManangementUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;

        public AdminController(ILogger<CustomerController> logger, ICustomerService customerService, IAdminService adminService)
        {
            _logger = logger;
            _customerService = customerService;
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAdmin()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var adminList =await  _adminService.GetAllAdmin();
                return View(adminList);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAdmin(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var admin = await _adminService.GetAdminById(id);
                return View(admin);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(Admin admin)
        {
            await _adminService.UpdateAdmin(admin);
            return RedirectToAction("ListAdmin", "Admin");
        }

        [HttpGet]
        public IActionResult AddAdmin()
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
        public async Task<IActionResult> AddAdmin(Admin admin)
        {
            await _adminService.AddAdmin(admin);
            return RedirectToAction("ListAdmin", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            _customerService.ListDeleteCustomer(id);
            var deletedAdmin = await _adminService.GetAdminById(id);
            _adminService.DeleteAdmin(deletedAdmin);
            return RedirectToAction("ListAdmin", "Admin");
        }
    }
}
