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
    public class B_StudentWorksCategory : I_StudentWorksCategory
    {
        public void Add(StudentWorksCategory entity)
        {
            Factory.CreateFactory.GetStudentWorksCategory().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetStudentWorksCategory().Delete(id);
        }

        public StudentWorksCategory FindByID(int id)
        {
            return Factory.CreateFactory.GetStudentWorksCategory().FindByID(id);
        }

        public List<StudentWorksCategory> List()
        {
            return Factory.CreateFactory.GetStudentWorksCategory().List();
        }

        public void Update(int id, StudentWorksCategory entity)
        {
            Factory.CreateFactory.GetStudentWorksCategory().Update(id, entity);
        }
    }
}
