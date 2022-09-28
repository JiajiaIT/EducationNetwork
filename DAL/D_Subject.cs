using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_Subject : IDAL.I_Subject
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(Subject entity)
        {
            db.Subject.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Subject.Where(s => s.ID == id).First();
            db.Subject.Remove(data);
            db.SaveChanges();
        }

        public Subject FindByID(int id)
        {
            var data = db.Subject.Where(s => s.ID == id).First();
            return data;
        }

        public List<Subject> List()
        {
            var data = db.Subject.ToList();
            return data;
        }

        public void Update(int id, Subject entity)
        {
            var data = db.Subject.Where(s => s.ID == id).First();
            data.SubjectName = entity.SubjectName;
            db.SaveChanges();
        }
    }
}
