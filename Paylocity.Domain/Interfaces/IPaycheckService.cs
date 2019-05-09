using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Domain.Interfaces
{
    public interface IPaycheckService
    {
        Paycheck Get(string employeeName);
    }
}
