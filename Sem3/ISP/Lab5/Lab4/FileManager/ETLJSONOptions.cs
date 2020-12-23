using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter;

namespace ETL
{
    class EtlJsonOptions : EtlOptions
    {
        public EtlJsonOptions(string json)
        {
            IParser parser = new Converter.Converter();
            EtlOptions etlJsonOptions = parser.DeserializeXML<EtlOptions>(json);
            DirectoryOptions = etlJsonOptions.DirectoryOptions;
            EncryptionOptions = etlJsonOptions.EncryptionOptions;
            ArchiveOptions = etlJsonOptions.ArchiveOptions;
            LoggingOptions = etlJsonOptions.LoggingOptions;
        }
    }
}
