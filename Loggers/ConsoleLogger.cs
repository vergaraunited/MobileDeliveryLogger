using MobileDeliveryLogger.BaseClasses;
using MobileDeliveryLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MobileDeliveryLogger.Loggers
{
    public class ConsoleLogger : BaseLogger, iLogger
    {
        public ConsoleLogger(string appName) : base(appName) { }

        public void WriteToLog(string message, LogLevel level, Exception ex)
        {
            if (ex != null)
                Console.WriteLine(String.Format("{0}:{1}:{2}:{3}", level, AppName, message, ex));
            else
                Console.WriteLine(String.Format("{0}:{1}:{2}", level, AppName, message));
        }
    }
}
