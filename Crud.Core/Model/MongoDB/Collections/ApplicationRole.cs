using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Crud.Core.Model.MongoDB.Collections
{
    [CollectionName("Roles")]
    public class ApplicationRole : MongoIdentityRole<Guid> 
    {
        public string? RoleCode { get; set; }
        public bool IsActive { get; set; }
    }
}
