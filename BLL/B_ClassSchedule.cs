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
    public class B_ClassSchedule : I_ClassSchedule
    {
        public void Add(ClassSchedule entity)
        {
            Factory.CreateFactory.GetClassSchedule().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetClassSchedule().Delete(id);
        }

        public ClassSchedule FindByID(int id)
        {
            return Factory.CreateFactory.GetClassSchedule().FindByID(id);
        }

        public List<ClassSchedule> List()
        {
            return Factory.CreateFactory.GetClassSchedule().List();
        }

        public void Update(int id, ClassSchedule entity)
        {
            Factory.CreateFactory.GetClassSchedule().Update(id, entity);
        }
    }
}
