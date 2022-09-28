using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_Info : IDAL.I_Info
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(Info entity)
        {
            entity.CreateTime = string.Format("{0:U}", DateTime.Now.AddHours(8));
            db.Info.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Info.Where(i => i.ID == id).First();
            db.Info.Remove(data);
            db.SaveChanges();
        }

        public Info FindByID(int id)
        {
            var data = db.Info.Where(i => i.ID == id).First();
            return data;
        }

        public List<Info> List()
        {
            var data = db.Info.ToList();
            return data;
        }

        public void Update(int id, Info entity)
        {
            var data = db.Info.Where(i => i.ID == id).First();
            data.Title = entity.Title;
            data.Img = entity.Img;
            data.Content = entity.Content;
            data.CreateTime = entity.CreateTime = string.Format("{0:U}", DateTime.Now.AddHours(8));
            data.CategoryID = entity.CategoryID;
            db.SaveChanges();
        }
    }
}
