using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class LoggingOptions : Options
    {
        public bool LoggingEnabled { get; set; } = true;
        public string LoggingPath{ get; set; } = $@"C:\Lab3_Yablonsky\TargetDirectory\log.txt";
        public LoggingOptions()
        {

        }
    }
}
