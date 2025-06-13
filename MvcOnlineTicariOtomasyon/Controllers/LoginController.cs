using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer customer)
        {
            c.Customers.Add(customer);
            c.SaveChanges();
            return PartialView();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var value = c.Customers.FirstOrDefault(x => x.CustomerEmail == customer.CustomerEmail && x.Password == customer.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.CustomerEmail, false);
                Session["CustomerMail"] = value.CustomerEmail;
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var value = c.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = admin.Username;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}