using Crud.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Domain.RepositoryContract
{
    public interface IGenericRepository
    {
        Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);

        Task<GetAllRecordResponse> GetAllRecord();

        Task<GetRecordByIdResponse> GetRecordById(string ID);

        Task<GetRecordByNameResponse> GetRecordByName(string Name);

        Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request);

        Task<UpdateRecordByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request);

        Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request);

        Task<DeleteAllRecordResponse> DeleteAllRecord();
    }
}
