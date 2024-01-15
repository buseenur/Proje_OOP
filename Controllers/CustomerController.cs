using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje_OOP.Entity;
using Proje_OOP.ProjeContext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proje_OOP.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            using var c = new Context();
           var values = c.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            using var c = new Context();

            if (p.CustomerName.Length >=6 && p.CustomerCity != "" && p.CustomerCity.Length >= 3)

            {
                c.Add(p);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Hatalı Kullanım";
                return View();
            }
            
        }

        public IActionResult DeleteCustomer(int id)
        {
            using var c = new Context();
            var values = c.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            c.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            using var c = new Context();
            var values = c.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            using var c = new Context();
            var values = c.Customers.Where(x => x.CustomerID == p.CustomerID).FirstOrDefault();
            values.CustomerName = p.CustomerName;
            values.CustomerCity = p.CustomerCity;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

