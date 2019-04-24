using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UserLogin
{
    class LogContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }

        public LogContext()
            : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
