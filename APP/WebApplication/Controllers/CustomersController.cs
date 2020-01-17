using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private Microsoft.AspNet.Identity.UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public CustomersController(Microsoft.AspNet.Identity.UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: Customers
        private DataContext _context;

        public CustomersController()
        {
            _context = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Registration()
        {
            
            return View(new Customer());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }

                ModelState.AddModelError(string.Empty, "Invali Login Attempt");
            }
            return View(model);
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer customer, Address address)
        {
            _context.Addresses.Add(address);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}