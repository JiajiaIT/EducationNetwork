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
    public class B_Subject : I_Subject
    {
        public void Add(Subject entity)
        {
            Factory.CreateFactory.GetSubject().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetSubject().Delete(id);
        }

        public Subject FindByID(int id)
        {
            return Factory.CreateFactory.GetSubject().FindByID(id);
        }

        public List<Subject> List()
        {
            return Factory.CreateFactory.GetSubject().List();
        }

        public void Update(int id, Subject entity)
        {
            Factory.CreateFactory.GetSubject().Update(id, entity);
        }
    }
}
