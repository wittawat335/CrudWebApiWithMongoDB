using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Crud.Core.Interface
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
