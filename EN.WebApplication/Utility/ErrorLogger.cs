

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Utility
{
    public static class ErrorLogger
    {
        //private string _logFolderPath;
        //private string _logFileName;
        //private string _logFullPath;
        //public ErrorLogger(string logFolderPath, string logFileName)
        //{
        //    _logFolderPath = logFolderPath;
        //    _logFileName = logFileName;
        //    _logFullPath = $"{_logFolderPath}{_logFileName}";
        //}

        static string _logFolderPath = ConfigHelper.LogFolderPath;
        static string _logFileName = ConfigHelper.LogFileName;
        static string _logFullPath = $"{_logFolderPath}{_logFileName}";
        //public ErrorLogger()
        //{
        //    _logFolderPath = ConfigHelper.LogFolderPath;
        //    _logFileName = ConfigHelper.LogFileName;
        //    _logFullPath = $"{_logFolderPath}{_logFileName}";
        //}

        public static void WriteToFile(string error, string errorType = "Error")
        {
            if (!Directory.Exists(_logFolderPath))
                Directory.CreateDirectory(_logFolderPath);

            if (!File.Exists(_logFullPath))
                File.Create(_logFullPath).Dispose();
            
            using (StreamWriter writer = new StreamWriter(_logFullPath, true))
            {
                writer.WriteLine(string.Format("{0} : {1} : {2}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), errorType, error));
                writer.Close();
            }
        }
    }
}