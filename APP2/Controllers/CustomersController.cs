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

    [Authorize]
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

        [Authorize(Roles =RoleName.RoleAdminOrCustommer)]//w innych miejscach moze byc to realizowane inaczej, to jest prawidlowy sposob, ktory wspieramy
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

        public ActionResult ModifyData()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            var address = _context.Addresses.SingleOrDefault(a => a.Id == customer.AddressId);
            customer.Address = address;

            ModifyDataViewModel model = new ModifyDataViewModel
            {
                Email = customer.Email,
                City = address.City,
                Street = address.Street,
                Building = address.Building,
                Apartment = address.Apartment,
                PostCode = address.PostCode,
                PhoneNumber = customer.PhoneNumber,
                Login = customer.Login,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ModifyData(ModifyDataViewModel model)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            var address = _context.Addresses.SingleOrDefault(a => a.Id == customer.AddressId);


            user.Email = model.Email;

            customer.Email = model.Email;
            address.City = model.City;
            address.Street = model.Street;
            address.Building = model.Building;
            address.Apartment = model.Apartment;
            address.PostCode = model.PostCode;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Login = model.Login;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;

            _context.SaveChanges();


            return RedirectToAction("Details", "Customers");
        }
    }
}