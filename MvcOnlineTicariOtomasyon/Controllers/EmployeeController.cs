using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Employees.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> list = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentId.ToString()
                                         }).ToList();
            ViewBag.department = list;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var uzanti = Path.GetExtension(file.FileName);
                var safAd = Path.GetFileNameWithoutExtension(file.FileName);

                var sanalYol = "/Image/" + safAd + uzanti;
                var fizikselYol = Server.MapPath(sanalYol);
                var klasorYolu = Server.MapPath("/Image/");

                file.SaveAs(fizikselYol);
                employee.EmployeeImage = sanalYol;
            }

            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> list = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentId.ToString()
                                         }).ToList();
            ViewBag.department = list;
            var value = c.Employees.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {

            var value = c.Employees.Find(employee.EmployeeId);
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var uzanti = Path.GetExtension(file.FileName);
                var safAd = Path.GetFileNameWithoutExtension(file.FileName);

                var sanalYol = "/Image/" + safAd + uzanti;
                var fizikselYol = Server.MapPath(sanalYol);
                var klasorYolu = Server.MapPath("/Image/");

                file.SaveAs(fizikselYol);
                value.EmployeeImage = sanalYol;
            }
            value.EmployeeName = employee.EmployeeName;
            value.EmployeeSurname = employee.EmployeeSurname;
            value.DepartmentId = employee.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var value = c.Employees.ToList();
            return View(value);
        }
    }
}