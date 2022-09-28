using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_Message : IDAL.I_Message
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(Message entity)
        {
            db.Message.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Message.Where(m => m.ID == id).First();
            db.Message.Remove(data);
            db.SaveChanges();
        }

        public Message FindByID(int id)
        {
            var data = db.Message.Where(m => m.ID == id).First();
            return data;
        }

        public List<Message> List()
        {
            var data = db.Message.ToList();
            return data;
        }

        public void Update(int id, Message entity)
        {
            var data = db.Message.Where(m => m.ID == id).First();
            data.Name = entity.Name;
            data.Phone = entity.Phone;
            data.QQ = entity.QQ;
            data.E_mail = entity.E_mail;
            data.Message1 = entity.Message1;
            db.SaveChanges();
        }
    }
}
