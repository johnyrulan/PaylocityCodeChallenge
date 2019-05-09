using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;

namespace Paylocity.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
            :base()
        {
            this.employeeService = employeeService;
        }

        public IActionResult List()
        {
            var employees = employeeService.List();

            return View(employees);
        }

        public IActionResult Get(string name)
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(Employee employee)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Edit(Employee employee)
        {
            return View();
        }
    }
}