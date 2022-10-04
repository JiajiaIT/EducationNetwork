using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Tools
    {
        public static string GetNewName(string exname)
        {
            return Guid.NewGuid().ToString().Split('-')[0] + exname;
        }
        public static string ServerPath = ConfigurationManager.AppSettings["ServerPath"].ToString();
        public static string ClassScheduleImg = ConfigurationManager.AppSettings["ClassScheduleImg"].ToString();
        public static string StudentWorksImg = ConfigurationManager.AppSettings["StudentWorksImg"].ToString();
        public static string TeacherImg = ConfigurationManager.AppSettings["TeacherImg"].ToString();
    }
}