using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Capgemini.Helpers
{
    public static class AppSettingsHelper
    {
        public static string GetConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["CapgeminiConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["CapgeminiConnectionStringName"].ToString();
                }

                return "CapgeminiConnectionString";
            }
        }
    }
}