using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.SaleTransactions.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> listItems = (from x in c.Products.ToList()
                                              select new SelectListItem()
                                              {
                                                  Text = x.ProductName,
                                                  Value = x.ProductId.ToString()
                                              }).ToList();
            List<SelectListItem> listItems2 = (from x in c.Customers.ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = x.CustomerName + " " + x.CustomerSurname,
                                                   Value = x.CustomerId.ToString()
                                               }).ToList();
            List<SelectListItem> listItems3 = (from x in c.Employees.ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                   Value = x.EmployeeId.ToString()
                                               }).ToList();
            ViewBag.product = listItems;
            ViewBag.customers = listItems2;
            ViewBag.employees = listItems3;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SaleTransaction saleTransaction)
        {

            saleTransaction.Date = DateTime.Now;
            c.SaleTransactions.Add(saleTransaction);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> listItems = (from x in c.Products.ToList()
                                              select new SelectListItem()
                                              {
                                                  Text = x.ProductName,
                                                  Value = x.ProductId.ToString()
                                              }).ToList();
            List<SelectListItem> listItems2 = (from x in c.Customers.ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = x.CustomerName + " " + x.CustomerSurname,
                                                   Value = x.CustomerId.ToString()
                                               }).ToList();
            List<SelectListItem> listItems3 = (from x in c.Employees.ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                   Value = x.EmployeeId.ToString()
                                               }).ToList();
            ViewBag.product = listItems;
            ViewBag.customers = listItems2;
            ViewBag.employees = listItems3;
            var value = c.SaleTransactions.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(SaleTransaction saleTransaction)
        {
            var value = c.SaleTransactions.Find(saleTransaction.TransactionId);
            value.ProductId = saleTransaction.ProductId;
            value.Quantity = saleTransaction.Quantity;
            value.UnitPrice = saleTransaction.UnitPrice;
            value.TotalPrice = saleTransaction.TotalPrice;
            value.EmployeeId = saleTransaction.EmployeeId;
            value.CustomerId = saleTransaction.CustomerId;
            value.Date = saleTransaction.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var values = c.SaleTransactions.Where(x => x.TransactionId == id).ToList();
            return View(values);
        }

    }
}