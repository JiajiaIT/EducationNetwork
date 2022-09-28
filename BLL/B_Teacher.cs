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
    public class B_Teacher : I_Teacher
    {
        public void Add(Teacher entity)
        {
            Factory.CreateFactory.GetTeacher().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetTeacher().Delete(id);
        }

        public Teacher FindByID(int id)
        {
            return Factory.CreateFactory.GetTeacher().FindByID(id);
        }

        public List<Teacher> List()
        {
            return Factory.CreateFactory.GetTeacher().List();
        }

        public void Update(int id, Teacher entity)
        {
            Factory.CreateFactory.GetTeacher().Update(id, entity);
        }
    }
}
