﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Model
{
    public class GetRecordByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public InsertRecordRequest data { get; set; }
    }

    public class GetRecordByNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<InsertRecordRequest> data { get; set; }
    }
}
