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
        public ActionResult Dynamic()
        {
            Class4 c4 = new Class4();
            c4.Invoices = c.Invoices.ToList();
            c4.InvoicesDetails = c.InvoiceDetails.ToList();
            return View(c4);
        }
        public ActionResult AddInvoice(string sequencen, string serialn, DateTime date, string taxoffice, string receiver, string deliverer, string total, InvoiceDetail[] invoiceDetails)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceSequenceNumber = sequencen;
            invoice.InvoiceSerialNumber = serialn;
            invoice.InvoiceDate = date;
            invoice.TaxOffice = taxoffice;
            invoice.Receiver = receiver;
            invoice.Deliverer = deliverer;
            invoice.TotalAmount = decimal.Parse(total);
            c.Invoices.Add(invoice);
            foreach (var item in invoiceDetails)
            {
                InvoiceDetail ind = new InvoiceDetail();
                ind.Description = item.Description;
                ind.Quantity = item.Quantity;
                ind.InvoiceId = item.InvoiceId;
                ind.UnitPrice = item.UnitPrice;
                ind.LineTotal = item.LineTotal;
                c.InvoiceDetails.Add(ind);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}