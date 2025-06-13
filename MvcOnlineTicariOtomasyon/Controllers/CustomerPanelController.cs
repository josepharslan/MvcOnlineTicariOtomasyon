using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

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
            var value = c.Customers.FirstOrDefault(x => x.CustomerEmail == mail);
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
        public ActionResult CargoTrack()
        {
            return View();
        }
    }
}