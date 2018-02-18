using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Utility
{
    public class ConfigHelper
    {
        public static string LogFolderPath
        {
            get
            {
                return
                    Get<string>("LogFolderPath");
            }
        }

        public static string LogFileName
        {
            get
            {
                return
                    Get<string>("LogFileName");
            }
        }

        private static T Get<T>(string key)
        {
            try
            {
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
            }
            catch (Exception) { }

            return default(T);
        }
    }
}