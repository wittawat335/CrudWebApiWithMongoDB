using System.Linq.Expressions;

namespace Crud.Core.Domain.RepositoryContract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Insert(T request);
        Task<List<T>> GetAll();
       

        //Task<T> GetByName(string Name);

        //Task<T> UpdateById(T request);

        //Task<T> UpdateSalaryById(T request);

        //Task<T> DeleteById(T request);

        //Task<T> DeleteAll();
    }
}
