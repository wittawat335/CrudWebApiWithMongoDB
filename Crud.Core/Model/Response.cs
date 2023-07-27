using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model
{
    public class Response<T>
    {
        public T? value { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
