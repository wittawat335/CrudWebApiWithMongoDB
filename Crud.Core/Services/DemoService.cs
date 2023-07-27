using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model;
using Crud.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services
{
    public class DemoService : IDemoService
    {
        private readonly IGenericRepository<InsertRecordRequest> _repository;

        public DemoService(IGenericRepository<InsertRecordRequest> repository)
        {
            _repository = repository;
        }

        public async Task<List<InsertRecordRequest>> GetAll()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Insert(InsertRecordRequest request)
        {
            bool result = false;
            try
            {
                request.CreatedDate = DateTime.Now.ToString(); // Insert Current Time
                request.UpdatedDate = string.Empty;
                result = await _repository.Insert(request);
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
