using MobileDeliveryLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MobileDeliveryLogger.Loggers
{
    public class EventLogger: iEventLogger
    {
        public EventLogger() { }

        public void WriteToEventLog(string sLog, string sSource, string message)
        {
            //RegistryPermission regPermission = new RegistryPermission(PermissionState.Unrestricted);  
            //regPermission.Assert();  

            //if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);

            //EventLog.WriteEntry(sSource, message, level);
        }

    }
}
