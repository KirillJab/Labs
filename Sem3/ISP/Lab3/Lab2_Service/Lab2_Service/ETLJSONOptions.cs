using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class EtlJsonOptions : EtlOptions
    {
        public EtlJsonOptions(string json)
        {
            EtlOptions etlJsonOptions = Converter.DeserializeJSON<EtlOptions>(json);
            DirectoryOptions = etlJsonOptions.DirectoryOptions;
            EncryptionOptions = etlJsonOptions.EncryptionOptions;
            ArchiveOptions = etlJsonOptions.ArchiveOptions;
            LoggingOptions = etlJsonOptions.LoggingOptions;
        }
    }
}
