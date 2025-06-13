using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var value = c.Messages.Where(x => x.Receiver == mail).ToList();
            var mailid = c.Customers.Where(x => x.CustomerEmail == mail).Select(y => y.CustomerId).FirstOrDefault();
            ViewBag.Mailid = mailid;
            var totalsale = c.SaleTransactions.Where(x => x.CustomerId == mailid).Count();
            ViewBag.Totalsale = totalsale;
            var totalprice = c.SaleTransactions.Where(x => x.CustomerId == mailid).Sum(y => y.TotalPrice);
            ViewBag.Totalprice = totalprice;
            var totalproduct = c.SaleTransactions.Where(x => x.CustomerId == mailid).Sum(y => y.Quantity);
            ViewBag.Totalproduct = totalproduct;
            var namesurname = c.Customers.Where(x => x.CustomerEmail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.Namesurname = namesurname;
            return View(value);
        }
        public ActionResult OrderList()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerEmail == mail).Select(x => x.CustomerId).FirstOrDefault();
            var values = c.SaleTransactions.Where(x => x.CustomerId == id).ToList();
            return View(values);
        }
        public ActionResult MessageInbox()
        {
            var email = Session["CustomerMail"] as string;
            var value = c.Messages.Where(x => x.Receiver == email).OrderByDescending(x => x.MessageDate).ToList();
            var mailcount = c.Messages.Where(x => x.Receiver == email).Count();
            var mailcount2 = c.Messages.Where(x => x.Sender == email).Count();
            ViewBag.mailnumber = mailcount;
            ViewBag.mailnumber2 = mailcount2;
            return View(value);
        }
        public ActionResult MessageSendbox()
        {
            var email = Session["CustomerMail"] as string;
            var value = c.Messages.Where(x => x.Sender == email).OrderByDescending(x => x.MessageDate).ToList();
            var mailcount = c.Messages.Where(x => x.Receiver == email).Count();
            var mailcount2 = c.Messages.Where(x => x.Sender == email).Count();
            ViewBag.mailnumber = mailcount;
            ViewBag.mailnumber2 = mailcount2;
            return View(value);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = c.Messages.Where(x => x.MessageId == id).ToList();
            var email = Session["CustomerMail"] as string;
            var mailcount = c.Messages.Where(x => x.Receiver == email).Count();
            var mailcount2 = c.Messages.Where(x => x.Sender == email).Count();
            ViewBag.mailnumber = mailcount;
            ViewBag.mailnumber2 = mailcount2;
            return View(value);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var email = Session["CustomerMail"] as string;
            var mailcount = c.Messages.Where(x => x.Receiver == email).Count();
            var mailcount2 = c.Messages.Where(x => x.Sender == email).Count();
            ViewBag.mailnumber = mailcount;
            ViewBag.mailnumber2 = mailcount2;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var email = Session["CustomerMail"] as string;
            message.MessageDate = DateTime.Today;
            message.Sender = email;
            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }
        public ActionResult CargoTrack(string p)
        {
            var cargo = from x in c.CargoDetails select x;
            cargo = cargo.Where(y => y.TrackNumber.Contains(p));

            return View(cargo.ToList());
        }
        public ActionResult CustomerCargoTrack(string id)
        {
            var value = c.CargoTracks.Where(x => x.TrackCode == id).ToList();
            return View(value);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public PartialViewResult Settings()
        {
            var email = Session["CustomerMail"] as string;
            var id = c.Customers.Where(x => x.CustomerEmail == email).Select(y => y.CustomerId).FirstOrDefault();
            var customer = c.Customers.Find(id);
            return PartialView(customer);
        }
        [HttpPost]
        public ActionResult Settings(Customer model)
        {
            var value = c.Customers.Find(model.CustomerId);

            value.CustomerName = model.CustomerName;
            value.CustomerSurname = model.CustomerSurname;
            value.CustomerEmail = model.CustomerEmail;
            value.Password = model.Password;
            value.CustomerCity = model.CustomerCity;

            c.SaveChanges();
            return RedirectToAction("Index", "CustomerPanel");
        }
        public PartialViewResult Notice()
        {
            var value = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(value);
        }
    }
}