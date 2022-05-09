using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspNetCoreMvc.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _department;

        //create contructor for inject interfaces
        public DepartmentController(IDepartment department)
        {
            this._department = department;
        }
        public IActionResult Index()
        {
            var department = _department.GetDepartment();
            return View(department);
            //returning list of deparments
        }
    }
}