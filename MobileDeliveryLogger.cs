using MobileDeliveryLogger.BaseClasses;
using MobileDeliveryLogger.Interfaces;
using MobileDeliveryLogger.Loggers;
using System;
using System.Collections.Generic;

namespace MobileDeliveryLogger
{
    public enum LogLevel    { Debug, Info, Warn, Error, Trace }

    public class Logger : BaseLogger
    {
        protected static List<iLogger> file = new List<iLogger>();
        protected int filecnt = 0;
        public Logger(string appName, string strPath="", LogLevel logLevel = LogLevel.Info)
        {
            if (filecnt == 0)
            {
                filecnt++;
                file.Add(new ConsoleLogger(appName));
            }
            if (filecnt == 1)
            {
                filecnt++;
                file.Add(new FileLogger(appName, strPath, logLevel));
            }
            
        }

        public static Action<LogLevel, string, Exception> LogAction = (level, message, ex) =>
        {
            try
            {
                if (level >= LogLevel.Info)
                { 
                    foreach( var it in file)
                    {
                        message = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> " + message + ex?.Message;
                        it.WriteToLog(message, level, ex);
                    }
                    //if (ex != null)
                    //    Console.WriteLine(String.Format("{0}:{1}:{2}:{3}:{4}", DateTime.Now, level, AppName, message, ex));
                    //else
                    //    Console.WriteLine(String.Format("{0}:{1}:{2}:{3}", DateTime.Now, level, AppName, message));
                }
            }
            catch (Exception x) { }
        };

        public static void Warn(string message, Exception ex = null)
        {
            LogAction(LogLevel.Warn, message, ex);
        }

        public static void Error(string message, Exception ex = null)
        {
            LogAction(LogLevel.Error, message, ex);
        }

        public static void Debug(string message, Exception ex = null)
        {
            LogAction(LogLevel.Debug, message, ex);
        }

        public static void Info(string message, Exception ex = null)
        {
            LogAction(LogLevel.Info, message, ex);
        }

        public static void Trace(string message, Exception ex = null)
        {
            LogAction(LogLevel.Trace, message, ex);
        }
    }
}
