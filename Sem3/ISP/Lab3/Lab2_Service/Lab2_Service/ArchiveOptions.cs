﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Lab3
{
    class ArchiveOptions : Options
    {
        public bool CompressionEnabled { get; set; } = true;
        public ArchiveOptions()
        {

        }
    }
}
