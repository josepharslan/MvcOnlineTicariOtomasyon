using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Customers.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = c.Employees.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = c.Categories.Count().ToString();
            ViewBag.v4 = value4;
            var value5 = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.v5 = value5;
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.v6 = value6;
            var value7 = c.Products.Count(x => x.Stock <= 50).ToString();
            ViewBag.v7 = value7;
            var value8 = (from x in c.Products orderby x.SellingPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.v8 = value8;
            var value9 = (from x in c.Products orderby x.SellingPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.v9 = value9;
            var value10 = c.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v10 = value10;
            var value11 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.v11 = value11;
            var value12 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v12 = value12;
            var value13 = c.Products.Where(p => p.ProductId == (c.SaleTransactions.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.v13 = value13;
            var value14 = c.SaleTransactions.Sum(x => x.TotalPrice).ToString();
            ViewBag.v14 = value14;
            var value15 = c.SaleTransactions.Count(x => x.Date.Day == DateTime.Today.Day).ToString();
            ViewBag.v15 = value15;
            var value16 = c.SaleTransactions.Where(x => x.Date.Day == DateTime.Today.Day).Sum(x => (decimal?)x.TotalPrice).ToString();
            ViewBag.v16 = value16;
            return View();
        }
        public ActionResult SimpleTables()
        {
            var colors = new[] { "bg-danger", "bg-warning", "bg-primary", "bg-success", "bg-secondary" };
            var query = c.Customers
                .GroupBy(x => x.CustomerCity)
                .Select(g => new { g.Key, CountNumber = g.Count() })
                .AsEnumerable().
                Select(item => new ClassGroup
                {
                    City = item.Key,
                    CountNumber = item.CountNumber,
                    ColorClass = colors[item.CountNumber % colors.Length]
                }).ToList();
            return View(query);
        }
        public PartialViewResult Partial1()
        {
            var query = c.Employees
                .GroupBy(x => x.Department.DepartmentName)
                .Select(
                g => new
                {
                    g.Key,
                    CountNumber = g.Count()
                }).AsEnumerable().Select(item => new ClassGroup2()
                {
                    Department = item.Key,
                    CountNumber = item.CountNumber,
                }).ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial2()
        {
            var query = c.Customers.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial3()
        {
            var value = c.Products.ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial4()
        {
            var colors = new[] { "bg-danger", "bg-warning", "bg-primary", "bg-success", "bg-secondary" };

            var query = c.Products
                .GroupBy(x => x.Brand)
                .Select(
                g => new
                {
                    g.Key,
                    CountNumber = g.Count()
                }).AsEnumerable().Select(item => new ClassGroup3()
                {
                    Brand = item.Key,
                    CountNumber = item.CountNumber,
                    ColorClass = colors[item.CountNumber % colors.Length]
                }).ToList();
            return PartialView(query);
        }
    }
}