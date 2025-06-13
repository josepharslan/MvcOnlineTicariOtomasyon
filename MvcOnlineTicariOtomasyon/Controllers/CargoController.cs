using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var cargo = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(y => y.TrackNumber.Contains(p));
            }
            return View(cargo.ToList());
        }
        public ActionResult Create()
        {
            Random rnd = new Random();
            string[] strings = { "A", "B", "C", "D", "E", "F" };
            int k1, k2, k3;
            k1 = rnd.Next(0, strings.Length);
            k2 = rnd.Next(0, strings.Length);
            k3 = rnd.Next(0, strings.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + strings[k1] + s2 + strings[k2] + s3 + strings[k3];
            ViewBag.trackcode = kod;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CargoDetail cargoDetail)
        {
            c.CargoDetails.Add(cargoDetail);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoDetail(string id)
        {
            var value = c.CargoTracks.Where(x => x.TrackCode == id).ToList();
            return View(value);
        }
    }
}