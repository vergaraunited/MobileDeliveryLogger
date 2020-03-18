using System;
using System.Collections.Generic;
using System.Text;

namespace MobileDeliveryLogger.Interfaces
{
    public interface iLogger
    {
        void WriteToLog(string sErrMsg, LogLevel level, Exception ex);

    }
}
