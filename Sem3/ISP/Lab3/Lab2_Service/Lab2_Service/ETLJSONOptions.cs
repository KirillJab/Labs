using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class EtlJsonOptions : ETLOptions
    {
        public EtlJsonOptions(string json)
        {
            ETLOptions EtlJsonOptions = Lab3.Converter.DeserializeJSON<ETLOptions>(json);
            DirectoryOptions = EtlJsonOptions.DirectoryOptions;
            EncryptionOptions = EtlJsonOptions.EncryptionOptions;
            ArchiveOptions = EtlJsonOptions.ArchiveOptions;
            LoggingOptions = EtlJsonOptions.LoggingOptions;
        }
    }
}
