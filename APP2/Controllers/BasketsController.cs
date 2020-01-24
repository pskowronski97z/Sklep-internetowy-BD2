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
    [Authorize]
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


        public ActionResult PayForBasket(int somVal)
        {
            while (true)
            {
                ApplicationUser userX = UserManager.FindById(User.Identity.GetUserId());
                var customerX = _context.Customers.SingleOrDefault(c => c.UserId == userX.Id);
                Basket basketX = _context.Baskets.FirstOrDefault(b => b.CustomerId == customerX.Id);
                if (basketX == null) { break; }
                _context.Baskets.Remove(basketX);
                basketX = _context.Baskets.FirstOrDefault(d => d.CustomerId == customerX.Id);
                _context.SaveChanges();
            }
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            Basket basket = _context.Baskets.FirstOrDefault(b => b.CustomerId == customer.Id);
            customer.BasketValue = 0;
            _context.SaveChanges();
           // return HttpNotFound;
            return RedirectToAction("Index", "Products");
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

        public ActionResult RemoveFromBasket(int productId)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            Basket basket = _context.Baskets.FirstOrDefault(b => b.ProductId == productId && b.CustomerId == customer.Id);

            customer.BasketValue -= _context.Products.FirstOrDefault(p => p.Id == productId).Price;
            if (basket != null)
            {
                if(basket.AmountInBasket > 0)
                {
                    basket.AmountInBasket -= 1;
                }
                if (basket.AmountInBasket == 0)
                {
                    _context.Baskets.Remove(basket);
                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Display", "Baskets");
       //     return RedirectToAction("Index", "Products");

        }

        public ActionResult RemoveBasket(int productId)
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());
            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);
            Basket basket = _context.Baskets.FirstOrDefault(b => b.ProductId == productId && b.CustomerId == customer.Id);


            for (int i = 0; i< basket.AmountInBasket;i++)
            {
                customer.BasketValue -= _context.Products.FirstOrDefault(p => p.Id == productId).Price;
            }
            
            if (basket != null)
            {
                if (basket.AmountInBasket > 0)
                {
                    basket.AmountInBasket -= 1;
                }
                if (basket.AmountInBasket == 0)
                {
                    _context.Baskets.Remove(basket);
                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Display", "Baskets");
        }


        public ActionResult Display()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            var customer = _context.Customers.SingleOrDefault(c => c.UserId == user.Id);

            var baskets = _context.Baskets.Where(b => b.CustomerId == customer.Id).ToList();

            foreach (Basket b in baskets)
            {
                b.Product = _context.Products.SingleOrDefault(p => p.Id == b.ProductId);
            }

            customer.Baskets = baskets;

            return View(customer);
        }

        public ActionResult deletos(int productId)
        {
            //return HttpNotFound();
            ViewBag.productId = productId;
            return View();
        }
    }
}