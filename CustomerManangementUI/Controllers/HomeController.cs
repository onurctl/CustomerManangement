using CustomerManangementService.Business.Abstract;
using CustomerManangementService.DAL.Concrete.EntityFramework;
using CustomerManangementService.Entities.Concrete;
using CustomerManangementService.Entities.DTOs;
using CustomerManangementUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerManangementUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminService _adminService;

        public HomeController(ILogger<HomeController> logger, IAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ListCustomer", "Customer");
            }
        }
        
        [HttpPost]
        public ActionResult Login(Admin a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                if (ModelState.IsValid)
                {
                   var obj = _adminService.Login(a);
                   if (obj != null)
                   {
                        HttpContext.Session.SetString("username", obj.username.ToString());
                        HttpContext.Session.SetInt32("adminId", obj.adminId);
                        return RedirectToAction("ListCustomer", "Customer");
                    }
                }
            }
            
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}