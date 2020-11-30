using System;
using System.IO;
using System.Threading;

namespace Lab3
{
    class Logger
    {
        LoggingOptions logOptions;
        public Logger()
        {
            
        }
        public Logger(LoggingOptions options)
        {
            logOptions = options;
        }

        public void Start()
        {
            while (logOptions.LoggingEnabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Log(string msg)
        {
            if(logOptions.LoggingEnabled)
            {
                File.AppendAllText(logOptions.LoggingPath, $"[{ DateTime.Now:dd.MM hh:mm:ss}]:  {msg}\n");
            }
        }
        public void Stop()
        {
            logOptions.LoggingEnabled = false;
        }
    }
}