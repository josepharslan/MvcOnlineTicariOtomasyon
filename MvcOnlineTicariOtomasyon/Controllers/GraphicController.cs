using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var graph = new Chart(width: 600, height: 600);
            graph.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok")
                .AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                yValues: new[] { 85, 66, 98 }).Write();
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = c.Products.ToList();
            result.ToList().ForEach(x => xvalue.Add(x.ProductName));
            result.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graph = new Chart(width: 500, height: 500)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> ProductList()
        {
            List<Class1> result = new List<Class1>();
            result.Add(new Class1()
            {
                ProductName = "Bilgisayar",
                Stock = 120
            });
            result.Add(new Class1()
            {
                ProductName = "Beyaz Eşya",
                Stock = 150
            });
            result.Add(new Class1()
            {
                ProductName = "Mobilya",
                Stock = 70
            });
            result.Add(new Class1()
            {
                ProductName = "Mobil Cihazlar",
                Stock = 150
            });
            return result;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<Class2> ProductList2()
        {
            List<Class2> result = new List<Class2>();
            using (var c = new Context())
            {
                result = c.Products.Select(x => new Class2()
                {
                    ProductName2 = x.ProductName,
                    Stock2 = x.Stock
                }).ToList();
            }
            return result;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}