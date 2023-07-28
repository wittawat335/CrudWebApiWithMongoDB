
using Crud.Core.Model.MongoDB.Interfaces;

namespace Crud.Core.Model.MongoDB
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string? DatabaseName { get; set; }
        public string? ConnectionString { get; set; }
    }
}
