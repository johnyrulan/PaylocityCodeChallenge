using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Domain.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> List();
        void Save(Employee employee);
        Employee Get(string name);
    }
}
