using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Customers.Count().ToString();
            ViewBag.customer = value;
            var value2 = c.Products.Count().ToString();
            ViewBag.product = value2;
            var value3 = c.Categories.Count().ToString();
            ViewBag.category = value3;
            var value4 = (from x in c.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.customercity = value4;
            var values = c.ToDoLists.ToList();
            return View(values);
        }
    }
}