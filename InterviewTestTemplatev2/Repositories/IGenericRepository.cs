using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Repositories
{
    public interface IGenericRepository<Type>
    {
        void Create(Type element);
        IEnumerable<Type> Read();
        void Delete(int id);
        Type GetById(int id);
    }
}