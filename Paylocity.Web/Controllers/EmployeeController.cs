using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;
using Paylocity.Web.Models;

namespace Paylocity.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IPaycheckService paycheckService;

        public EmployeeController(IEmployeeService employeeService, IPaycheckService paycheckService)
            :base()
        {
            this.employeeService = employeeService;
            this.paycheckService = paycheckService;
        }

        [HttpGet]        
        public IActionResult List()
        {
            var employees = employeeService.List();

            return View(employees);
        }

        [HttpGet]
        [Route("/Employee/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(string name)
        {
            var employee = new Employee
            {
                Name = name,
                Dependents = new List<Person>()
            };

            employeeService.Save(employee);

            return Redirect("/");
        }

        [HttpGet]
        [Route("/Employee/{name}/AddDependent")]
        public IActionResult AddDependent(string name)
        {
            var employee = employeeService.Get(name);

            var model = new AddDependentModel
            {
                EmployeeName = employee.Name,
                DependentName = string.Empty
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddDependent(AddDependentModel model)
        {
            var employee = employeeService.Get(model.EmployeeName);

            employee.Dependents.Add(new Person
            {
                Name = model.DependentName
            });

            employeeService.Save(employee);

            return Redirect("/Employee/" + model.EmployeeName);
        }

        [HttpGet]
        [Route("/Employee/{name}")]
        public IActionResult Get(string name)
        {
            var employee = employeeService.Get(name);
            var paycheck = paycheckService.Get(name);

            var model = new ViewEmployeeModel
            {
                Employee = employee,
                Paycheck = paycheck
            };

            return View(model);
        }
    }
}