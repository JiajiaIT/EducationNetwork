using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_InfoCategory : IDAL.I_InfoCategory
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(InfoCategory entity)
        {
            db.InfoCategory.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.InfoCategory.Where(i => i.ID == id).First();
            db.InfoCategory.Remove(data);
            db.SaveChanges();
        }

        public InfoCategory FindByID(int id)
        {
            var data = db.InfoCategory.Where(i => i.ID == id).First();
            return data;
        }

        public List<InfoCategory> List()
        {
            var data = db.InfoCategory.ToList();
            return data;
        }

        public void Update(int id, InfoCategory entity)
        {
            var data = db.InfoCategory.Where(i => i.ID == id).First();
            data.CategoryName = entity.CategoryName;
            db.SaveChanges();
        }
    }
}
