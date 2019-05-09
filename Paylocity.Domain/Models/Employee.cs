using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Domain.Models
{
    public class Employee : Person
    {
        public List<Person> Dependents { get; set; }
    }
}
