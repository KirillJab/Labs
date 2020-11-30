using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Lab3
{
    class ArchiveOptions : Options
    {
        public CompressionLevel compressionLevel { get; set; } = CompressionLevel.Optimal;
        public ArchiveOptions()
        {

        }
    }
}
