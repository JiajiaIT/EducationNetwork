using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using Factory;

namespace BLL
{
    public class B_Admins : I_Admins
    {
        public void Add(Admins entity)
        {
            Factory.CreateFactory.GetAdmins().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetAdmins().Delete(id);
        }

        public void EditPassword(string username, string password)
        {
            Factory.CreateFactory.GetAdmins().EditPassword(username, password);
        }

        public Admins FindByID(int id)
        {
            return Factory.CreateFactory.GetAdmins().FindByID(id);
        }

        public List<Admins> List()
        {
            return Factory.CreateFactory.GetAdmins().List();
        }

        public int Login(string username,string password)
        {
            return Factory.CreateFactory.GetAdmins().Login(username,password);
        }

        public void Update(int id, Admins entity)
        {
            Factory.CreateFactory.GetAdmins().Update(id, entity);
        }

        public string ViewPassword(string username)
        {
            return Factory.CreateFactory.GetAdmins().ViewPassword(username);
        }
    }
}
