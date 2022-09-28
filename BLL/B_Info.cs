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
    public class B_Info : I_Info
    {
        public void Add(Info entity)
        {
            Factory.CreateFactory.GetInfo().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetInfo().Delete(id);
        }

        public Info FindByID(int id)
        {
            return Factory.CreateFactory.GetInfo().FindByID(id);
        }

        public List<Info> List()
        {
            return Factory.CreateFactory.GetInfo().List();
        }

        public void Update(int id, Info entity)
        {
            Factory.CreateFactory.GetInfo().Update(id, entity);
        }
    }
}
