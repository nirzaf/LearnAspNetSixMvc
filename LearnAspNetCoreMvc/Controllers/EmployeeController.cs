using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspNetCoreMvc.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            this._employee = employee;
        }
        public IActionResult Index()
        {
            var employee = _employee.GetEmployee();
            return View(employee);
        }
    }
}