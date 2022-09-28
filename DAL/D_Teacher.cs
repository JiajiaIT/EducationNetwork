using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_Teacher : IDAL.I_Teacher
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(Teacher entity)
        {
            db.Teacher.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Teacher.Where(t => t.ID == id).First();
            db.Teacher.Remove(data);
            db.SaveChanges();
        }

        public Teacher FindByID(int id)
        {
            var data = db.Teacher.Where(t => t.ID == id).First();
            return data;
        }

        public List<Teacher> List()
        {
            var data = db.Teacher.ToList();
            return data;
        }

        public void Update(int id, Teacher entity)
        {
            var data = db.Teacher.Where(t => t.ID == id).First();
            data.Name = entity.Name;
            data.Img = entity.Img;
            data.Describe = entity.Describe;
            data.SubjectID = entity.SubjectID;
            db.SaveChanges();
        }
    }
}
