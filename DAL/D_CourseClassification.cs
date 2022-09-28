using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_CourseClassification : IDAL.I_CourseClassification
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(CourseClassification entity)
        {
            db.CourseClassification.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.CourseClassification.Where(c => c.ID == id).First();
            db.CourseClassification.Remove(data);
            db.SaveChanges();
        }

        public CourseClassification FindByID(int id)
        {
            var data = db.CourseClassification.Where(c => c.ID == id).First();
            return data;
        }

        public List<CourseClassification> List()
        {
            var data = db.CourseClassification.ToList();
            return data;
        }

        public void Update(int id, CourseClassification entity)
        {
            var data = db.CourseClassification.Where(c => c.ID == id).First();
            data.CategoryName = entity.CategoryName;
            db.SaveChanges();
        }
    }
}
