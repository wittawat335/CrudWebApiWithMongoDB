using Crud.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Domain.RepositoryContract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Insert(T request);

        Task<List<T>> GetAll();

        //Task<T> GetById(string ID);

        //Task<T> GetByName(string Name);

        //Task<T> UpdateById(T request);

        //Task<T> UpdateSalaryById(T request);

        //Task<T> DeleteById(T request);

        //Task<T> DeleteAll();
    }
}
