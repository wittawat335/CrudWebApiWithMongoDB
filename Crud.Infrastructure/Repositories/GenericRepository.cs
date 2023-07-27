using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infrastructure.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoConnection;
        private readonly IMongoCollection<InsertRecordRequest> _booksCollection;

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnection = new MongoClient(_configuration["BookStoreDatabase:ConnectionString"]);
            var MongoDataBase = _mongoConnection.GetDatabase(_configuration["BookStoreDatabase:DatabaseName"]);
            _booksCollection = MongoDataBase.GetCollection<InsertRecordRequest>(_configuration["BookStoreDatabase:BooksCollectionName"]);
        }

        public Task<DeleteAllRecordResponse> DeleteAllRecord()
        {
            throw new NotImplementedException();
        }

        public Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllRecordResponse> GetAllRecord()
        {
            throw new NotImplementedException();
        }

        public Task<GetRecordByIdResponse> GetRecordById(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request)
        {
            InsertRecordResponse response = new InsertRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data Successfully Insert";

            try
            {
                request.CreatedDate = DateTime.Now.ToString(); // Insert Current Time
                request.UpdatedDate = string.Empty;
                await _booksCollection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }

        public Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateRecordByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
