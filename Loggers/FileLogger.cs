using System;
using System.IO;
using MobileDeliveryLogger.Interfaces;
using MobileDeliveryLogger.BaseClasses;

namespace MobileDeliveryLogger.Loggers
{
    public class FileLogger : BaseLogger, iLogger
    {
        #region "Variables"  
        private string sLogFormat;
        private string sErrorTime;
        iEventLogger evtLogger;
        StreamWriter sw;
        string homeDir= Directory.GetCurrentDirectory();
        //string homeDir2 = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
        string sPathName, sPathLogFileName;
        #endregion

        public FileLogger(string appName, string path, LogLevel logLevel = LogLevel.Info, iEventLogger evntLogger=null) : base(appName)
        {
            if (path != null && path.Length > 1)
                homeDir = path;

            evtLogger = evntLogger;

            //this variable used to create log filename format "  
            //for example filename : ErrorLogYYYYMMDD  
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;

            //Create the log file path name
            sPathName = homeDir + "\\" + AppName + "_" + sErrorTime;
            sPathLogFileName = sPathName + ".log";

            Level = logLevel;
        }

        public void WriteToLog(string sErrMsg, LogLevel level, Exception ex)
        {
            try
            {
                if (Level > level)
                    return;
                //sLogFormat used to create log format :  
                // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message  
                sLogFormat = $"{level} ";

                if (ex != null)
                    sLogFormat += ex.Message;

                using (sw = new StreamWriter(sPathLogFileName, true))
                {
                    sw.WriteLine(sLogFormat + sErrMsg);
                    sw.Flush();
                }
            }
            catch (Exception ex1)
            {
                if (evtLogger!=null)
                    evtLogger.WriteToEventLog(AppName, "Logging.WriteToLogFile", "Error: " + ex1.ToString());
                //sPathLogFileName = $"C:\\Temp\\{AppName}_{sErrorTime}";
                //using (sw = new StreamWriter(sPathLogFileName, true))
                //{
                //    sw.WriteLine(sLogFormat + sErrMsg);
                //    sw.Flush();
                //}
                //throw new Exception($"FileLogger Fatal Error: {ex1.Message} - LogFilePath: {sPathLogFileName}");
            }
        }
    }
}
