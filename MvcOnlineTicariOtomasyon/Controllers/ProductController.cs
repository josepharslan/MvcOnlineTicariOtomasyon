using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var value = from x in c.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                value = value.Where(x => x.ProductName.Contains(p));
            }
            return View(value.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.category = values;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = c.Products.Find(id);
            product.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.category = values;

            var value = c.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            var value = c.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.Brand = product.Brand;
            value.Stock = product.Stock;
            value.BuyingPrice = product.BuyingPrice;
            value.SellingPrice = product.SellingPrice;
            value.CategoryId = product.CategoryId;
            value.ProductImage = product.ProductImage;
            value.Status = product.Status;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult List()
        {
            var value = c.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSale(int id)
        {
            List<SelectListItem> listItems = (from x in c.Employees.ToList()
                                              select new SelectListItem()
                                              {
                                                  Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                  Value = x.EmployeeId.ToString()
                                              }).ToList();
            ViewBag.employees = listItems;
            var deger1 = c.Products.Find(id);
            ViewBag.dgr1 = deger1.ProductId;
            ViewBag.dgr2 = deger1.SellingPrice;
            return View();
        }
        [HttpPost]
        public ActionResult AddSale(SaleTransaction saleTransaction)
        {
            saleTransaction.Date = DateTime.Now;
            c.SaleTransactions.Add(saleTransaction);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}