using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entity;
using Proje_OOP.ProjeContext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proje_OOP.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/

        Context c = new Context();

        public IActionResult Index()
        {
            var values = c.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NewProduct(Product p)
        {
            c.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            //önce silinecek ürünü bul
            var values = c.Products.Where(x => x.ProductID ==id).FirstOrDefault();
            c.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = c.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(id);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var values = c.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
            values.ProductName = p.ProductName;
            values.Price = p.Price;
            values.Stock = p.Stock;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
} 

