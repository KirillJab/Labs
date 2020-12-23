using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter;

namespace ETL
{
    class EtlXmlOptions : EtlOptions
    {
        public EtlXmlOptions(string xml)
        {
            IParser parser = new Converter.Converter();
            EtlOptions etlXmlOptions = parser.DeserializeXML<EtlOptions>(xml);
            DirectoryOptions = etlXmlOptions.DirectoryOptions;
            EncryptionOptions = etlXmlOptions.EncryptionOptions;
            ArchiveOptions = etlXmlOptions.ArchiveOptions;
            LoggingOptions = etlXmlOptions.LoggingOptions;
        }
    }
}
