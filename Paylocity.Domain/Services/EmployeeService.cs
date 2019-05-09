using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Get(string name)
        {
            return employeeRepository.Get(name);
        }

        public List<Employee> List()
        {
            return employeeRepository.List();
        }

        public void Save(Employee employee)
        {
            employeeRepository.Save(employee);
        }
    }
}
