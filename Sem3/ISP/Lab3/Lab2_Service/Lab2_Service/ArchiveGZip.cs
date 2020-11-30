using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ArchiveGZip
    {
        public static void GZip(string source, string target, CompressionLevel compressionLevel)
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(target))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, compressionLevel))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
        }
        public static void DeGZip(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
        }
    }
}
