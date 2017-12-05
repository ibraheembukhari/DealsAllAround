using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DealsAllAround.DataAccess
{
    public static class ConfigurationProvider
    {
        private static readonly string dbKey = "dbx";

        public static string GetDBConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[dbKey].ConnectionString;
        }
    }
}