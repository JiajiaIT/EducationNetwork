using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_StudentWorksCategory : IDAL.I_StudentWorksCategory
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(StudentWorksCategory entity)
        {
            db.StudentWorksCategory.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.StudentWorksCategory.Where(s => s.ID == id).First();
            db.StudentWorksCategory.Remove(data);
            db.SaveChanges();
        }

        public StudentWorksCategory FindByID(int id)
        {
            var data = db.StudentWorksCategory.Where(s => s.ID == id).First();
            return data;
        }

        public List<StudentWorksCategory> List()
        {
            var data = db.StudentWorksCategory.ToList();
            return data;
        }

        public void Update(int id, StudentWorksCategory entity)
        {
            var data = db.StudentWorksCategory.Where(s => s.ID == id).First();
            data.CategoryName = entity.CategoryName;
            db.SaveChanges();
        }
    }
}
