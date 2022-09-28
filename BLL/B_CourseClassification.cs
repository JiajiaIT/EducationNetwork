using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using Factory;

namespace BLL
{
    public class B_CourseClassification : I_CourseClassification
    {
        public void Add(CourseClassification entity)
        {
            Factory.CreateFactory.GetCourseClassification().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetCourseClassification().Delete(id);
        }

        public CourseClassification FindByID(int id)
        {
            return Factory.CreateFactory.GetCourseClassification().FindByID(id);
        }

        public List<CourseClassification> List()
        {
            return Factory.CreateFactory.GetCourseClassification().List();
        }

        public void Update(int id, CourseClassification entity)
        {
            Factory.CreateFactory.GetCourseClassification().Update(id, entity);
        }
    }
}
