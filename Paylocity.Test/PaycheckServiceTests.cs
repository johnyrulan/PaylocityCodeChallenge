using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Paylocity.Domain.Constants;
using Paylocity.Domain.Interfaces;
using Paylocity.Domain.Models;
using Paylocity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.Test
{
    [TestClass]
    public class PaycheckServiceTests
    {
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private IPaycheckService paycheckService;

        private readonly string testEmployeeName = "Johny";

        [TestInitialize]
        public void Initialize()
        {
            mockEmployeeRepository = new Mock<IEmployeeRepository>();
            paycheckService = new PaycheckService(mockEmployeeRepository.Object);            

            mockEmployeeRepository
                .Setup(_ => _.Get(It.IsAny<string>()))
                .Returns(new Employee {
                    Name = testEmployeeName,
                    Dependents = new List<Person>()
                });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaycheckService_Get_Should_Return_Null_If_No_Employee_Found()
        {
            mockEmployeeRepository
                .Setup(_ => _.Get(It.IsAny<string>()))
                .Returns<Paycheck>(null);

            var paycheck = paycheckService.Get(string.Empty);            
        }

        [TestMethod]        
        public void PaycheckService_Get_Should_Return_Base_Employee_Pay()
        {
            var paycheck = paycheckService.Get(testEmployeeName);

            Assert.AreEqual(EmployeeConstants.EmployeeBasePay, paycheck.BasePay);
        }
    }
}
