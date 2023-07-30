using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model.MongoDB.Collections
{
    [BsonCollection("Products")]
    public class Products : Document
    {
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateBy { get; set; }
    }
}
