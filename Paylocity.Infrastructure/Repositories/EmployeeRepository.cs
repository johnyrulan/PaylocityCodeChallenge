using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paylocity.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>();
        }

        public Employee Get(string name)
        {
            return employees.SingleOrDefault(e => e.Name == name);
        }

        public List<Employee> List()
        {
            return employees;
        }

        public void Save(Employee employee)
        {
            var empl = employees.SingleOrDefault(e => e.Name == employee.Name);

            if (empl != null)
            {
                empl.Name = employee.Name;
                empl.Dependents = employee.Dependents;
            }
            else
            {
                employees.Add(employee);
            }
        }
    }
}
