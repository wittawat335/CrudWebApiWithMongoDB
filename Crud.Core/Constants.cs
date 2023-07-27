using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core
{
    public static class Constants
    {
        public struct MongoDBSettings
        {
            public const string ConnectionString = "MongoDBSetting:ConnectionString";
            public const string DatabaseName = "MongoDBSetting:DatabaseName";
            public const string CollectionName = "MongoDBSetting:CollectionName";
        }
        public struct Msg
        {
            public const string Complete = "Data Successfully Insert";
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
