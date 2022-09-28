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
    public class B_Message : I_Message
    {
        public void Add(Message entity)
        {
            Factory.CreateFactory.GetMessage().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetMessage().Delete(id);
        }

        public Message FindByID(int id)
        {
            return Factory.CreateFactory.GetMessage().FindByID(id);
        }

        public List<Message> List()
        {
            return Factory.CreateFactory.GetMessage().List();
        }

        public void Update(int id, Message entity)
        {
            Factory.CreateFactory.GetMessage().Update(id, entity);
        }
    }
}
