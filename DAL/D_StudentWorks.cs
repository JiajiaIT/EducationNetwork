using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_StudentWorks : IDAL.I_StudentWorks
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(StudentWorks entity)
        {
            db.StudentWorks.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.StudentWorks.Where(s => s.ID == id).First();
            db.StudentWorks.Remove(data);
            db.SaveChanges();
        }

        public StudentWorks FindByID(int id)
        {
            var data = db.StudentWorks.Where(s => s.ID == id).First();
            return data;
        }

        public List<StudentWorks> List()
        {
            var data = db.StudentWorks.ToList();
            return data;
        }

        public void Update(int id, StudentWorks entity)
        {
            var data = db.StudentWorks.Where(s => s.ID == id).First();
            data.Img = entity.Img;
            data.CategoryID = entity.CategoryID;
            db.SaveChanges();
        }
    }
}
