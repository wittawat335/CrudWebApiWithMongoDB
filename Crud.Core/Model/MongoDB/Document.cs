using Crud.Core.Interface;
using MongoDB.Bson;

namespace Crud.Core.Model.MongoDB
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
