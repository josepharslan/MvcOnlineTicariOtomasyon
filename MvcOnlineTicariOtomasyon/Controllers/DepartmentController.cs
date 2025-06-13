using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            c.Departments.Add(department);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = c.Departments.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Department department)
        {
            var value = c.Departments.Find(department.DepartmentId);
            value.DepartmentName = department.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = c.Departments.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var value = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.department = value;
            var degerler = c.Employees.Where(x => x.DepartmentId == id).ToList();
            return View(degerler);
        }
        public ActionResult EmployeeSales(int id)
        {
            var employee = c.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.employee = employee;
            var values = c.SaleTransactions.Where(x => x.EmployeeId == id).ToList();
            return View(values);
        }
    }
}