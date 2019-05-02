using InterviewTestTemplatev2.Models;

namespace InterviewTestTemplatev2.Services
{
    public interface IBonusPoolCalculationService
    {
        decimal CalculateBonusPercentageOfEmployeeSalary(int id);
        int CalculateBonusPoolForEmployee(int selectedEmployeeId, int bonusAllocation);
        BonusPoolCalculatorResultModel SetBonusPoolToEmployee(int selectedEmployeeId, int bonusAllocation);
        BonusPoolCalculatorModel AddEmployeesToResultModel();
    }
}
