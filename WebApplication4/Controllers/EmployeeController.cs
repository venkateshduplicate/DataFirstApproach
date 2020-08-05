using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.CustomErrors;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        VenkyEnterpriseEntities db = new VenkyEnterpriseEntities();
        // GET: Employee
        [CustomErrorHandler]
        public ActionResult Index()
        {
            var a = 5;
            var b = 0;
            var c = a / b;
            var employees = db.Employees;
            return View(employees);
        }
        [HandleError]
        public ActionResult Create()
        {
            var a = 5;
            var b = 0;
            var c = a / b;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpException("Invalid Request");

            }
            db.Employees.Add(emp);
            db.SaveChanges();

           return View();
        }
    }
}