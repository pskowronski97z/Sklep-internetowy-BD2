using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopLogin.Controllers
{
    public class BasketsController : Controller
    {
        private ApplicationDbContext _context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public BasketsController()
        {
            _context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
        }

        // GET: Baskets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToBasket(int productId)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);

            Basket basket = _context.Baskets.FirstOrDefault(b => b.ProductId == productId && b.CustomerId == customer.Id);

            if (basket != null)
            {
                basket.AmountInBasket += 1;
            }
            else
            {
                _context.Baskets.Add(new Basket { ProductId = productId, CustomerId = customer.Id, AmountInBasket = 1 });
            }
            customer.BasketValue += _context.Products.FirstOrDefault(p => p.Id == productId).Price;

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Display()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);

            var baskets = _context.Baskets.Where(b => b.CustomerId == customer.Id).ToList();
           
            foreach(Basket b in baskets){
                b.Product = _context.Products.SingleOrDefault(p => p.Id == b.ProductId);
            }

            customer.Baskets = baskets;

            return View(customer);
        }
    }
}