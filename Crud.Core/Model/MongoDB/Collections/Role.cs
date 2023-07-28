using Crud.Core.Utility;

namespace Crud.Core.Model.MongoDB.Collections
{
    [BsonCollection(Constants.MongoDBSettings.CollectionName.Role)]
    public class Role : Document
    {
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateBy { get; set; }
    }
}
