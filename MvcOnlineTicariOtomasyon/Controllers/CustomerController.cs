using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Customers.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.Status = true;
            c.Customers.Add(customer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = c.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }
            var value = c.Customers.Find(customer.CustomerId);
            value.CustomerName = customer.CustomerName;
            value.CustomerSurname = customer.CustomerSurname;
            value.CustomerEmail = customer.CustomerEmail;
            value.CustomerCity = customer.CustomerCity;
            value.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = c.Customers.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerPurchases(int id)
        {
            var customervalue = c.Customers.Where(x => x.CustomerId == id).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.customer = customervalue;
            var value = c.SaleTransactions.Where(x => x.CustomerId == id).ToList();
            return View(value);
        }

    }
}