using Crud.Core.Domain.RepositoryContract;
using Crud.Core.Model;
using Crud.Core.Utility;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoConnection;
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoConnection = new MongoClient(_configuration[Constants.MongoDBSettings.ConnectionString]);
            var MongoDataBase = _mongoConnection.GetDatabase(_configuration[Constants.MongoDBSettings.DatabaseName.CrudDB]);
            _collection = MongoDataBase.GetCollection<T>(_configuration[Constants.MongoDBSettings.CollectionName.UserDetails]);
        }

       

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _collection.Find(x => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Insert(T request)
        {
            var result = false;
            try
            {
                await _collection.InsertOneAsync(request);
                result = true;
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
