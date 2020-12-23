using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Options
{
    public class ConnectionOptions
    {
        public string DataSource { get; set; } = "DESKTOP-QOSVQN3\\SQLEXPRESS";
        public string Database { get; set; } = "AdventureWorks2017";
        public string User { get; set; } = "KillReal";
        public string Password { get; set; } = "qwerty1234";
    }
}
