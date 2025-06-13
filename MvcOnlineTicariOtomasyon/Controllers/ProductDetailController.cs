using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ProductDetail pd = new ProductDetail();
            //var value = c.Products.Where(x => x.ProductId == 8).ToList();
            pd.Products = c.Products.Where(x => x.ProductId == 1).ToList();
            pd.Details = c.Details.Where(y => y.DetailId == 1).ToList();
            return View(pd);
        }
    }
}