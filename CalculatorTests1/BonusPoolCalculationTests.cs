using InterviewTestTemplatev2.Controllers;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CalculatorTests1
{
    [TestClass]
    public class BonusPoolCalculationTests
    {
        [TestMethod]
        public void CalculateBonusPercentageOfEmployeeSalary_Successful_When_It_Has_Correct_Input()
        {
            var employeeRepository = new Mock<IHrEmployeeRepository>();
            var employee = new HrEmployee
            {
                ID = 3,
                FistName = "John",
                SecondName = "Smith",
                DateOfBirth = Convert.ToDateTime("1985-09-05"),
                HrDepartmentId = 1,
                JobTitle = "Accountant",
                Salary = 60000,
                Full_Name = " John Smith"
            };

            List<HrEmployee> employees = new List<HrEmployee>()
            {
                new HrEmployee
                {
                    ID = 3,
                    FistName = "John",
                    SecondName = "Smith",
                    DateOfBirth = Convert.ToDateTime("1985-09-05"),
                    HrDepartmentId = 1,
                    JobTitle = "Accountant",
                    Salary = 60000,
                    Full_Name = " John Smith"
                },
                new HrEmployee
                {
                    ID = 2,
                    FistName = "Janet",
                    SecondName = "Jones",
                    DateOfBirth = Convert.ToDateTime("1975-09-05"),
                    HrDepartmentId = 2,
                    JobTitle = "HR Director",
                    Salary = 90000,
                    Full_Name = "Janet Jones"
                }
            };

            employeeRepository.Setup(x => x.GetById(employee.ID))
                .Returns(employee);
            employeeRepository.Setup(x => x.Read())
                .Returns(employees);

            var service = new BonusPoolCalculationService(employeeRepository.Object);
            var actual = service.CalculateBonusPercentageOfEmployeeSalary(employee.ID);

            Assert.AreEqual(0.4m, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CalculateBonusPercentageOfEmployeeSalary_When_TotalSalary_Is_Null_Throws_Exception()
        {
            var employeeRepository = new Mock<IHrEmployeeRepository>();
            var employee = new HrEmployee
            {
                ID = 3,
                FistName = "John",
                SecondName = "Smith",
                DateOfBirth = Convert.ToDateTime("1985-09-05"),
                HrDepartmentId = 1,
                JobTitle = "Accountant",
                Salary = 35000,
                Full_Name = " John Smith"
            };

            List<HrEmployee> employees = new List<HrEmployee>()
            {
                new HrEmployee
                {
                    ID = 3,
                    FistName = "John",
                    SecondName = "Smith",
                    DateOfBirth = Convert.ToDateTime("1985-09-05"),
                    HrDepartmentId = 1,
                    JobTitle = "Accountant",
                    Salary = 0,
                    Full_Name = " John Smith"
                },
                new HrEmployee
                {
                    ID = 2,
                    FistName = "Janet",
                    SecondName = "Jones",
                    DateOfBirth = Convert.ToDateTime("1975-09-05"),
                    HrDepartmentId = 2,
                    JobTitle = "HR Director",
                    Salary = 0,
                    Full_Name = "Janet Jones"
                }
            };

            employeeRepository.Setup(x => x.GetById(employee.ID))
                .Returns(employee);
            employeeRepository.Setup(x => x.Read())
                .Returns(employees);

            var service = new BonusPoolCalculationService(employeeRepository.Object);
            service.CalculateBonusPercentageOfEmployeeSalary(employee.ID);
        }

        [TestMethod]
        public void CalculateBonusPoolForEmployee_Successful_When_It_Has_Correct_Input()
        {
            var bonusPoolAmount = 50;

            var employee = new HrEmployee
            {
                ID = 3,
                FistName = "John",
                SecondName = "Smith",
                DateOfBirth = Convert.ToDateTime("1985-09-05"),
                HrDepartmentId = 1,
                JobTitle = "Accountant",
                Salary = 60000,
                Full_Name = " John Smith"
            };

            List<HrEmployee> employees = new List<HrEmployee>()
            {
                new HrEmployee
                {
                    ID = 3,
                    FistName = "John",
                    SecondName = "Smith",
                    DateOfBirth = Convert.ToDateTime("1985-09-05"),
                    HrDepartmentId = 1,
                    JobTitle = "Accountant",
                    Salary = 60000,
                    Full_Name = " John Smith"
                },
                new HrEmployee
                {
                    ID = 2,
                    FistName = "Janet",
                    SecondName = "Jones",
                    DateOfBirth = Convert.ToDateTime("1975-09-05"),
                    HrDepartmentId = 2,
                    JobTitle = "HR Director",
                    Salary = 90000,
                    Full_Name = "Janet Jones"
                }
            };

            var employeeRepository = new Mock<IHrEmployeeRepository>();
            employeeRepository.Setup(x => x.GetById(employee.ID))
                .Returns(employee);
            employeeRepository.Setup(x => x.Read())
                .Returns(employees);

            var service = new BonusPoolCalculationService(employeeRepository.Object);
            var actual = service.CalculateBonusPoolForEmployee(employee.ID, bonusPoolAmount);
            Assert.AreEqual(20, actual);
        }
    }
}
