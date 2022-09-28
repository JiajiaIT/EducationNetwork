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
    public class B_InfoCategory : I_InfoCategory
    {
        public void Add(InfoCategory entity)
        {
            Factory.CreateFactory.GetInfoCategory().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetInfoCategory().Delete(id);
        }

        public InfoCategory FindByID(int id)
        {
            return Factory.CreateFactory.GetInfoCategory().FindByID(id);
        }

        public List<InfoCategory> List()
        {
            return Factory.CreateFactory.GetInfoCategory().List();
        }

        public void Update(int id, InfoCategory entity)
        {
            Factory.CreateFactory.GetInfoCategory().Update(id, entity);
        }
    }
}
