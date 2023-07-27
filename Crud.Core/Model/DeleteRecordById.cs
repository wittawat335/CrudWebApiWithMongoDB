using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model
{
    public class DeleteRecordByIdRequest
    {
        [Required]
        public string Id { get; set; }
    }

    public class DeleteRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
