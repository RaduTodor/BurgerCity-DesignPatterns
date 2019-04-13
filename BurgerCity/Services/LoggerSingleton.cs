using System;
using System.Configuration;
using System.IO;
using BurgerCity.Entities;

namespace BurgerCity.Services
{
    public sealed class LoggerSingleton
    {
        private static LoggerSingleton logger;
        private static readonly object padlock = new object();
        private static StreamWriter currentLogFile;
        private static string currentLogPath;

        private LoggerSingleton()
        {
            var currentLogDirectoryPath = string.Format(ConfigurationManager.AppSettings["LogsLocalPath"],
                System.AppContext.BaseDirectory);
            currentLogPath = currentLogDirectoryPath +
                                 string.Format(ConfigurationManager.AppSettings["LogsFileNameFormat"],
                                     DateTime.Now.ToString("yy-MM-dd"));
            Directory.CreateDirectory(currentLogDirectoryPath);
            File.CreateText(currentLogPath).Close();
        }

        public static LoggerSingleton GetLogger
        {
            get
            {
                lock (padlock)
                {
                    if (logger == null)
                    {
                        logger = new LoggerSingleton();
                    }
                    return logger;
                }

            }
        }

        public void LogMessage(string message)
        {
            using (currentLogFile = new StreamWriter(currentLogPath, true))
            {
                currentLogFile.WriteAsync(new LogTemplate(message).ToString());
            }
        }

        public void LogError(Exception exception)
        {
            using (currentLogFile = new StreamWriter(currentLogPath, true))
            {
                currentLogFile.WriteAsync(new LogTemplate(exception.Message, exception.StackTrace).ToString());
            }
        }
    }
}
