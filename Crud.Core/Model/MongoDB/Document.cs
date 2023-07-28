using Crud.Core.Model.MongoDB.Interfaces;
using MongoDB.Bson;

namespace Crud.Core.Model.MongoDB
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
