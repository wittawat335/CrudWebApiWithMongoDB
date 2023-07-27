using Crud.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Services.Contracts
{
    public interface IDemoService
    {
        Task<bool> Insert(InsertRecordRequest request);
        Task<List<InsertRecordRequest>> GetAll();

        //Task<GetRecordByIdResponse> GetById(string ID);

        //Task<GetRecordByNameResponse> GetByName(string Name);

        //Task<UpdateRecordByIdResponse> UpdateById(InsertRecordRequest request);

        //Task<UpdateRecordByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request);

        //Task<Response<DeleteRecordByIdResponse>> DeleteById(DeleteRecordByIdRequest request);

        //Task<Response<DeleteAllRecordResponse>> DeleteAll();
    }
}
