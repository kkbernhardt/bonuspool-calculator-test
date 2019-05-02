using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public class HrDepartmentRepository : IHrDepartmentRepository
    {
        private readonly MvcInterviewV3Entities1 _entitiesContext;

        public HrDepartmentRepository(MvcInterviewV3Entities1 entitiesContext)
        {
            _entitiesContext = entitiesContext;
        }

        public void Create(HrDepartment department)
        {
            _entitiesContext.HrDepartments.Add(department);
            _entitiesContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var removableDepartment = _entitiesContext.HrDepartments.Where(d => d.ID == id).FirstOrDefault();
            _entitiesContext.HrDepartments.Remove(removableDepartment);
            _entitiesContext.SaveChanges();
        }

        public IEnumerable<HrDepartment> Read()
        {
            return _entitiesContext.HrDepartments.ToList();
        }
        public HrDepartment GetById(int id)
        {
            var selectedDepartment = _entitiesContext
                .HrDepartments
                .Where(e => e.ID == id)
                .FirstOrDefault();

            return selectedDepartment;
        }
    }
}