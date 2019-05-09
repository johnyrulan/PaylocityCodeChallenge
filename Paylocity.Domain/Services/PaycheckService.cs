using Paylocity.Domain.Constants;
using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Domain.Services
{
    public class PaycheckService : IPaycheckService
    {
        private readonly IEmployeeRepository employeeRepository;

        public PaycheckService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        private bool NameStartsWithA(string name)
        {
            var startsWithA = (name.StartsWith('a') || name.StartsWith('A'));

            return startsWithA;
        }

        private double CalculateBenefitsCost(string name, bool isEmployee)
        {
            double benefitsCost = isEmployee
                ? EmployeeConstants.EmployeeBaseBenefitsCost
                : EmployeeConstants.EmployeeBaseDependentCost;

            if (NameStartsWithA(name))
            {
                benefitsCost -= benefitsCost * EmployeeConstants.StartsWithABenefitsDiscount;
            }

            return benefitsCost;
        }

        private double CalculateAdjustedPay(double benefitsCost)
        {
            double adjustedPay = EmployeeConstants.EmployeeBasePay - (benefitsCost / PaycheckConstants.PaychecksPerYear);

            return adjustedPay;
        }

        public Paycheck Get(string employeeName)
        {
            var employee = employeeRepository.Get(employeeName);

            if (employee == null)
            {
                throw new ArgumentException();
            }

            var paycheck = new Paycheck
            {
                BasePay = EmployeeConstants.EmployeeBasePay
            };

            double benefitsCost = CalculateBenefitsCost(employee.Name, true);

            foreach (var dependent in employee.Dependents)
            {
                benefitsCost += CalculateBenefitsCost(dependent.Name, false);
            }

            paycheck.AdjustedPay = CalculateAdjustedPay(benefitsCost);

            return paycheck;
        }
    }
}
