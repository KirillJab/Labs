using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL
{
    class EncryptionOptions : Options
    {
        public bool EncryptionEnabled { get; set; } = true;
        public EncryptionOptions()
        {

        }
    }
}
