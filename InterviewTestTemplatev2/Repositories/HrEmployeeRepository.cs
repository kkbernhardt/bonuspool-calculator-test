using InterviewTestTemplatev2.Data;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTestTemplatev2.Repositories
{
    public class HrEmployeeRepository : IHrEmployeeRepository
    {
        private readonly MvcInterviewV3Entities1 _entitiesContext;

        public HrEmployeeRepository(MvcInterviewV3Entities1 entitiesContext)
        {
            _entitiesContext = entitiesContext;
        }

        public void Create(HrEmployee employee)
        {
            _entitiesContext.HrEmployees.Add(employee);
            _entitiesContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var removableEmployee = _entitiesContext
                .HrEmployees
                .Where(e => e.ID == id)
                .FirstOrDefault();

            _entitiesContext.HrEmployees.Remove(removableEmployee);
            _entitiesContext.SaveChanges();
        }

        public IEnumerable<HrEmployee> Read()
        {
            var employees = _entitiesContext.HrEmployees.ToList();

            return employees;
        }

        public HrEmployee GetById(int id)
        {
            var selectedEmployee = _entitiesContext
                .HrEmployees
                .FirstOrDefault(x => x.ID == id);

            return selectedEmployee;
        }
    }
}