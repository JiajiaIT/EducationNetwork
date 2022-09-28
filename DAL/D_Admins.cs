using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class D_Admins : IDAL.I_Admins
    {
        EducationNetworkEntities db = new EducationNetworkEntities();
        public void Add(Admins entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var admin = db.Admins.Where(a => a.ID == id).First();
            db.Admins.Remove(admin);
            db.SaveChanges();
        }

        public void EditPassword(string username, string password)
        {
            var data = db.Admins.Where(a => a.UserName == username).First();
            data.PassWord = password;
            db.SaveChanges();
        }

        public Admins FindByID(int id)
        {
            var admin = db.Admins.Where(a => a.ID == id).First();
            return admin;
        }

        public List<Admins> List()
        {
            var admins = db.Admins.ToList();
            return admins;
        }

        public int Login(string username,string password)
        {
            var data = db.Admins.Where(a => a.UserName ==username&&a.PassWord==password);
            if (data.Count() > 0)
            {
                return 1;
            }
            else {
                return 0;
            }
        }

        public void Update(int id, Admins entity)
        {
            var admin = db.Admins.Where(a => a.ID == id).First();
            admin.UserName = entity.UserName;
            admin.PassWord = entity.PassWord;
            admin.NickName = entity.NickName;
            admin.Phone = entity.Phone;
            admin.E_mail = entity.E_mail;
            db.SaveChanges();
        }

        public string ViewPassword(string username)
        {
            var data= db.Admins.Where(a => a.UserName == username).First();
            return data.PassWord;
        }
    }
}
