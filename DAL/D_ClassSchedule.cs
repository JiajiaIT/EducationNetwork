using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_ClassSchedule : IDAL.I_ClassSchedule
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(ClassSchedule entity)
        {
            db.ClassSchedule.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.ClassSchedule.Where(c => c.ID == id).First();
            db.ClassSchedule.Remove(data);
            db.SaveChanges();
        }

        public ClassSchedule FindByID(int id)
        {
            var data = db.ClassSchedule.Where(c => c.ID == id).First();
            return data;
        }

        public List<ClassSchedule> List()
        {
            var data = db.ClassSchedule.ToList();
            return data;
        }

        public void Update(int id, ClassSchedule entity)
        {
            var data = db.ClassSchedule.Where(c => c.ID == id).First();
            data.Name = entity.Name;
            data.Img = entity.Img;
            data.Describe = entity.Describe;
            data.CategoryID = entity.CategoryID;
            db.SaveChanges();
        }
    }
}
