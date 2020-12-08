using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class EtlOptions : Options
    {
        public DirectoryOptions DirectoryOptions { get; set; } = new DirectoryOptions();
        public EncryptionOptions EncryptionOptions { get; set; } = new EncryptionOptions();
        public ArchiveOptions ArchiveOptions { get; set; } = new ArchiveOptions();
        public LoggingOptions LoggingOptions { get; set; } = new LoggingOptions();
        public EtlOptions()
        {

        }
        public EtlOptions(DirectoryOptions directoryOptions, EncryptionOptions encryptionOptions, ArchiveOptions archiveOptions, LoggingOptions loggingOptions)
        {
            DirectoryOptions = directoryOptions;
            EncryptionOptions = encryptionOptions;
            ArchiveOptions = archiveOptions;
            LoggingOptions = loggingOptions;
        }
    }
}
