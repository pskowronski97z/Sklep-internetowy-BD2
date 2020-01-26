using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShopLogin.Models;

namespace ShopLogin.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index(int catId)
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            List<Product> filteredProducts = new List<Product>();

            
                foreach (var product in products)
                {
                    if (product.CategoryId == catId)
                    {                    
                        filteredProducts.Add(product);
                    }
                }          

            return View(filteredProducts);
        }

        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
    }
}