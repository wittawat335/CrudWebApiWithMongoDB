﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Utility
{
    public static class Constants
    {
        public struct MongoDBSettings
        {
            public const string ConnectionString = "MongoDBSetting:ConnectionString";
            public struct DatabaseName
            {
                public const string CrudDB = "MongoDBSetting:DatabaseName:CrudDB";
            }
            public struct CollectionName
            {
                public const string UserDetails = "MongoDBSetting:CollectionName:UserDetails";
                public const string Role = "Role";
            }
        }

        public struct Msg
        {
            public const string InsertComplete = "Data Successfully Insert";
            public const string UpdateComplete = "Data Successfully Update";
            public const string DeleteComplete = "Data Successfully Delete";
            public const string GetList = "Data Fetch Successfully";
            public const string NoRecord = "No Record Found";
        }
        public struct StatusData
        {
            public const bool True = true;
            public const bool False = false;
        }
    }
}
