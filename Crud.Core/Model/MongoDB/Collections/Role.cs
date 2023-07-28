using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model.MongoDB.Collections
{
    [BsonCollection("Role")]
    public class Role : Document
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public string? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
