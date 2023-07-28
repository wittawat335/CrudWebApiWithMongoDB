using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model.MongoDB.ViewModels
{
    public class RoleViewModel
    {
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateBy { get; set; }
    }
}
