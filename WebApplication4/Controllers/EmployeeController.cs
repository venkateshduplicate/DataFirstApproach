using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        VenkyEnterpriseEntities db = new VenkyEnterpriseEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees;
            return View(employees);
        }
        public ActionResult Create()
        {
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