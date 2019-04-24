using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Logs
    {
        public int LogsId { get; set; }
        public DateTime DateOfLog { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public string Activity { get; set; }

        public Logs()
        { }

        public Logs(DateTime date,string userName,int userRole,string activity)
        {
            DateOfLog = date;
            UserName = userName;
            UserRole = userRole;
            Activity = activity;
        }
    }
}
