using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopLogin.Models;

namespace ShopLogin.Controllers
{
    [Authorize(Roles = RoleName.RoleAdmin)]
    public class CustomersController : Controller
    {

        // GET: Customers
        private ApplicationDbContext _context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Registration()
        {
            
            return View(new Customer());
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