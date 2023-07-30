using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model;
using Crud.Core.Utility;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Crud.Infrastructure.Repositories
{
    public class DemoRepository : IDemoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoConnection;
        private readonly IMongoCollection<InsertRecordRequest> _collection;
        public DemoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnection = new MongoClient(_configuration[Constants.MongoDBSettings.ConnectionString]);
            var MongoDataBase = _mongoConnection.GetDatabase(_configuration[Constants.MongoDBSettings.DatabaseName.CrudDB]);
            _collection = MongoDataBase
                .GetCollection<InsertRecordRequest>(_configuration[Constants.MongoDBSettings.CollectionName.UserDetails]);
        }
        public async Task<GetAllRecordResponse> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data Fetch Successfully";

            try
            {
                response.data = new List<InsertRecordRequest>();
                response.data = await _collection.Find(x => true).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<GetRecordByIdResponse> GetRecordById(string ID)
        {
            GetRecordByIdResponse response = new GetRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Fetch Data Successfully by ID";

            try
            {
                response.data = await _collection.Find(x => (x.Id == ID)).FirstOrDefaultAsync();
                if (response.data == null)
                {
                    response.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            response.IsSuccess = true;
            response.Message = "Fetch data Successfully By Name";

            try
            {
                response.data = new List<InsertRecordRequest>();
                response.data = await _collection.Find(x => (x.FirstName == Name) || (x.LastName == Name)).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request)
        {
            InsertRecordResponse response = new InsertRecordResponse();
            response.IsSuccess = true;
            response.Message = Constants.Msg.InsertComplete;

            try
            {
                request.CreatedDate = DateTime.Now.ToString(); // Insert Current Time
                request.UpdatedDate = string.Empty;
                await _collection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Update Record Successfully By Id";

            try
            {
                GetRecordByIdResponse GetResponse = await GetRecordById(request.Id); // Find ID for Update
                if (!GetResponse.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Message = GetResponse.Message;
                    return response;
                }

                request.CreatedDate = GetResponse.data.CreatedDate;
                request.UpdatedDate = DateTime.Now.ToString();

                var Result = await _collection.ReplaceOneAsync(x => x.Id == request.Id, request); //Update Data
                if (!Result.IsAcknowledged)
                {
                    response.Message = "Input Id Not Found / Updation Not Occurs";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<UpdateRecordByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest request)
        {
            UpdateRecordByIdResponse response = new UpdateRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Update Salary Successfully";

            try
            {
                var Filter = new BsonDocument()
                    .Add("Salary", request.Salary)
                    .Add("UpdatedDate", DateTime.Now.ToString());

                var updateDoc = new BsonDocument("$set", Filter);

                var Result = await _collection.UpdateOneAsync(x => x.Id == request.Id, updateDoc);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
            DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Delete Record Successfully By Id";

            try
            {

                var result = await _collection.DeleteOneAsync(x => x.Id == request.Id);
                if (!result.IsAcknowledged)
                {
                    response.IsSuccess = true;
                    response.Message = "Record Not Found In Database For Deletion, Please Enter Valid Id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
        public async Task<DeleteAllRecordResponse> DeleteAllRecord()
        {
            DeleteAllRecordResponse response = new DeleteAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Clear Database Successfully";

            try
            {
                var Result = await _collection.DeleteManyAsync(x => true);
                if (!Result.IsAcknowledged)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong.";
                }
                else
                {
                    response.Message = Result.DeletedCount == 0 ? "Database Already Cleaned." : response.Message;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return response;
        }
    }
}
