using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Repositories;
using System;
using System.Linq;

namespace InterviewTestTemplatev2.Services
{
    public class BonusPoolCalculationService : IBonusPoolCalculationService
    {
        private readonly IHrEmployeeRepository _employeeRepository;

        public BonusPoolCalculationService(IHrEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public decimal CalculateBonusPercentageOfEmployeeSalary(int selectedEmployeeId)
        {
            var selectedEmployee = _employeeRepository.GetById(selectedEmployeeId);
            decimal totalSalary = _employeeRepository.Read().Sum(e => e.Salary);
            try
            {
                decimal percentageOfEmployeeSalary = selectedEmployee.Salary / (decimal)totalSalary;
                return percentageOfEmployeeSalary;
            }
            catch (DivideByZeroException e)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }
        public int CalculateBonusPoolForEmployee(int selectedEmployeeId, int bonusPoolAmount)
        {
            var bonusPercentage = CalculateBonusPercentageOfEmployeeSalary(selectedEmployeeId);
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);

            return bonusAllocation;
        }

        public BonusPoolCalculatorResultModel SetBonusPoolToEmployee(int selectedEmployeeId, int bonusAllocation)
        {
            var bonusResult = new BonusPoolCalculatorResultModel();
            bonusResult.hrEmployee = _employeeRepository.GetById(selectedEmployeeId);
            bonusResult.bonusPoolAllocation = CalculateBonusPoolForEmployee(selectedEmployeeId, bonusAllocation);

            return bonusResult;
        }

        public BonusPoolCalculatorModel AddEmployeesToResultModel()
        {
            var bonusResult = new BonusPoolCalculatorModel();
            bonusResult.AllEmployees = _employeeRepository.Read().ToList();

            return bonusResult;
        }
    }
}