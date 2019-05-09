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
            throw new NotImplementedException();
        }

        public List<Employee> List()
        {
            return new List<Employee> { new Employee { Name = "John" } };
        }

        public void Save(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
