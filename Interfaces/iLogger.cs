using System;

namespace MobileDeliveryLogger.Interfaces
{
    public interface iLogger
    {
        void WriteToLog(string sErrMsg, LogLevel level, Exception ex);

    }
}
