using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class CustomersController : Controller
    {
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

        public ActionResult Login()
        {
            return View();
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