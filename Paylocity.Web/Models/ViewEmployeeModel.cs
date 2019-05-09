using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.Web.Models
{
    public class ViewEmployeeModel
    {
        public Employee Employee { get; set; }
        public Paycheck Paycheck { get; set; }
    }
}
