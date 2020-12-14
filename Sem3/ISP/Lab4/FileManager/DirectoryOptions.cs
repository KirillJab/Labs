using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    class DirectoryOptions : Options
    {
        public string SourceDirectory { get; set; } = $@"C:\ETL_Yablonsky\SourceDirectory";
        public string TargetDirectory { get; set; } = $@"C:\ETL_Yablonsky\TargetDirectory\ClientDirectory";
        public string ArchiveDirectory { get; set; } = $@"C:\ETL_Yablonsky\TargetDirectory\Archive";
        public DirectoryOptions()
        {

        }
    }
}
