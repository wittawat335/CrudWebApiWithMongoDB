using Crud.Core.Interface;

namespace Crud.Core.Model.MongoDB
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string? DatabaseName { get; set; }
        public string? ConnectionString { get; set; }
    }
}
