using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ETLOptions : Options
    {
        public DirectoryOptions DirectoryOptions { get; set; } = new DirectoryOptions();
        public EncryptionOptions EncryptionOptions { get; set; } = new EncryptionOptions();
        public ArchiveOptions ArchiveOptions { get; set; } = new ArchiveOptions();
        public LoggingOptions LoggingOptions { get; set; } = new LoggingOptions();
        public ETLOptions()
        {

        }
        public ETLOptions(DirectoryOptions directoryOptions, EncryptionOptions encryptionOptions, ArchiveOptions archiveOptions, LoggingOptions loggingOptions)
        {
            DirectoryOptions = directoryOptions;
            EncryptionOptions = encryptionOptions;
            ArchiveOptions = archiveOptions;
            LoggingOptions = loggingOptions;
        }
    }
}
