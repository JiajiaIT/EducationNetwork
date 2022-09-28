using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Reflection;

namespace Factory
{
    public class CreateFactory
    {
        public static I_Admins GetAdmins()
        {
            return (I_Admins)Assembly.Load("DAL").CreateInstance("DAL.D_Admins");
        }
        public static I_ClassSchedule GetClassSchedule()
        {
            return (I_ClassSchedule)Assembly.Load("DAL").CreateInstance("DAL.D_ClassSchedule");
        }
        public static I_CourseClassification GetCourseClassification()
        {
            return (I_CourseClassification)Assembly.Load("DAL").CreateInstance("DAL.D_CourseClassification");
        }
        public static I_Info GetInfo()
        {
            return (I_Info)Assembly.Load("DAL").CreateInstance("DAL.D_Info");
        }
        public static I_InfoCategory GetInfoCategory()
        {
            return (I_InfoCategory)Assembly.Load("DAL").CreateInstance("DAL.D_InfoCategory");
        }
        public static I_Message GetMessage()
        {
            return (I_Message)Assembly.Load("DAL").CreateInstance("DAL.D_Message");
        }
        public static I_StudentWorks GetStudentWorks()
        {
            return (I_StudentWorks)Assembly.Load("DAL").CreateInstance("DAL.D_StudentWorks");
        }
        public static I_StudentWorksCategory GetStudentWorksCategory()
        {
            return (I_StudentWorksCategory)Assembly.Load("DAL").CreateInstance("DAL.D_StudentWorksCategory");
        }
        public static I_Subject GetSubject()
        {
            return (I_Subject)Assembly.Load("DAL").CreateInstance("DAL.D_Subject");
        }
        public static I_Teacher GetTeacher()
        {
            return (I_Teacher)Assembly.Load("DAL").CreateInstance("DAL.D_Teacher");
        }
    }
}
