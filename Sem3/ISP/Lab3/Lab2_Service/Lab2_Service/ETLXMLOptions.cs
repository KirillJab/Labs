using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class EtlXmlOptions : EtlOptions
    {
        public EtlXmlOptions(string xml)
        {
            EtlOptions etlXmlOptions = Converter.DeserializeXML<EtlOptions>(xml);
            DirectoryOptions = etlXmlOptions.DirectoryOptions;
            EncryptionOptions = etlXmlOptions.EncryptionOptions;
            ArchiveOptions = etlXmlOptions.ArchiveOptions;
            LoggingOptions = etlXmlOptions.LoggingOptions;
        }
    }
}
