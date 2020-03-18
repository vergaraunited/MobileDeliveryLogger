using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MobileDeliveryLogger.Interfaces
{
    public interface iEventLogger
    {
        void WriteToEventLog(string sLog, string sSource, string message);
    }
}
