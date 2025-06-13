using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Invoices.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var value = c.InvoiceDetails.Where(x => x.InvoiceId == id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = c.Invoices.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {
            var value = c.Invoices.Find(invoice.InvoiceId);
            value.InvoiceSequenceNumber = invoice.InvoiceSequenceNumber;
            value.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            value.Deliverer = invoice.Deliverer;
            value.Receiver = invoice.Receiver;
            value.TaxOffice = invoice.TaxOffice;
            value.InvoiceDate = invoice.InvoiceDate;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDetail(InvoiceDetail invoiceDetail)
        {
            c.InvoiceDetails.Add(invoiceDetail);
            c.SaveChanges();
            return RedirectToAction("/Details/" + invoiceDetail.InvoiceId);
        }
    }
}