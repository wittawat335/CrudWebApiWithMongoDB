using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.DTOs
{
    public class RoleDTO
    {
        public string? Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateBy { get; set; }
    }
}
