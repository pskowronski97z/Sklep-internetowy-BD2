using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext _context;

        public ProductsController()
        {
            _context = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
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