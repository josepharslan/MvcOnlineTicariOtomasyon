using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var values = c.Categories.ToList().ToPagedList(sayfa, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var value = c.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            var value = c.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = c.Categories.Find(id);
            c.Categories.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}