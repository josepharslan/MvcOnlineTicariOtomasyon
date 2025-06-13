using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Products.ToList();
            return View(value);
        }
    }
}