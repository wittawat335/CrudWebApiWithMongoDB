using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model.Response
{
    public class ResponseList <T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<T> data { get; set; }
    }
}
