using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace UserLogin
{
    public class Logger
    {

        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            LogContext context = new LogContext();

            Logs log = new Logs(DateTime.Now, LoginValidation.CurrentUserName, (int)LoginValidation.CurrentUserRole, activity);

            context.Logs.Add(log);
            context.SaveChanges();

            string activityLine = DateTime.Now + "; " + LoginValidation.CurrentUserName + " "+
                LoginValidation.CurrentUserRole +" "+ activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("test.txt") == true) 
            {
                File.AppendAllText("test.txt", activityLine +"\n");
                
                //string s = File.ReadAllText("test.txt");
                //Console.Write(s);
            }
            
        }

        public static void GetCurrentSeassionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("Logs:\n");

            foreach (var item in filteredActivities)
            {
                sb.Append(item + Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
