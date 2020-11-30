using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class DirectoryOptions : Options
    {
        public string SourceDirectory { get; set; } = $@"C:\Lab3_Yablonsky\SourceDirectory";
        public string TargetDirectory { get; set; } = $@"C:\Lab3_Yablonsky\TargetDirectory\ClientDirectory";
        public string ArchiveDirectory { get; set; } = $@"C:\Lab3_Yablonsky\TargetDirectory\Archive";
        public DirectoryOptions()
        {

        }
    }
}
