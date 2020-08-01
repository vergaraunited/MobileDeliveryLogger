namespace MobileDeliveryLogger.Interfaces
{
    public interface iEventLogger
    {
        void WriteToEventLog(string sLog, string sSource, string message);
    }
}
