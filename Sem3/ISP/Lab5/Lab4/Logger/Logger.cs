using Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : ILogger
    {
        LoggingOptions logOptions;
        DataAccessLayer.DataAccessLayer dal;
        public Logger()
        {

        }
        public Logger(LoggingOptions options, IParser parser)
        {
            logOptions = options;
            dal = new DataAccessLayer.DataAccessLayer(logOptions.ConnectionOptions, parser);
        }
        public void Start()
        {

        }
        public void Log(string msg)
        {
            if (logOptions.LoggingEnabled)
            {
                dal.Log(DateTime.Now, msg);
            }
        }
        public void Stop()
        {
            logOptions.LoggingEnabled = false;
        }
    }
}
